using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using App.Core.Models;
using App.Core.Services;

namespace App.Forms
{
    public partial class DaftarPengaduan : Form
    {
        private readonly User _currentUser;
        private readonly PengaduanKebersihanService _kebersihanService;
        private readonly PengaduanFasilitasService _fasilitasService;
        private readonly GuestRepository _tamuService;
        private readonly PengaduanKeamananService _keamananService;

        private string _selectedPengaduanId = "";
        private string _selectedPengaduanType = "";

        public DaftarPengaduan(User user)
        {
            InitializeComponent();
            _currentUser = user;

            _kebersihanService = new PengaduanKebersihanService();
            _fasilitasService = new PengaduanFasilitasService();
            _tamuService = new GuestRepository();
            _keamananService = new PengaduanKeamananService();

            InitializeDataGridView();
            LoadAllPengaduan();
            LoadCounters();

            buttonDitolak.Click += ButtonDitolak_Click;
            buttonDiproses.Click += ButtonDiproses_Click;
            buttonSelesai.Click += ButtonSelesai_Click;

            daftarSemuaPengaduan.SelectionChanged += DaftarSemuaPengaduan_SelectionChanged;
        }

        private void InitializeDataGridView()
        {
            daftarSemuaPengaduan.AutoGenerateColumns = false;
            daftarSemuaPengaduan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            daftarSemuaPengaduan.MultiSelect = false;

            ApplyDataGridViewStyling(daftarSemuaPengaduan);

            daftarSemuaPengaduan.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "ID",
                DataPropertyName = "Id",
                Width = 100,
                Visible = false
            });

