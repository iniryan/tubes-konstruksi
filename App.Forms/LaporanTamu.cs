using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using App.Core.Services;


namespace App.Forms
{
    public partial class LaporanTamu : Form
    {
        public LaporanTamu()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Retrieve input values from text boxes
            string nama = txtNama.Text; // Assuming textBox1 is for Nama
            string nomorIdentitas = txtNomorIdentitas.Text; // Assuming textBox2 is for Nomor Identitas
            string tujuan = txtTujuan.Text; // Assuming textBox3 is for Tujuan
            string pegawaiTujuan = txtPegawai.Text; // Assuming textBox4 is for Pegawai Tujuan

            // Validate inputs
            if (string.IsNullOrWhiteSpace(nama) || string.IsNullOrWhiteSpace(nomorIdentitas) ||
                string.IsNullOrWhiteSpace(tujuan) || string.IsNullOrWhiteSpace(pegawaiTujuan))
            {
                MessageBox.Show("Semua kolom harus diisi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Add guest data to the repository
            GuestRepository.TambahTamu(new Tamu
            {
                Nama = nama,
                NomorIdentitas = nomorIdentitas,
                Tujuan = tujuan,
                PegawaiTujuan = pegawaiTujuan,
                WaktuDatang = DateTime.Now
            });

            MessageBox.Show("Tamu berhasil ditambahkan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Clear input fields
            txtNama.Clear();
            txtNomorIdentitas.Clear();
            txtTujuan.Clear();
            txtPegawai.Clear();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
