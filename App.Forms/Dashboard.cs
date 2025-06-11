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
    public partial class Dashboard : Form
    {
        private Panel currentPanel;
        private DaftarPengaduan daftarPengaduanForm;
        private MenuPengaduan menuPengaduanForm;

        public Dashboard()
        {
            InitializeComponent();
            currentPanel = panelBase;

            // Add click event handlers for the buttons
            daftarPengaduanBtn.Click += daftarPengaduanBtn_Click;
            dashboardBtn.Click += dashboardBtn_Click;
            menuPengaduanBtn.Click += menuPengaduanBtn_Click;
            daftarPengaduanForm = new DaftarPengaduan();
            menuPengaduanForm = new MenuPengaduan();
        }

        private void daftarPengaduanBtn_Click(object sender, EventArgs e)
        {
            // Switch to DaftarPengaduan panel
            panelBase.Controls.Clear();
            panelBase.Controls.Add(daftarPengaduanForm.GetPanel());
            daftarPengaduanForm.GetPanel().Dock = DockStyle.Fill;

            // Update button styles
            daftarPengaduanBtn.Font = new Font("Segoe UI", 10.2f, FontStyle.Bold);
            dashboardBtn.Font = new Font("Segoe UI", 10.2f, FontStyle.Regular);
            menuPengaduanBtn.Font = new Font("Segoe UI", 10.2f, FontStyle.Regular);
        }

        private void dashboardBtn_Click(object sender, EventArgs e)
        {
            // Switch back to Dashboard panel
            panelBase.Controls.Clear();
            RestoreDashboardPanel();

            // Update button styles
            dashboardBtn.Font = new Font("Segoe UI", 10.2f, FontStyle.Bold);
            daftarPengaduanBtn.Font = new Font("Segoe UI", 10.2f, FontStyle.Regular);
            menuPengaduanBtn.Font = new Font("Segoe UI", 10.2f, FontStyle.Regular);
        }

        private void RestoreDashboardPanel()
        {
            panelBase.Controls.Add(panelCounter);
            panelBase.Controls.Add(panelContent);
            panelCounter.Dock = DockStyle.Top;
            panelContent.Dock = DockStyle.Bottom;
        }

        private void menuPengaduanBtn_Click(object sender, EventArgs e)
        {
            // Switch to MenuPengaduan panel
            panelBase.Controls.Clear();
            panelBase.Controls.Add(menuPengaduanForm.GetPanel());
            menuPengaduanForm.GetPanel().Dock = DockStyle.Fill;

            // Update button styles
            daftarPengaduanBtn.Font = new Font("Segoe UI", 10.2f, FontStyle.Regular);
            dashboardBtn.Font = new Font("Segoe UI", 10.2f, FontStyle.Regular);
            menuPengaduanBtn.Font = new Font("Segoe UI", 10.2f, FontStyle.Bold);
        }
    }
}