            daftarSemuaPengaduan.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Jenis",
                HeaderText = "Jenis",
                DataPropertyName = "Jenis",
                Width = 100
            });

            daftarSemuaPengaduan.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NamaPelapor",
                HeaderText = "Nama Pelapor",
                DataPropertyName = "NamaPelapor",
                Width = 150
            });

            daftarSemuaPengaduan.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Lokasi",
                HeaderText = "Lokasi",
                DataPropertyName = "Lokasi",
                Width = 200
            });

            daftarSemuaPengaduan.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Deskripsi",
                HeaderText = "Deskripsi",
                DataPropertyName = "Deskripsi",
                Width = 250
            });

            daftarSemuaPengaduan.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Status",
                HeaderText = "Status",
                DataPropertyName = "Status",
                Width = 100
            });

            daftarSemuaPengaduan.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TanggalDibuat",
                HeaderText = "Tanggal Dibuat",
                DataPropertyName = "TanggalDibuat",
                Width = 150
            });

            daftarSemuaPengaduan.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "JenisOriginal",
                HeaderText = "Jenis Original",
                DataPropertyName = "JenisOriginal",
                Visible = false
            });
        }

        private void ApplyDataGridViewStyling(DataGridView dataGridView)
        {
            dataGridView.ReadOnly = true;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;

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

        private async void LoadAllPengaduan()
        {
            try
            {
                var allPengaduan = new List<PengaduanDisplay>();

                // Load Kebersihan
                var kebersihanList = await _kebersihanService.AmbilSemuaPengaduanAsync();
                foreach (var item in kebersihanList)
                {
                    allPengaduan.Add(new PengaduanDisplay
                    {
                        Id = item.Id,
                        Jenis = "Kebersihan",
                        NamaPelapor = item.Detail.NamaPelapor,
                        Lokasi = item.Detail.Lokasi,
                        Deskripsi = item.Detail.Deskripsi,
                        Status = GetStatusText(item.Status),
                        TanggalDibuat = item.TanggalDibuat.ToString("dd/MM/yyyy HH:mm"),
                        JenisOriginal = "Kebersihan"
                    });
                }

                // Load Fasilitas
                var fasilitasList = await _fasilitasService.AmbilSemuaPengaduanAsync();
                foreach (var item in fasilitasList)
                {
                    allPengaduan.Add(new PengaduanDisplay
                    {
                        Id = item.Id,
                        Jenis = "Fasilitas",
                        NamaPelapor = item.Detail.NamaPelapor,
                        Lokasi = item.Detail.Lokasi,
                        Deskripsi = item.Detail.Deskripsi,
                        Status = GetStatusText(item.Status),
                        TanggalDibuat = item.TanggalDibuat.ToString("dd/MM/yyyy HH:mm"),
                        JenisOriginal = "Fasilitas"
                    });
                }

                // Load Tamu
                var tamuList = await _tamuService.AmbilSemuaTamuAsync();
                foreach (var item in tamuList)
                {
                    allPengaduan.Add(new PengaduanDisplay
                    {
                        Id = item.Id,
                        Jenis = "Tamu",
                        NamaPelapor = item.Detail.NamaPelapor,
                        Lokasi = item.Detail.Lokasi,
                        Deskripsi = item.Detail.Deskripsi,
                        Status = GetStatusText(item.Status),
                        TanggalDibuat = item.TanggalDibuat.ToString("dd/MM/yyyy HH:mm"),
                        JenisOriginal = "Tamu"
                    });
                }

                // Load Keamanan
                var keamananList = await _keamananService.AmbilSemuaPengaduanAsync();
                foreach (var item in keamananList)
                {
                    allPengaduan.Add(new PengaduanDisplay
                    {
                        Id = item.Id,
                        Jenis = "Keamanan",
                        NamaPelapor = item.Detail.NamaPelapor,
                        Lokasi = item.Detail.Lokasi,
                        Deskripsi = item.Detail.Deskripsi,
                        Status = GetStatusText(item.Status),
                        TanggalDibuat = item.TanggalDibuat.ToString("dd/MM/yyyy HH:mm"),
                        JenisOriginal = "Keamanan"
                    });
                }

                // Sort newest first by TanggalDibuat
                allPengaduan = allPengaduan.OrderByDescending(p => p.TanggalDibuat).ToList();

                daftarSemuaPengaduan.DataSource = allPengaduan;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void LoadCounters()
        {
            try
            {
                int totalDitolak = 0, totalDiproses = 0, totalSelesai = 0;

                // Count from Kebersihan
                var kebersihanStats = await _kebersihanService.HitungKomposisiStatusAsync();
                totalDitolak += kebersihanStats.GetValueOrDefault(StatusPengaduan.Ditolak, 0);
                totalDiproses += kebersihanStats.GetValueOrDefault(StatusPengaduan.Diproses, 0);
                totalSelesai += kebersihanStats.GetValueOrDefault(StatusPengaduan.Selesai, 0);

                // Count from Fasilitas
                var fasilitasStats = await _fasilitasService.HitungKomposisiStatusAsync();
                totalDitolak += fasilitasStats.GetValueOrDefault(StatusPengaduan.Ditolak, 0);
                totalDiproses += fasilitasStats.GetValueOrDefault(StatusPengaduan.Diproses, 0);
                totalSelesai += fasilitasStats.GetValueOrDefault(StatusPengaduan.Selesai, 0);

                // Count from Tamu
                var tamuStats = await _tamuService.HitungKomposisiStatusAsync();
                totalDitolak += tamuStats.GetValueOrDefault(StatusPengaduan.Ditolak, 0);
                totalDiproses += tamuStats.GetValueOrDefault(StatusPengaduan.Diproses, 0);
                totalSelesai += tamuStats.GetValueOrDefault(StatusPengaduan.Selesai, 0);

                // Count from Keamanan
                var keamananStats = await _keamananService.HitungKomposisiStatusAsync();
                totalDitolak += keamananStats.GetValueOrDefault(StatusPengaduan.Ditolak, 0);
                totalDiproses += keamananStats.GetValueOrDefault(StatusPengaduan.Diproses, 0);
                totalSelesai += keamananStats.GetValueOrDefault(StatusPengaduan.Selesai, 0);

                // Update UI
                counterDitolak.Text = totalDitolak.ToString();
                counterDiproses.Text = totalDiproses.ToString();
                counterSelesai.Text = totalSelesai.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading counters: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetStatusText(StatusPengaduan status)
        {
            return status switch
            {
                StatusPengaduan.Dibuat => "Dibuat",
                StatusPengaduan.Diproses => "Diproses",
                StatusPengaduan.Selesai => "Selesai",
                StatusPengaduan.Ditolak => "Ditolak",
                _ => "Unknown"
            };
        }

        private void DaftarSemuaPengaduan_SelectionChanged(object sender, EventArgs e)
        {
            if (daftarSemuaPengaduan.CurrentRow != null)
            {
                var selectedRow = daftarSemuaPengaduan.CurrentRow;
                _selectedPengaduanId = selectedRow.Cells["Id"].Value?.ToString() ?? "";
                _selectedPengaduanType = selectedRow.Cells["JenisOriginal"].Value?.ToString() ?? "";
            }
        }

        private async void ButtonDitolak_Click(object sender, EventArgs e)
        {
            await UbahStatusPengaduan(StatusPengaduan.Ditolak);
        }

        private async void ButtonDiproses_Click(object sender, EventArgs e)
        {
            await UbahStatusPengaduan(StatusPengaduan.Diproses);
        }

        private async void ButtonSelesai_Click(object sender, EventArgs e)
        {
            await UbahStatusPengaduan(StatusPengaduan.Selesai);
        }

        private async Task UbahStatusPengaduan(StatusPengaduan statusBaru)
        {
            if (string.IsNullOrEmpty(_selectedPengaduanId) || string.IsNullOrEmpty(_selectedPengaduanType))
            {
                MessageBox.Show("Silakan pilih pengaduan terlebih dahulu.", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                switch (_selectedPengaduanType)
                {
                    case "Kebersihan":
                        await _kebersihanService.UbahStatusAsync(_selectedPengaduanId, statusBaru);
                        break;
                    case "Fasilitas":
                        await _fasilitasService.UbahStatusAsync(_selectedPengaduanId, statusBaru);
                        break;
                    case "Tamu":
                        await _tamuService.UbahStatusAsync(_selectedPengaduanId, statusBaru);
                        break;
                    case "Keamanan":
                        await _keamananService.UbahStatusAsync(_selectedPengaduanId, statusBaru);
                        break;
                    default:
                        MessageBox.Show("Jenis pengaduan tidak dikenali.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }

                MessageBox.Show($"Status pengaduan berhasil diubah menjadi {GetStatusText(statusBaru)}.",
                    "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresh data
                LoadAllPengaduan();
                LoadCounters();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show($"Perubahan status tidak valid: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error mengubah status: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Panel GetPanel()
        {
            return panelDaftarPengaduan;
        }

        private void labelTextDaftarPengaduan_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }

    public class PengaduanDisplay
    {
        public string Id { get; set; } = "";
        public string Jenis { get; set; } = "";
        public string NamaPelapor { get; set; } = "";
        public string Lokasi { get; set; } = "";
        public string Deskripsi { get; set; } = "";
        public string Status { get; set; } = "";
        public string TanggalDibuat { get; set; } = "";
        public string JenisOriginal { get; set; } = "";
    }
}
