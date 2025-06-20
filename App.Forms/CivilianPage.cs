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
using App.Forms;

namespace App.Forms
{
    public partial class CivilianPage : Form
    {
        private readonly User _currentUser;
        private Control currentControl;
        private PengaduanKebersihan pengaduanKebersihan;
        private PengaduanFasilitasForm pengaduanFasilitas;
        private PengaduanKeamananForm pengaduanKeamanan;

        public Panel GetPanel()
        {
            return panelBase;
        }

        public CivilianPage(User user)
        {
            InitializeComponent();
            _currentUser = user;
            InitializePanels();
            SetupComboBox();
            ShowSelectedPanel();

            labelNama.Text = $"Selamat datang, {_currentUser.Name}";
        }
        private void InitializePanels()
        {
            pengaduanKebersihan = new PengaduanKebersihan(_currentUser);
            pengaduanKebersihan.Visible = false;
            pengaduanKebersihan.Dock = DockStyle.Fill;
            panelContent.Controls.Add(pengaduanKebersihan);

            pengaduanKeamanan = new PengaduanKeamananForm(_currentUser);
            pengaduanKeamanan.Visible = false;
            pengaduanKeamanan.Dock = DockStyle.Fill;
            panelContent.Controls.Add(pengaduanKeamanan);

            pengaduanFasilitas = new PengaduanFasilitasForm(_currentUser);
            pengaduanFasilitas.Dock = DockStyle.Fill;
            pengaduanFasilitas.Visible = false;
            panelContent.Controls.Add(pengaduanFasilitas);
        }

        private void SetupComboBox()
        {
            comboBoxTipePengaduan.Items.Add("Kebersihan");
            comboBoxTipePengaduan.Items.Add("Keamanan");
            comboBoxTipePengaduan.Items.Add("Fasilitas");

            comboBoxTipePengaduan.SelectedIndex = 0;

            comboBoxTipePengaduan.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBoxTipePengaduan.SelectedIndexChanged += ComboBoxTipePengaduan_SelectedIndexChanged;
        }

        private void ComboBoxTipePengaduan_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowSelectedPanel();
        }

        private void ShowSelectedPanel()
        {
            if (currentControl != null)
            {
                currentControl.Visible = false;
            }

            if (comboBoxTipePengaduan.SelectedItem == null) return; switch (comboBoxTipePengaduan.SelectedItem.ToString())
            {
                case "Kebersihan":
                    pengaduanKebersihan.Visible = true;
                    currentControl = pengaduanKebersihan;
                    break;
                case "Keamanan":
                    pengaduanKeamanan.Visible = true;
                    currentControl = pengaduanKeamanan;
                    break;
                case "Fasilitas":
                    pengaduanFasilitas.Visible = true;
                    currentControl = pengaduanFasilitas;
                    break;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void logOutBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
