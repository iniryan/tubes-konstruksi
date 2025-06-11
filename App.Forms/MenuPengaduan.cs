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
    public partial class MenuPengaduan : Form
    {
        private readonly User _currentUser;
        private Control currentControl;
        private PengaduanKebersihan pengaduanKebersihan;
        private PengaduanFasilitasForm pengaduanFasilitas;

        public Panel GetPanel()
        {
            return panelMenuPengaduan;
        }

        public MenuPengaduan(User user)
        {
            InitializeComponent();
            _currentUser = user;
            InitializePanels();
            SetupComboBox();
            ShowSelectedPanel();
        }

        private void InitializePanels()
        {
            pengaduanKebersihan = new PengaduanKebersihan(_currentUser);
            pengaduanKebersihan.Visible = false;
            pengaduanKebersihan.Dock = DockStyle.Fill;
            panelContentPengaduan.Controls.Add(pengaduanKebersihan);
            
            pengaduanFasilitas = new PengaduanFasilitasForm();
            pengaduanFasilitas.Dock = DockStyle.Fill;
            pengaduanFasilitas.Visible = false;
            panelContentPengaduan.Controls.Add(pengaduanFasilitas);
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

            if (comboBoxTipePengaduan.SelectedItem == null) return;

            switch (comboBoxTipePengaduan.SelectedItem.ToString())
            {
                case "Kebersihan":
                    pengaduanKebersihan.Visible = true;
                    currentControl = pengaduanKebersihan;
                    break;
                case "Keamanan":
                    // pengaduanKeamanan.Visible = true;
                    // currentControl = pengaduanKeamanan;
                    break;
                case "Fasilitas":
                    // TODO: Tampilkan UserControl untuk Fasilitas
                     pengaduanFasilitas.Visible = true;
                    currentControl = pengaduanFasilitas;
                    break;
            }
        }
    }
}
