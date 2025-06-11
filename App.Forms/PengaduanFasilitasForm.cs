using App.Core.Models;
using App.Core.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.Forms
{
    public partial class PengaduanFasilitasForm : UserControl
    {
        private readonly PengaduanFasilitasService _pengaduanService;
        private string? _selectedPengaduanId = null;

        private bool _isClearing = false;
        public PengaduanFasilitasForm()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            _pengaduanService = new PengaduanFasilitasService();

            this.Load += PengaduanFasilitasForm_Load;
            buttonSimpan.Click += buttonSimpan_Click;
            buttonClearForm.Click += buttonClearForm_Click;
            buttonHapus.Click += buttonHapus_Click;
            dataGridViewDataKebersihan.SelectionChanged += DataGridViewDataKebersihan_SelectionChanged;
            dataGridViewDataKebersihan.RowPostPaint += DataGridViewDataKebersihan_RowPostPaint;
        }

        private async void PengaduanFasilitasForm_Load(object? sender, EventArgs e)
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
            headerStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewDataKebersihan.TopLeftHeaderCell.Style.ApplyStyle(headerStyle);
        }

        private void SetupComboBoxes()
        {
            comboBoxPrioritas.DataSource = Enum.GetValues(typeof(Prioritas));
            comboBoxJenisFasilitas.Items.AddRange(new string[] { "Taman Bermain", "Lapangan", "Lampu Jalan", "Jalan Lingkungan" });

            comboBoxPrioritas.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxJenisFasilitas.DropDownStyle = ComboBoxStyle.DropDownList;
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
                p.Detail.JenisFasilitas,
                p.Detail.Lokasi,
                p.Detail.Deskripsi,
                TanggalDibuat = p.TanggalDibuat.ToString("dd/MM/yyyy HH:mm:ss")
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

                comboBoxPrioritas.SelectedItem = selectedRow.Cells["PrioritasPengaduan"].Value;
                comboBoxJenisFasilitas.SelectedItem = selectedRow.Cells["JenisFasilitas"].Value?.ToString();
                textBoxLokasi.Text = selectedRow.Cells["Lokasi"].Value?.ToString() ?? string.Empty;
                richTextBoxDeskripsi.Text = selectedRow.Cells["Deskripsi"].Value?.ToString() ?? string.Empty;

                labelTextFormKebersihan.Text = "Form Ubah Pengaduan Fasilitas"; //jgn lupa ganti labelnya
                buttonSimpan.Text = "Ubah Data Pengaduan";
            }
            else
            {
                ClearForm();
            }
        }

        private async void buttonSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxPrioritas.SelectedItem is not Prioritas prioritas)
                {
                    MessageBox.Show("Prioritas harus dipilih.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string? jenisFasilitas = comboBoxJenisFasilitas.SelectedItem?.ToString();
                string lokasi = textBoxLokasi.Text;
                string deskripsi = richTextBoxDeskripsi.Text;
                string namaPelapor = "Dhina";

                if (string.IsNullOrWhiteSpace(lokasi) || string.IsNullOrWhiteSpace(deskripsi) || string.IsNullOrWhiteSpace(jenisFasilitas))
                {
                    MessageBox.Show("Semua field harus diisi.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tambah atau Ubah
                if (_selectedPengaduanId == null)
                {
                    await _pengaduanService.TambahPengaduanAsync(namaPelapor, deskripsi, lokasi, prioritas, jenisFasilitas);
                    MessageBox.Show("Pengaduan berhasil ditambahkan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    await _pengaduanService.UbahDataPengaduanAsync(_selectedPengaduanId, namaPelapor, deskripsi, lokasi, prioritas, jenisFasilitas);
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

        private void buttonClearForm_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private async void buttonHapus_Click(object sender, EventArgs e)
        {
            if (_selectedPengaduanId == null)
            {
                MessageBox.Show("Tidak ada pengaduan yang dipilih untuk dihapus.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    MessageBox.Show($"Terjadi kesalahan saat menghapus pengaduan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearForm()
        {
            _isClearing = true;
            _selectedPengaduanId = null;

            textBoxLokasi.Clear();
            richTextBoxDeskripsi.Clear();

            comboBoxPrioritas.SelectedIndex = 0;
            comboBoxJenisFasilitas.SelectedIndex = -1;

            labelTextFormKebersihan.Text = "Form Pengaduan Fasilitas"; //jgn lupa ganti labelnya
            buttonSimpan.Text = "Simpan Data";

            dataGridViewDataKebersihan.ClearSelection();
            _isClearing = false;
        }

        private void DataGridViewDataKebersihan_RowPostPaint(object? sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (dataGridViewDataKebersihan.Rows[e.RowIndex].Selected) return;

            string symbol = "▶";
            using (Font font = new Font("Segoe UI", 10, FontStyle.Bold))
            using (SolidBrush brush = new SolidBrush(Color.Gray))
            {
                SizeF stringSize = e.Graphics.MeasureString(symbol, font);
                float x = e.RowBounds.Left + (dataGridViewDataKebersihan.RowHeadersWidth - stringSize.Width) / 2;
                float y = e.RowBounds.Top + (e.RowBounds.Height - stringSize.Height) / 2;
                e.Graphics.DrawString(symbol, font, brush, x, y);
            }
        }
    }
}
