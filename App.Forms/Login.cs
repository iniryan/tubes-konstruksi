using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Windows.Forms;
using App.Forms;

namespace App.Forms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username and password tidak boleh kosong.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            User? user = AuthService.Login(username, password);

            if (user != null)
            {
                MessageBox.Show($"Login berhasil! Selamat datang, {user.Username}.", "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                var dashboard = new Dashboard(user);
                dashboard.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Username atau password salah.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
