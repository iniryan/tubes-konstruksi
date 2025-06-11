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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void daftarButton_Click(object sender, EventArgs e)
        {
            //string nama = namaLengkap.Text;
            //string alamat = alamatLengkap.Text;
            //string noHP = noHandphone.Text;
            //string username = newUsername.Text;
            //string password = newPassword.Text;

            //if (string.IsNullOrWhiteSpace(nama) || string.IsNullOrWhiteSpace(alamat) ||
            //    string.IsNullOrWhiteSpace(noHP) || string.IsNullOrWhiteSpace(username) ||
            //    string.IsNullOrWhiteSpace(password))
            //{
            //    MessageBox.Show("Semua field harus diisi.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            ////bool isSuccess = AuthService.Register(username, password);

            //if (isSuccess)
            //{
            //    MessageBox.Show("Registrasi berhasil! Silakan login.", "Registrasi Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    this.Close();
            //}
            //else
            //{
            //    MessageBox.Show("Username sudah terdaftar. Silakan gunakan username lain.", "Registration Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
