using App.Core.Models;
using App.Core.Services;
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.Forms
{
    public partial class PengaduanKebersihan : UserControl
    {
        private readonly User _currentUser;
        private readonly PengaduanKebersihanService _pengaduanService;
        private string? _selectedPengaduanId = null;

        private bool _isClearing = false;

        public PengaduanKebersihan(User user)
        {
            InitializeComponent();
            _currentUser = user;

            this.Dock = DockStyle.Fill;
            _pengaduanService = new PengaduanKebersihanService();

            this.Load += PengaduanKebersihan_Load;
            buttonSave.Click += ButtonSave_Click;
            buttonClear.Click += ButtonClear_Click;
            buttonDelete.Click += ButtonDelete_Click;
            dataGridViewDataKebersihan.SelectionChanged += DataGridViewDataKebersihan_SelectionChanged;
            dataGridViewDataKebersihan.RowPostPaint += DataGridViewDataKebersihan_RowPostPaint;
        }

        private async void PengaduanKebersihan_Load(object? sender, EventArgs e)
        {
            SetupDataGridViewStyles();
            SetupComboBoxes();
            await LoadDataAsync();
        }

        private void SetupDataGridViewStyles()
        {
            dataGridViewDataKebersihan.RowHeadersVisible = true;
            dataGridViewDataKebersihan.TopLeftHeaderCell.Value = "Pilih Data";
            dataGridViewDataKebersihan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewDataKebersihan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dataGridViewDataKebersihan.AllowUserToAddRows = false;
            dataGridViewDataKebersihan.AllowUserToDeleteRows = false;
            dataGridViewDataKebersihan.ReadOnly = true;

            var headerStyle = dataGridViewDataKebersihan.ColumnHeadersDefaultCellStyle;
            headerStyle.BackColor = Color.Navy;
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font("Product Sans", 10, FontStyle.Bold);
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataGridViewDataKebersihan.TopLeftHeaderCell.Style.ApplyStyle(headerStyle);
        }

        private void SetupComboBoxes()
        {
            comboBoxPrioritas.DataSource = Enum.GetValues(typeof(Prioritas));

            comboBoxKategori.Items.AddRange(new string[] { "Sampah", "WC Umum", "Saluran Air", "Lingkungan" });

            comboBoxPrioritas.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxKategori.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private async Task LoadDataAsync()
        {
            var data = await _pengaduanService.AmbilSemuaPengaduanAsync();
            var displayData = data.Select(p => new
            {
                p.Id,
                Pelapor = p.Detail.NamaPelapor,
                p.Status,
                p.Detail.PrioritasPengaduan,
                p.Detail.Kategori,
                p.Detail.Lokasi,
                p.Detail.Deskripsi,
                p.TanggalDibuat
            }).ToList();

            dataGridViewDataKebersihan.DataSource = displayData;

            if (dataGridViewDataKebersihan.Columns["Id"] != null)
            {
                dataGridViewDataKebersihan.Columns["Id"].Visible = false;
            }

            dataGridViewDataKebersihan.ClearSelection();
        }

        private void DataGridViewDataKebersihan_SelectionChanged(object? sender, EventArgs e)
        {
            if (_isClearing) return;

            if (dataGridViewDataKebersihan.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewDataKebersihan.SelectedRows[0];

                _selectedPengaduanId = selectedRow.Cells["Id"].Value?.ToString();


                comboBoxPrioritas.SelectedItem = (Prioritas)selectedRow.Cells["PrioritasPengaduan"].Value;
                comboBoxKategori.SelectedItem = selectedRow.Cells["Kategori"].Value?.ToString();
                textBoxLokasi.Text = selectedRow.Cells["Lokasi"].Value?.ToString();
                textBoxNamaPelapor.Text = selectedRow.Cells["NamaPelapor"].Value?.ToString();
                richTextBoxDeskripsi.Text = selectedRow.Cells["Deskripsi"].Value?.ToString();

                labelTextFormKebersihan.Text = "Ubah Data Pengaduan";
                buttonSave.Text = "Ubah Data";
            }
            else
            {
                ClearForm();
            }
        }

        private async void ButtonSave_Click(object? sender, EventArgs e)
        {
            try
            {
                if (comboBoxPrioritas.SelectedItem is not Prioritas prioritas)
                {
                    MessageBox.Show("Prioritas harus dipilih.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string? kategori = comboBoxKategori.SelectedItem?.ToString();
                string lokasi = textBoxNamaPelapor.Text;
                string deskripsi = richTextBoxDeskripsi.Text;
                string namaPelapor = textBoxNamaPelapor.Text;

                if (string.IsNullOrWhiteSpace(lokasi) || string.IsNullOrWhiteSpace(deskripsi) || string.IsNullOrWhiteSpace(kategori))
                {
                    MessageBox.Show("Semua field harus diisi.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_selectedPengaduanId == null)
                {
                    await _pengaduanService.TambahPengaduanAsync(namaPelapor, deskripsi, lokasi, prioritas, kategori);
                    MessageBox.Show("Pengaduan berhasil ditambahkan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    await _pengaduanService.UbahDataPengaduanAsync(_selectedPengaduanId, namaPelapor, deskripsi, lokasi, prioritas, kategori);
                    MessageBox.Show("Pengaduan berhasil diubah.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                await LoadDataAsync();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonClear_Click(object? sender, EventArgs e)
        {
            ClearForm();
        }

        private async void ButtonDelete_Click(object? sender, EventArgs e)
        {
            if (_selectedPengaduanId == null)
            {
                MessageBox.Show("Pilih pengaduan yang ingin dihapus.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show("Apakah Anda yakin ingin menghapus pengaduan ini?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    await _pengaduanService.HapusPengaduanAsync(_selectedPengaduanId);
                    MessageBox.Show("Pengaduan berhasil dihapus.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDataAsync();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Gagal menghapus data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearForm()
        {
            _isClearing = true;

            _selectedPengaduanId = null;
            textBoxNamaPelapor.Clear();
            richTextBoxDeskripsi.Clear();
            textBoxLokasi.Clear();
            comboBoxPrioritas.SelectedIndex = 0;
            comboBoxKategori.SelectedIndex = -1;

            labelTextFormKebersihan.Text = "Form Pengaduan Kebersihan";
            buttonSave.Text = "Simpan Data";

            dataGridViewDataKebersihan.ClearSelection();

            _isClearing = false;
        }

        private void DataGridViewDataKebersihan_RowPostPaint(object? sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (dataGridViewDataKebersihan.Rows[e.RowIndex].Selected) return;

            string symbol = "▶";
            using (Font font = new Font("Product Sans", 10, FontStyle.Bold))
            using (SolidBrush brush = new SolidBrush(Color.Gray))
            {
                SizeF stringSize = e.Graphics.MeasureString(symbol, font);
                float x = e.RowBounds.Left + (dataGridViewDataKebersihan.RowHeadersWidth - stringSize.Width) / 2;
                float y = e.RowBounds.Top + (e.RowBounds.Height - stringSize.Height) / 2;
                e.Graphics.DrawString(symbol, font, brush, x, y);
            }
        }

        private void buttonSave_Click_1(object sender, EventArgs e)
        {

        }
    }
}