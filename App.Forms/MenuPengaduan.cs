using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using App.Forms;

namespace App.Forms
{
    public partial class MenuPengaduan : Form
    {
        private Control currentControl;
        private PengaduanKebersihan pengaduanKebersihan;

        public Panel GetPanel()
        {
            return panelMenuPengaduan;
        }

        public MenuPengaduan()
        {
            InitializeComponent();
            InitializePanels();
            SetupComboBox();
            ShowSelectedPanel();
        }

        private void InitializePanels()
        {
            // Initialize panel untuk Kebersihan
            pengaduanKebersihan = new PengaduanKebersihan();
            pengaduanKebersihan.Dock = DockStyle.Fill;
            pengaduanKebersihan.Visible = false;
            panelContentPengaduan.Controls.Add(pengaduanKebersihan);
        }

        private void SetupComboBox()
        {
            // Add items to combobox
            comboBoxTipePengaduan.Items.Add("Kebersihan");
            comboBoxTipePengaduan.Items.Add("Keamanan");
            comboBoxTipePengaduan.Items.Add("Fasilitas");

            // Set default selected item as "Kebersihan"
            comboBoxTipePengaduan.SelectedIndex = 0;

            // Make comboBox cannot be edited
            comboBoxTipePengaduan.DropDownStyle = ComboBoxStyle.DropDownList;

            // Add event handler for selection change
            comboBoxTipePengaduan.SelectedIndexChanged += ComboBoxTipePengaduan_SelectedIndexChanged;
        }

        private void ComboBoxTipePengaduan_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Panggil metode terpusat untuk menampilkan panel
            ShowSelectedPanel();
        }

        /// <summary>
        /// Metode terpusat untuk menyembunyikan panel lama dan menampilkan panel baru
        /// sesuai dengan pilihan di ComboBox.
        /// </summary>
        private void ShowSelectedPanel()
        {
            // Sembunyikan kontrol yang sedang aktif (jika ada)
            if (currentControl != null)
            {
                currentControl.Visible = false;
            }

            // Periksa item yang dipilih dan tampilkan kontrol yang sesuai
            if (comboBoxTipePengaduan.SelectedItem == null) return;

            switch (comboBoxTipePengaduan.SelectedItem.ToString())
            {
                case "Kebersihan":
                    pengaduanKebersihan.Visible = true;
                    currentControl = pengaduanKebersihan;
                    break;
                case "Keamanan":
                    // TODO: Tampilkan UserControl untuk Keamanan
                    // pengaduanKeamanan.Visible = true;
                    // currentControl = pengaduanKeamanan;
                    break;
                case "Fasilitas":
                    // TODO: Tampilkan UserControl untuk Fasilitas
                    // pengaduanFasilitas.Visible = true;
                    // currentControl = pengaduanFasilitas;
                    break;
            }
        }
    }
}
