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
            if (this.chartPengaduan == null)
            {
                MessageBox.Show("Chart control is not initialized. Please fix it in the Dashboard designer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                Dictionary<StatusPengaduan, int> dataStatus = await _pengaduanKebersihanService.HitungKomposisiStatusAsync();

                Dictionary<string, int> dataStatusStringKeys = dataStatus.ToDictionary(
                    kvp => kvp.Key.ToString(),
                    kvp => kvp.Value
                );

                var chart = this.chartPengaduan;
                var seriesName = "Pengaduan";

                chart.Series[seriesName].Points.Clear();
                chart.Titles.Clear();

                chart.Titles.Add("Komposisi Status Pengaduan");
                chart.ChartAreas[0].AxisX.Title = "Status";
                chart.ChartAreas[0].AxisY.Title = "Jumlah";
                chart.ChartAreas[0].AxisX.Interval = 1;
                chart.Series[seriesName].IsValueShownAsLabel = true;
                chart.Series[seriesName].Font = new Font("Product Sans", 8);
                chart.Legends[0].Enabled = false;

                foreach (KeyValuePair<string, int> item in dataStatusStringKeys)
                {
                    chart.Series[seriesName].Points.AddXY(item.Key, item.Value);
                }
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
