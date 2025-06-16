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
        private readonly User _currentUser;
        private readonly PengaduanKebersihanService _pengaduanKebersihanService;
        // private readonly PengaduanFasilitasService _pengaduanFasilitasService;

        public Dashboard(User user)
        {
            InitializeComponent();
            _currentUser = user;

            _pengaduanKebersihanService = new PengaduanKebersihanService();
            // _pengaduanFasilitasService = new PengaduanFasilitasService();

            daftarPengaduanBtn.Click += daftarPengaduanBtn_Click;
            dashboardBtn.Click += dashboardBtn_Click;
            menuPengaduanBtn.Click += menuPengaduanBtn_Click;
            logOutBtn.Click += logOutBtn_Click;

            daftarPengaduanForm = new DaftarPengaduan(_currentUser);
            menuPengaduanForm = new MenuPengaduan(_currentUser);
            lapTamu = new LaporanTamu(_currentUser);

            LoadDashboardDataAsync();
        }
        private async void LoadDashboardDataAsync()
        {
            await Task.WhenAll(
                LoadPengaduanChartAsync(),
                LoadCounterKebersihanAsync()
            );
        }

        private async Task LoadCounterKebersihanAsync()
        {
            try
            {
                int totalPengaduan = await _pengaduanKebersihanService.HitungTotalPengaduanAsync();

                counterKebersihan.Invoke((MethodInvoker)delegate
                {
                    counterKebersihan.Text = totalPengaduan.ToString("N0");
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat data pengaduan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                // Configure chart appearance
                var title = new System.Windows.Forms.DataVisualization.Charting.Title();
                title.Font = new Font("Product Sans", 12, FontStyle.Bold);
                title.Text = "Status Pengaduan";
                chartPengaduan.Titles.Add(title);

                // Configure chart areas
                var chartArea = chartPengaduan.ChartAreas[0];
                chartArea.AxisX.Title = "Status";
                chartArea.AxisY.Title = "Jumlah";
                chartArea.AxisX.TitleFont = new Font("Product Sans", 10);
                chartArea.AxisY.TitleFont = new Font("Product Sans", 10);
                chartArea.AxisX.LabelStyle.Font = new Font("Product Sans", 9);
                chartArea.AxisY.LabelStyle.Font = new Font("Product Sans", 9);
                chartArea.AxisX.Interval = 1;

                // Configure series
                series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                series.Font = new Font("Product Sans", 9);
                series.IsValueShownAsLabel = true;
                series.LabelFormat = "#,##0";

                // Set color palette
                series.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.BrightPastel;

                // Add data points
                foreach (var item in dataStatus)
                {
                    int pointIndex = series.Points.AddXY(item.Key.ToString(), item.Value);
                    var dataPoint = series.Points[pointIndex];
                    dataPoint.Label = item.Value.ToString("N0");
                    dataPoint.LabelToolTip = $"{item.Key}: {item.Value:N0}";
                }

                // Adjust chart position and size if needed
                chartPengaduan.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat data grafik: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        }

        private void dashboardBtn_Click(object sender, EventArgs e)
        {
            panelBase.Controls.Clear();
            RestoreDashboardPanel();

            dashboardBtn.Font = new Font("Product Sans", 10.2f, FontStyle.Bold);
            daftarPengaduanBtn.Font = new Font("Product Sans", 10.2f, FontStyle.Regular);
            menuPengaduanBtn.Font = new Font("Product Sans", 10.2f, FontStyle.Regular);
            buttonTamu.Font = new Font("Product Sans", 10.2f, FontStyle.Regular);
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
        }

        private void logOutBtn_Click(object sender, EventArgs e)
        {
            this.Close();
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
        }
    }
}
