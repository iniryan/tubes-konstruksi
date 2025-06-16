using App.Core.Models;
using App.Core.Services;
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.Forms
{
    public partial class PengaduanKebersihan : UserControl
    {
        private readonly User _currentUser;
        private readonly PengaduanKebersihanService _pengaduanService;
        private readonly IAuthService _authService;
        private string? _selectedPengaduanId = null;
        private bool _isClearing = false;

        public PengaduanKebersihan(User user)
        {
            InitializeComponent();
            _currentUser = user;
            _authService = new AuthService();
            _pengaduanService = new PengaduanKebersihanService();

            this.Dock = DockStyle.Fill;
            InitializeAdminControls();

            this.Load += PengaduanKebersihan_Load;
            buttonSave.Click += ButtonSave_Click;
            buttonClear.Click += ButtonClear_Click;
            buttonDelete.Click += ButtonDelete_Click;
            dataGridViewDataKebersihan.SelectionChanged += DataGridViewDataKebersihan_SelectionChanged;
            dataGridViewDataKebersihan.RowPostPaint += DataGridViewDataKebersihan_RowPostPaint;
        }

        private void InitializeAdminControls()
        {
            if (_currentUser.Role.ToLower() == "admin")
            {
                radioExistingUser.CheckedChanged += RadioButton_CheckedChanged;
                radioNewUser.CheckedChanged += RadioButton_CheckedChanged;
                comboBoxUser.SelectedIndexChanged += ComboBoxUser_SelectedIndexChanged;
            }
        }

        private async void PengaduanKebersihan_Load(object? sender, EventArgs e)
        {
            SetupDataGridViewStyles();
            SetupComboBoxes();

            // Set up name and controls first
            SetupNamaPelapor();

            // Then load users (for admin only)
            await LoadUsersAsync();

            // Finally load the data
            await LoadDataAsync();
        }

        private void SetupDataGridViewStyles()
        {
            dataGridViewDataKebersihan.RowHeadersVisible = true;
            dataGridViewDataKebersihan.TopLeftHeaderCell.Value = "Pilih Data";
            dataGridViewDataKebersihan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewDataKebersihan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dataGridViewDataKebersihan.AllowUserToAddRows = false;
            dataGridViewDataKebersihan.AllowUserToDeleteRows = false;
            dataGridViewDataKebersihan.ReadOnly = true;

            var headerStyle = dataGridViewDataKebersihan.ColumnHeadersDefaultCellStyle;
            headerStyle.BackColor = Color.Navy;
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font("Product Sans", 10, FontStyle.Bold);
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataGridViewDataKebersihan.TopLeftHeaderCell.Style.ApplyStyle(headerStyle);
        }

        private void SetupComboBoxes()
        {
            comboBoxPrioritas.DataSource = Enum.GetValues(typeof(Prioritas));

            comboBoxKategori.Items.AddRange(new string[] { "Sampah", "WC Umum", "Saluran Air", "Lingkungan" });

            comboBoxPrioritas.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxKategori.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private async Task LoadDataAsync()
        {
            var data = await _pengaduanService.AmbilSemuaPengaduanAsync();

            // Filter data if user is civilian
            if (_currentUser.Role.ToLower() == "civilian")
            {
                data = data.Where(p => p.Detail.UserId == _currentUser.Id).ToList();
            }

            var displayData = data.Select(p => new
            {
                p.Id,
                Pelapor = p.Detail.NamaPelapor,
                p.Status,
                p.Detail.PrioritasPengaduan,
                p.Detail.Kategori,
                p.Detail.Lokasi,
                p.Detail.Deskripsi,
                p.TanggalDibuat
            }).ToList();

            dataGridViewDataKebersihan.DataSource = displayData;

            if (dataGridViewDataKebersihan.Columns["Id"] != null)
            {
                dataGridViewDataKebersihan.Columns["Id"].Visible = false;
            }

            dataGridViewDataKebersihan.ClearSelection();
        }

        private async Task LoadUsersAsync()
        {
            if (_currentUser.Role.ToLower() == "admin")
            {
                try
                {
                    var users = await _authService.GetAllUsersAsync();
                    var civilianUsers = users.Where(u => u.Role.ToLower() == "civilian").ToList();

                    comboBoxUser.DisplayMember = "Name";
                    comboBoxUser.ValueMember = "Id";
                    comboBoxUser.DataSource = civilianUsers;
                    comboBoxUser.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading users: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DataGridViewDataKebersihan_SelectionChanged(object? sender, EventArgs e)
        {
            if (_isClearing) return;

            if (dataGridViewDataKebersihan.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewDataKebersihan.SelectedRows[0];

                _selectedPengaduanId = selectedRow.Cells["Id"].Value?.ToString();


                comboBoxPrioritas.SelectedItem = (Prioritas)selectedRow.Cells["PrioritasPengaduan"].Value;
                comboBoxKategori.SelectedItem = selectedRow.Cells["Kategori"].Value?.ToString();
                textBoxLokasi.Text = selectedRow.Cells["Lokasi"].Value?.ToString();
                textBoxNamaPelapor.Text = selectedRow.Cells["Pelapor"].Value?.ToString();
                richTextBoxDeskripsi.Text = selectedRow.Cells["Deskripsi"].Value?.ToString();

                labelTextFormKebersihan.Text = "Ubah Data Pengaduan";
                buttonSave.Text = "Ubah Data";
            }
            else
            {
                ClearForm();
            }
        }

        private async void ButtonSave_Click(object? sender, EventArgs e)
        {
            try
            {
                if (comboBoxPrioritas.SelectedItem is not Prioritas prioritas)
                {
                    MessageBox.Show("Prioritas harus dipilih.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string? kategori = comboBoxKategori.SelectedItem?.ToString();
                string lokasi = textBoxLokasi.Text;
                string deskripsi = richTextBoxDeskripsi.Text;
                string namaPelapor = textBoxNamaPelapor.Text;

                if (string.IsNullOrWhiteSpace(lokasi) || string.IsNullOrWhiteSpace(deskripsi) ||
                    string.IsNullOrWhiteSpace(kategori) || string.IsNullOrWhiteSpace(namaPelapor))
                {
                    MessageBox.Show("Semua field harus diisi.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_selectedPengaduanId == null)
                {
                    int userId;
                    if (_currentUser.Role.ToLower() == "admin")
                    {
                        if (radioExistingUser.Checked)
                        {
                            if (comboBoxUser.SelectedItem is User selectedUser)
                            {
                                userId = selectedUser.Id;
                            }
                            else
                            {
                                MessageBox.Show("Silakan pilih user terlebih dahulu.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        else
                        {
                            try
                            {
                                var newUser = await CreateNewUserAsync(namaPelapor);
                                userId = newUser.Id;

                                await LoadUsersAsync();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                    else
                    {
                        userId = _currentUser.Id;
                    }

                    await _pengaduanService.TambahPengaduanAsync(userId, namaPelapor, lokasi, deskripsi, prioritas, kategori);
                    MessageBox.Show("Pengaduan berhasil ditambahkan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var currentData = await _pengaduanService.AmbilPengaduanByIdAsync(_selectedPengaduanId);
                    if (currentData == null)
                    {
                        MessageBox.Show("Data pengaduan tidak ditemukan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    await _pengaduanService.UbahDataPengaduanAsync(_selectedPengaduanId, currentData.Detail.UserId,
                        namaPelapor, lokasi, deskripsi, prioritas, kategori);
                    MessageBox.Show("Pengaduan berhasil diubah.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                await LoadDataAsync();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonClear_Click(object? sender, EventArgs e)
        {
            ClearForm();
        }

        private async void ButtonDelete_Click(object? sender, EventArgs e)
        {
            if (_selectedPengaduanId == null)
            {
                MessageBox.Show("Pilih pengaduan yang ingin dihapus.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show("Apakah Anda yakin ingin menghapus pengaduan ini?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    await _pengaduanService.HapusPengaduanAsync(_selectedPengaduanId);
                    MessageBox.Show("Pengaduan berhasil dihapus.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDataAsync();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Gagal menghapus data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ClearForm()
        {
            _isClearing = true;

            _selectedPengaduanId = null;

            // Only clear nama pelapor if admin
            if (_currentUser.Role.ToLower() == "admin")
            {
                textBoxNamaPelapor.Clear();
            }

            richTextBoxDeskripsi.Clear();
            textBoxLokasi.Clear();
            comboBoxPrioritas.SelectedIndex = 0;
            comboBoxKategori.SelectedIndex = -1;

            labelTextFormKebersihan.Text = "Form Pengaduan Kebersihan";
            buttonSave.Text = "Simpan Data";

            dataGridViewDataKebersihan.ClearSelection();

            _isClearing = false;
        }

        private void DataGridViewDataKebersihan_RowPostPaint(object? sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (dataGridViewDataKebersihan.Rows[e.RowIndex].Selected) return;

            string symbol = "▶";
            using (Font font = new Font("Product Sans", 10, FontStyle.Bold))
            using (SolidBrush brush = new SolidBrush(Color.Gray))
            {
                SizeF stringSize = e.Graphics.MeasureString(symbol, font);
                float x = e.RowBounds.Left + (dataGridViewDataKebersihan.RowHeadersWidth - stringSize.Width) / 2;
                float y = e.RowBounds.Top + (e.RowBounds.Height - stringSize.Height) / 2;
                e.Graphics.DrawString(symbol, font, brush, x, y);
            }
        }

        private void buttonSave_Click_1(object sender, EventArgs e)
        {

        }
        private void RadioButton_CheckedChanged(object? sender, EventArgs e)
        {
            if (_currentUser.Role.ToLower() == "admin")
            {
                if (radioExistingUser != null && radioExistingUser.Checked)
                {
                    comboBoxUser.Visible = true;
                    textBoxNamaPelapor.ReadOnly = true;

                    if (comboBoxUser.SelectedItem is User selectedUser)
                    {
                        textBoxNamaPelapor.Text = selectedUser.Name;
                    }
                }
                else
                {
                    comboBoxUser.Visible = false;
                    textBoxNamaPelapor.ReadOnly = false;
                    textBoxNamaPelapor.Clear();
                }
            }
        }

        private void ComboBoxUser_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (comboBoxUser.SelectedItem is User selectedUser)
            {
                textBoxNamaPelapor.Text = selectedUser.Name;
            }
        }

        private void SetupNamaPelapor()
        {
            if (_currentUser.Role.ToLower() == "civilian")
            {
                // For civilian
                textBoxNamaPelapor.Text = _currentUser.Name;
                textBoxNamaPelapor.ReadOnly = true;
                textBoxNamaPelapor.Enabled = false;

                //ubah posisi y awal lokasi dan deskripsi
                labelTextLokasi.Location = new Point(labelTextLokasi.Location.X, labelTextLokasi.Location.Y - 42);
                labelTextDeskripsiPengaduan.Location = new Point(labelTextDeskripsiPengaduan.Location.X, labelTextDeskripsiPengaduan.Location.Y - 42);
                textBoxLokasi.Location = new Point(textBoxLokasi.Location.X, textBoxLokasi.Location.Y - 42);
                richTextBoxDeskripsi.Location = new Point(richTextBoxDeskripsi.Location.X, richTextBoxDeskripsi.Location.Y - 42);

                //ubah ukuran tinggi deskripsi
                richTextBoxDeskripsi.Size = new Size(richTextBoxDeskripsi.Size.Width, 135);


                // Hide admin controls
                if (comboBoxUser != null) comboBoxUser.Visible = false;
                if (radioExistingUser != null) radioExistingUser.Visible = false;
                if (radioNewUser != null) radioNewUser.Visible = false;
            }
            else
            {
                // For admin
                textBoxNamaPelapor.ReadOnly = true;
                if (radioExistingUser != null)
                {
                    radioExistingUser.Checked = true;
                }
                RadioButton_CheckedChanged(null, EventArgs.Empty);

            }
        }

        private async Task<User> CreateNewUserAsync(string namaPelapor)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(namaPelapor))
                {
                    throw new ArgumentException("Nama pelapor tidak boleh kosong.");
                }

                if (namaPelapor.Length < 3)
                {
                    throw new ArgumentException("Nama pelapor harus minimal 3 karakter.");
                }

                string username = string.Join("", namaPelapor.ToLower()
                    .Where(c => char.IsLetterOrDigit(c) || c == ' ')
                    .ToArray())
                    .Replace(" ", "");

                var existingUsers = await _authService.GetAllUsersAsync();
                if (existingUsers.Any(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
                {
                    int counter = 1;
                    string baseUsername = username;
                    while (existingUsers.Any(u => u.Username.Equals($"{username}", StringComparison.OrdinalIgnoreCase)))
                    {
                        username = $"{baseUsername}{counter}";
                        counter++;
                    }
                }

                string password = username + "123";

                string role = "civilian";
                string alamat = "-";
                string notelp = "-";

                User newUser = await _authService.RegisterAsync(username, password, role, alamat, notelp, namaPelapor);

                var message = $"User baru telah dibuat!\n\n" +
                             $"Nama: {namaPelapor}\n" +
                             $"Username: {username}\n" +
                             $"Password: {password}\n\n" +
                             $"PENTING: Mohon catat atau salin informasi ini!\n" +
                             $"User dapat mengganti password setelah login pertama.";

                MessageBox.Show(message, "User Baru Dibuat", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return newUser;
            }
            catch (Exception ex)
            {
                throw new Exception($"Gagal membuat user baru: {ex.Message}");
            }
        }
    }
}