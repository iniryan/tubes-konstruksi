using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using App.Core.Models;
using App.Core.Services;

namespace App.Forms
{
    public partial class Dashboard : Form
    {
        private DaftarPengaduan daftarPengaduanForm;
        private MenuPengaduan menuPengaduanForm;
        private LaporanTamu lapTamu;
        private Pengguna penggunaForm;
        private readonly User _currentUser;
        private readonly PengaduanKebersihanService _pengaduanKebersihanService;
        // private readonly PengaduanKeamananService _pengaduanKeamananService;
        private readonly PengaduanFasilitasService _pengaduanFasilitasService;
        private readonly GuestRepository _tamuService;

        public Dashboard(User user)
        {
            InitializeComponent();
            _currentUser = user;

            _pengaduanKebersihanService = new PengaduanKebersihanService();
            // _pengaduanKeamananService = new PengaduanKeamananService();
            _pengaduanFasilitasService = new PengaduanFasilitasService();
            _tamuService = new GuestRepository();

            daftarPengaduanBtn.Click += daftarPengaduanBtn_Click;
            dashboardBtn.Click += dashboardBtn_Click;
            menuPengaduanBtn.Click += menuPengaduanBtn_Click;
            menuPenggunaBtn.Click += menuPenggunaBtn_Click;
            logOutBtn.Click += logOutBtn_Click;

            daftarPengaduanForm = new DaftarPengaduan(_currentUser);
            menuPengaduanForm = new MenuPengaduan(_currentUser);
            lapTamu = new LaporanTamu(_currentUser);
            penggunaForm = new Pengguna(_currentUser);

            labelNama.Text = $"Selamat datang, {_currentUser.Name}";

            ApplyDataGridViewStyling(dataPengaduanTerbaruGridView);

            LoadDashboardDataAsync();
        }
        private async void LoadDashboardDataAsync()
        {
            await Task.WhenAll(
                LoadPengaduanChartAsync(),
                LoadAllCountersAsync(),
                LoadRecentPengaduanAsync()
            );
        }

