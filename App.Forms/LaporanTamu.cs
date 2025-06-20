using App.Core.Models;
using App.Core.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.Forms
{
    public partial class LaporanTamu : Form
    {
        private readonly User _currentUser;
        private Control currentControl;
        private readonly GuestRepository _guestRepository;
        private string? _selectedTamuId = null;

        private bool _isClearing = false;

        public Panel GetPanel()
        {
            return panelContentLaporanTamu;
        }

        public LaporanTamu(User user)
        {
            InitializeComponent();
            _currentUser = user;
            this.Dock = DockStyle.Fill;

            _guestRepository = new GuestRepository();

            this.Load += LaporanTamu_Load;
            buttonSave.Click += buttonSave_Click;
            dataGridViewDataLaporanTamu.SelectionChanged += dataGridViewDataLaporanTamu_SelectionChanged;
            dataGridViewDataLaporanTamu.RowPostPaint += dataGridViewDataLaporanTamu_RowPostPaint;
            buttonClear.Click += buttonClear_Click;
        }

        private async void LaporanTamu_Load(object sender, EventArgs e)
        {
            SetupDataGridViewStyles();
            await LoadDataAsync();
        }
        private void SetupDataGridViewStyles()
        {
            dataGridViewDataLaporanTamu.RowHeadersVisible = true;
            dataGridViewDataLaporanTamu.TopLeftHeaderCell.Value = "Pilih Data";
            dataGridViewDataLaporanTamu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewDataLaporanTamu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dataGridViewDataLaporanTamu.AllowUserToAddRows = false;
            dataGridViewDataLaporanTamu.AllowUserToDeleteRows = false;
            dataGridViewDataLaporanTamu.ReadOnly = true;

            ApplyDataGridViewStyling(dataGridViewDataLaporanTamu);

            var headerStyle = dataGridViewDataLaporanTamu.ColumnHeadersDefaultCellStyle;
            dataGridViewDataLaporanTamu.TopLeftHeaderCell.Style.ApplyStyle(headerStyle);
        }

        private void dataGridViewDataLaporanTamu_RowPostPaint(object? sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (dataGridViewDataLaporanTamu.Rows[e.RowIndex].Selected) return;

            string symbol = "▶";
            using (Font font = new Font("Product Sans", 10, FontStyle.Bold))
            using (SolidBrush brush = new SolidBrush(Color.Gray))
            {
                SizeF stringSize = e.Graphics.MeasureString(symbol, font);
                float x = e.RowBounds.Left + (dataGridViewDataLaporanTamu.RowHeadersWidth - stringSize.Width) / 2;
                float y = e.RowBounds.Top + (e.RowBounds.Height - stringSize.Height) / 2;
                e.Graphics.DrawString(symbol, font, brush, x, y);
            }
        }
        private async Task LoadDataAsync()
        {
            var data = await _guestRepository.AmbilSemuaTamuAsync();

            var displayData = data.Select(p => new
            {
                p.Id,
                Nama = p.Detail.NamaPelapor,
                NomorIdentitas = p.Detail.NomorIdentitas,
                Tujuan = p.Detail.Tujuan,
                PegawaiTujuan = p.Detail.PegawaiTujuan,
                WaktuDatang = p.Detail.WaktuDatang,
                WaktuKeluar = p.Detail.WaktuKeluar,
                Status = p.Status.ToString()
            }).ToList();

            dataGridViewDataLaporanTamu.DataSource = displayData;

            ApplyDataGridViewStyling(dataGridViewDataLaporanTamu);

            if (dataGridViewDataLaporanTamu.Columns.Contains("Id"))
                dataGridViewDataLaporanTamu.Columns["Id"].Visible = false;
        }

        private void dataGridViewDataLaporanTamu_SelectionChanged(object sender, EventArgs e)
        {
            if (_isClearing) return;

            if (dataGridViewDataLaporanTamu.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewDataLaporanTamu.SelectedRows[0];
                _selectedTamuId = selectedRow.Cells["Id"].Value?.ToString();

                if (_selectedTamuId != null)
                {
                    textNama.Text = selectedRow.Cells["Nama"].Value?.ToString();
                    textNomorIdentitas.Text = selectedRow.Cells["NomorIdentitas"].Value?.ToString();
                    textTujuan.Text = selectedRow.Cells["Tujuan"].Value?.ToString();
                    textPegawai.Text = selectedRow.Cells["PegawaiTujuan"].Value?.ToString();

                    // Set date picker untuk waktu keluar
                    if (selectedRow.Cells["WaktuKeluar"].Value is DateTime waktuKeluar)
                        dateTimePickerWaktuKeluar.Value = waktuKeluar;
                    else if (DateTime.TryParse(selectedRow.Cells["WaktuKeluar"].Value?.ToString(), out var dt))
                        dateTimePickerWaktuKeluar.Value = dt;
                    else
                        dateTimePickerWaktuKeluar.Value = DateTime.Now;

                    dateTimePickerWaktuKeluar.Checked = selectedRow.Cells["WaktuKeluar"].Value != null && !string.IsNullOrEmpty(selectedRow.Cells["WaktuKeluar"].Value.ToString());

                    labelTextFormTambahTamu.Text = "Ubah Data Tamu";
                    buttonSave.Text = "Ubah Data";
                }
            }
            else
            {
                ClearForm();
            }
        }

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            string nama = textNama.Text.Trim();
            string nomorIdentitas = textNomorIdentitas.Text.Trim();
            string tujuan = textTujuan.Text.Trim();
            string pegawaiTujuan = textPegawai.Text.Trim();
            string lokasi = "Lobi Utama";
            string deskripsi = $"Kunjungan ke {pegawaiTujuan} untuk {tujuan}";
            DateTime? waktuKeluar = dateTimePickerWaktuKeluar.Checked ? dateTimePickerWaktuKeluar.Value : (DateTime?)null;

            if (string.IsNullOrWhiteSpace(nama) ||
                string.IsNullOrWhiteSpace(nomorIdentitas) ||
                string.IsNullOrWhiteSpace(tujuan) ||
                string.IsNullOrWhiteSpace(pegawaiTujuan))
            {
                MessageBox.Show("Semua kolom wajib diisi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (_selectedTamuId == null) // Tambah
                {
                    await _guestRepository.TambahTamuAsync(_currentUser.Id, nama, lokasi, deskripsi, nomorIdentitas, tujuan, pegawaiTujuan, waktuKeluar);
                    MessageBox.Show("Tamu berhasil ditambahkan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // Edit
                {
                    await _guestRepository.UbahDetailTamuAsync(_selectedTamuId, nama, lokasi, deskripsi, nomorIdentitas, tujuan, pegawaiTujuan, waktuKeluar);
                    MessageBox.Show("Tamu berhasil diubah!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                await LoadDataAsync();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            _selectedTamuId = null;
            textNama.Clear();
            textNomorIdentitas.Clear();
            textTujuan.Clear();
            textPegawai.Clear();
            dateTimePickerWaktuKeluar.Value = DateTime.Now;
            dateTimePickerWaktuKeluar.Checked = false;
            labelTextFormTambahTamu.Text = "Form Tambah Tamu";
            buttonSave.Text = "Simpan Data";
            dataGridViewDataLaporanTamu.ClearSelection();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private async void buttonDelete_Click(object sender, EventArgs e)
        {
            if (_selectedTamuId == null)
            {
                MessageBox.Show("Pilih data tamu yang ingin dihapus.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show("Yakin ingin menghapus data tamu ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    await _guestRepository.HapusTamuAsync(_selectedTamuId);
                    MessageBox.Show("Tamu berhasil dihapus.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    await LoadDataAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal menghapus tamu: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void dataGridViewDataLaporanTamu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridViewDataLaporanTamu.Rows[e.RowIndex];
                textNama.Text = row.Cells["Nama"].Value?.ToString();
                textNomorIdentitas.Text = row.Cells["NomorIdentitas"].Value?.ToString();
                textTujuan.Text = row.Cells["Tujuan"].Value?.ToString();
                textPegawai.Text = row.Cells["PegawaiTujuan"].Value?.ToString();

                if (row.Cells["WaktuKeluar"].Value is DateTime waktuKeluar)
                {
                    dateTimePickerWaktuKeluar.Value = waktuKeluar;
                }
                else if (DateTime.TryParse(row.Cells["WaktuKeluar"].Value?.ToString(), out var dt))
                {
                    dateTimePickerWaktuKeluar.Value = dt;
                }
                else
                {
                    dateTimePickerWaktuKeluar.Value = DateTime.Now;
                }
            }
        }
        private void labelTextLokasi_Click(object sender, EventArgs e)
        {
            //
        }
        private void label1_Click(object sender, EventArgs e)
        {
            //
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //
        }
        private void ApplyDataGridViewStyling(DataGridView dataGridView)
        {
            dataGridView.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);

            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 152, 219);
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Product Sans", 10, FontStyle.Bold);
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.EnableHeadersVisualStyles = false;

            dataGridView.DefaultCellStyle.Font = new Font("Product Sans", 9);
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(41, 128, 185);
            dataGridView.DefaultCellStyle.SelectionForeColor = Color.White;

            dataGridView.GridColor = Color.FromArgb(200, 200, 200);
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView.BackgroundColor = SystemColors.Control;
        }

    }
}
