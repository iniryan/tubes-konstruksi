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
using App.Core.Services;

namespace App.Forms
{
    public partial class Pengguna : Form
    {
        private readonly User _currentUser;
        private readonly AuthService _authService;
        private readonly UserCreationService _userCreationService;

        public Pengguna(User user)
        {
            InitializeComponent();
            _currentUser = user;
            _authService = new AuthService();
            _userCreationService = new UserCreationService(_authService);

            InitializeDataGridView();
            LoadUsersData();
        }

        public Pengguna()
        {
            InitializeComponent();
        }

        private void InitializeDataGridView()
        {
            daftarPengguna.AutoGenerateColumns = false;
            daftarPengguna.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            daftarPengguna.MultiSelect = false;
            daftarPengguna.ReadOnly = true;
            daftarPengguna.AllowUserToAddRows = false;
            daftarPengguna.AllowUserToDeleteRows = false;

            daftarPengguna.Columns.Clear();

            daftarPengguna.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "ID",
                DataPropertyName = "Id",
                Width = 50,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            daftarPengguna.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Name",
                HeaderText = "Nama Lengkap",
                DataPropertyName = "Name",
                Width = 200
            });

            daftarPengguna.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Username",
                HeaderText = "Username",
                DataPropertyName = "Username",
                Width = 150
            });

            daftarPengguna.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Role",
                HeaderText = "Role",
                DataPropertyName = "Role",
                Width = 100,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            daftarPengguna.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Alamat",
                HeaderText = "Alamat",
                DataPropertyName = "Alamat",
                Width = 200
            });

            daftarPengguna.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NoTelepon",
                HeaderText = "No. Telepon",
                DataPropertyName = "NoTelepon",
                Width = 150
            });

            daftarPengguna.RowsDefaultCellStyle.BackColor = Color.White;
            daftarPengguna.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);

            daftarPengguna.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 152, 219);
            daftarPengguna.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            daftarPengguna.ColumnHeadersDefaultCellStyle.Font = new Font("Product Sans", 10, FontStyle.Bold);
            daftarPengguna.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            daftarPengguna.EnableHeadersVisualStyles = false;

            daftarPengguna.DefaultCellStyle.Font = new Font("Product Sans", 9);
            daftarPengguna.DefaultCellStyle.SelectionBackColor = Color.FromArgb(41, 128, 185);
            daftarPengguna.DefaultCellStyle.SelectionForeColor = Color.White;

            daftarPengguna.GridColor = Color.FromArgb(200, 200, 200);
            daftarPengguna.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            daftarPengguna.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
        }

        private async void LoadUsersData()
        {
            try
            {
                var users = await _authService.GetAllUsersAsync();

                var userDisplayList = users.Select(user => new UserDisplay
                {
                    Id = user.Id,
                    Name = user.Name,
                    Username = user.Username,
                    Role = FormatRole(user.Role),
                    Alamat = string.IsNullOrWhiteSpace(user.Alamat) || user.Alamat == "-" ? "Tidak diisi" : user.Alamat,
                    NoTelepon = string.IsNullOrWhiteSpace(user.NoTelepon) || user.NoTelepon == "-" ? "Tidak diisi" : user.NoTelepon
                }).OrderBy(u => u.Id).ToList();

                daftarPengguna.DataSource = userDisplayList;

                labelTextDaftarPengguna.Text = $"Daftar Semua Pengguna ({users.Count} pengguna)";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string FormatRole(string role)
        {
            return role.ToLower() switch
            {
                "admin" => "Administrator",
                "civilian" => "Warga Sipil",
                _ => "Unknown"
            };
        }

        public Panel GetPanel()
        {
            return panelMenuPengguna;
        }

        public async void RefreshData()
        {
            LoadUsersData();
        }
    }

    public class UserDisplay
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Username { get; set; } = "";
        public string Role { get; set; } = "";
        public string Alamat { get; set; } = "";
        public string NoTelepon { get; set; } = "";
    }
}
