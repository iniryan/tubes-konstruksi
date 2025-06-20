using App.Core.Services;
using App.Core.Models;
using System;
using System.Windows.Forms;

namespace App.Forms
{
    public partial class Login : Form
    {
        private readonly IAuthService _authService;

        public Login()
        {
            InitializeComponent();
            _authService = new AuthService();

            btnLogin.Click += btnLogin_Click_Async;
            btnRegister.Click += btnRegister_Click;
        }

        private async void btnLogin_Click_Async(object? sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username and password tidak boleh kosong.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                User user = await _authService.LoginAsync(username, password);
                MessageBox.Show($"Login berhasil! Selamat datang, {user.Username}.", "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Form nextForm;
                if (user.Role.ToLower() == "admin")
                {
                    nextForm = new Dashboard(user);
                }
                else
                {
                    nextForm = new CivilianPage(user);
                }

                this.Hide();
                var result = nextForm.ShowDialog();
                
                if (result == DialogResult.OK)
                {
                    txtUsername.Clear();
                    txtPassword.Clear();
                    txtUsername.Focus();
                    this.Show();
                }
                else
                {
                    this.Close();
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message, "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegister_Click(object? sender, EventArgs e)
        {
            this.Hide();
            using (var registerForm = new Register())
            {
                registerForm.ShowDialog();
            }
            this.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var registerForm = new Register();
            registerForm.ShowDialog();
            this.Show();
        }
    }
}