        private async Task LoadAllCountersAsync()
        {
            try
            {
                var tasks = new[]
                {
                    _pengaduanKebersihanService.HitungTotalPengaduanAsync(),
                    _pengaduanFasilitasService.HitungTotalPengaduanAsync(),
                    // _pengaduanKeamananService.HitungTotalPengaduanAsync(),
                    _tamuService.HitungTotalTamuAsync()
                };

                var results = await Task.WhenAll(tasks);

                this.Invoke((MethodInvoker)delegate
                {
                    counterKebersihan.Text = results[0].ToString("N0");
                    counterFasilitas.Text = results[1].ToString("N0");
                    counterTamu.Text = results[2].ToString("N0");
                    // counterKeamanan.Text = results[2].ToString("N0");
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat data counter: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadPengaduanChartAsync()
        {
            if (chartPengaduan == null)
            {
                MessageBox.Show("Chart control is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                Dictionary<StatusPengaduan, int> dataStatus = await _pengaduanKebersihanService.HitungKomposisiStatusAsync();

                var series = chartPengaduan.Series["Pengaduan"];
                series.Points.Clear();
                chartPengaduan.Titles.Clear();

                var title = new System.Windows.Forms.DataVisualization.Charting.Title();
                title.Font = new Font("Product Sans", 12, FontStyle.Bold);
                title.Text = "Status Pengaduan";
                chartPengaduan.Titles.Add(title);

                var chartArea = chartPengaduan.ChartAreas[0];
                chartArea.AxisX.Title = "Status";
                chartArea.AxisY.Title = "Jumlah";
                chartArea.AxisX.TitleFont = new Font("Product Sans", 10);
                chartArea.AxisY.TitleFont = new Font("Product Sans", 10);
                chartArea.AxisX.LabelStyle.Font = new Font("Product Sans", 9);
                chartArea.AxisY.LabelStyle.Font = new Font("Product Sans", 9);
                chartArea.AxisX.Interval = 1;

                series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                series.Font = new Font("Product Sans", 9);
                series.IsValueShownAsLabel = true;
                series.LabelFormat = "#,##0";

                series.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.BrightPastel;

                foreach (var item in dataStatus)
                {
                    int pointIndex = series.Points.AddXY(item.Key.ToString(), item.Value);
                    var dataPoint = series.Points[pointIndex];
                    dataPoint.Label = item.Value.ToString("N0");
                    dataPoint.LabelToolTip = $"{item.Key}: {item.Value:N0}";
                }

                chartPengaduan.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat data grafik: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadRecentPengaduanAsync()
        {
            try
            {
                // Get all pengaduan
                var kebersihanTask = _pengaduanKebersihanService.AmbilSemuaPengaduanAsync();
                var fasilitasTask = _pengaduanFasilitasService.AmbilSemuaPengaduanAsync();
                // var keamananTask = _pengaduanKeamananService.AmbilSemuaPengaduanAsync();
                var tamuTask = _tamuService.AmbilSemuaTamuAsync();

                await Task.WhenAll(kebersihanTask, fasilitasTask, /*keamananTask,*/ tamuTask);

                // Gabungkan semua pengaduan ke dalam satu list
                var allComplaints = new List<object>();

                // pengaduan Kebersihan
                allComplaints.AddRange(kebersihanTask.Result.Select(p => new
                {
                    Id = p.Id,
                    Jenis = "Kebersihan",
                    Pelapor = p.Detail.NamaPelapor,
                    Status = p.Status,
                    Kategori = p.Detail.Kategori,
                    TanggalDibuat = p.TanggalDibuat
                }));

                // pengaduan Fasilitas
                allComplaints.AddRange(fasilitasTask.Result.Select(p => new
                {
                    Id = p.Id,
                    Jenis = "Fasilitas",
                    Pelapor = p.Detail.NamaPelapor,
                    Status = p.Status,
                    Kategori = p.Detail.JenisFasilitas,
                    TanggalDibuat = p.TanggalDibuat
                }));

                // pengaduan Keamanan
                // allComplaints.AddRange(keamananTask.Result.Select(p => new
                // {
                //     Id = p.Id,
                //     Jenis = "Keamanan",
                //     Pelapor = p.Detail.NamaPelapor,
                //     Status = p.Status,
                //     Kategori = p.Detail.Kategori,
                //     TanggalDibuat = p.TanggalDibuat
                // }));

                // pengaduan Tamu
                allComplaints.AddRange(tamuTask.Result.Select(t => new
                {
                    Id = t.Id,
                    Jenis = "Tamu",
                    Pelapor = t.Detail.NamaPelapor,
                    Status = t.Status,
                    Kategori = "Kunjungan",
                    TanggalDibuat = t.TanggalDibuat
                }));

                // 5 pengaduan terbaru
                var recentComplaints = allComplaints
                    .OrderByDescending(c => ((dynamic)c).TanggalDibuat)
                    .Take(5)
                    .ToList();

                this.Invoke((MethodInvoker)delegate
                {
                    dataPengaduanTerbaruGridView.DataSource = recentComplaints;

                    dataPengaduanTerbaruGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataPengaduanTerbaruGridView.Columns["Id"].Visible = false;

                    if (dataPengaduanTerbaruGridView.Columns["TanggalDibuat"] != null)
                    {
                        dataPengaduanTerbaruGridView.Columns["TanggalDibuat"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    }

                    foreach (DataGridViewColumn col in dataPengaduanTerbaruGridView.Columns)
                    {
                        col.HeaderText = col.Name switch
                        {
                            "Jenis" => "Jenis Pengaduan",
                            "Pelapor" => "Nama Pelapor",
                            "Status" => "Status",
                            "Kategori" => "Kategori",
                            "TanggalDibuat" => "Tanggal",
                            _ => col.HeaderText
                        };
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat data pengaduan terbaru: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void daftarPengaduanBtn_Click(object sender, EventArgs e)
        {
            panelBase.Controls.Clear();
            panelBase.Controls.Add(daftarPengaduanForm.GetPanel());
            daftarPengaduanForm.GetPanel().Dock = DockStyle.Fill;

            daftarPengaduanBtn.Font = new Font("Product Sans", 10.2f, FontStyle.Bold);
            dashboardBtn.Font = new Font("Product Sans", 10.2f, FontStyle.Regular);
            menuPengaduanBtn.Font = new Font("Product Sans", 10.2f, FontStyle.Regular);
            buttonTamu.Font = new Font("Product Sans", 10.2f, FontStyle.Regular);
            menuPenggunaBtn.Font = new Font("Product Sans", 10.2f, FontStyle.Regular);
        }
        private void dashboardBtn_Click(object sender, EventArgs e)
        {
            panelBase.Controls.Clear();
            RestoreDashboardPanel();

            dashboardBtn.Font = new Font("Product Sans", 10.2f, FontStyle.Bold);
            daftarPengaduanBtn.Font = new Font("Product Sans", 10.2f, FontStyle.Regular);
            menuPengaduanBtn.Font = new Font("Product Sans", 10.2f, FontStyle.Regular);
            buttonTamu.Font = new Font("Product Sans", 10.2f, FontStyle.Regular);
            menuPenggunaBtn.Font = new Font("Product Sans", 10.2f, FontStyle.Regular);
        }

        private void RestoreDashboardPanel()
        {
            panelBase.Controls.Add(panelCounter);
            panelBase.Controls.Add(panelContent);
        }
        private void menuPengaduanBtn_Click(object sender, EventArgs e)
        {
            panelBase.Controls.Clear();
            panelBase.Controls.Add(menuPengaduanForm.GetPanel());
            menuPengaduanForm.GetPanel().Dock = DockStyle.Fill;

            menuPengaduanBtn.Font = new Font("Product Sans", 10.2f, FontStyle.Bold);
            daftarPengaduanBtn.Font = new Font("Product Sans", 10.2f, FontStyle.Regular);
            dashboardBtn.Font = new Font("Product Sans", 10.2f, FontStyle.Regular);
            buttonTamu.Font = new Font("Product Sans", 10.2f, FontStyle.Regular);
            menuPenggunaBtn.Font = new Font("Product Sans", 10.2f, FontStyle.Regular);
        }

        private void logOutBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonTamu_Click(object sender, EventArgs e)
        {
            panelBase.Controls.Clear();
            panelBase.Controls.Add(lapTamu.GetPanel());
            lapTamu.GetPanel().Dock = DockStyle.Fill;

            buttonTamu.Font = new Font("Product Sans", 10.2f, FontStyle.Bold);
            menuPengaduanBtn.Font = new Font("Product Sans", 10.2f, FontStyle.Regular);
            daftarPengaduanBtn.Font = new Font("Product Sans", 10.2f, FontStyle.Regular);
            dashboardBtn.Font = new Font("Product Sans", 10.2f, FontStyle.Regular);
            menuPenggunaBtn.Font = new Font("Product Sans", 10.2f, FontStyle.Regular);
        }

        private void menuPenggunaBtn_Click(object sender, EventArgs e)
        {
            panelBase.Controls.Clear();
            panelBase.Controls.Add(penggunaForm.GetPanel());
            penggunaForm.GetPanel().Dock = DockStyle.Fill;

            // Refresh data setiap kali menu pengguna dibuka
            penggunaForm.RefreshData();

            menuPenggunaBtn.Font = new Font("Product Sans", 10.2f, FontStyle.Bold);
            menuPengaduanBtn.Font = new Font("Product Sans", 10.2f, FontStyle.Regular);
            daftarPengaduanBtn.Font = new Font("Product Sans", 10.2f, FontStyle.Regular);
            dashboardBtn.Font = new Font("Product Sans", 10.2f, FontStyle.Regular);
            buttonTamu.Font = new Font("Product Sans", 10.2f, FontStyle.Regular);
        }

        private void ApplyDataGridViewStyling(DataGridView dataGridView)
        {
            dataGridView.AutoGenerateColumns = true;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.MultiSelect = false;
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
    }
}
