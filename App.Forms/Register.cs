using App.Core.Services;
using System;
using System.Windows.Forms;

namespace App.Forms
{
    public partial class Register : Form
    {
        private readonly IAuthService _authService;

        public Register()
        {
            InitializeComponent();
            _authService = new AuthService();

            daftarButton.Click += daftarButton_Click_Async;
            btnLogin.Click += btnLogin_Click;
        }

        private async void daftarButton_Click_Async(object? sender, EventArgs e)
        {
            string username = newUsername.Text;
            string password = newPassword.Text;
            string alamat = alamatLengkap.Text;
            string notelp = noHandphone.Text;
            string name = namaLengkap.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(alamat) || string.IsNullOrWhiteSpace(notelp) || string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Field tidak boleh kosong.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var user = await _authService.RegisterAsync(username, password, "civilian", alamat, notelp, name);
                MessageBox.Show($"Registrasi berhasil untuk user: {user.Username}! Silakan login.", "Registrasi Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Registration Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Registration Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogin_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void daftarButton_Click_1(object sender, EventArgs e)
        {

        }
        
    }
}