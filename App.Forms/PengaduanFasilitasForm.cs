using App.Core.Models;
using App.Core.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.Forms
{
    public partial class PengaduanFasilitasForm : UserControl
    {
        private readonly User _currentUser;
        private readonly PengaduanFasilitasService _pengaduanService;
        private readonly IAuthService _authService;
        private readonly UserCreationService _userCreationService;
        private string? _selectedPengaduanId = null;
        private bool _isClearing = false;

        public PengaduanFasilitasForm(User user)
        {
            InitializeComponent();
            _currentUser = user;
            _authService = new AuthService();
            _userCreationService = new UserCreationService(_authService);
            _pengaduanService = new PengaduanFasilitasService();

            this.Dock = DockStyle.Fill;

            this.Load += PengaduanFasilitasForm_Load;
            buttonSimpanFasilitas.Click += buttonSimpan_Click;
            buttonClearFormFasilitas.Click += buttonClearForm_Click;

            dataGridViewDataFasilitas.SelectionChanged += DataGridViewDataFasilitas_SelectionChanged;
            dataGridViewDataFasilitas.RowPostPaint += DataGridViewDataFasilitas_RowPostPaint;
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

        private async void PengaduanFasilitasForm_Load(object? sender, EventArgs e)
        {
            SetupDataGridViewStyles();
            SetupComboBoxes();
            InitializeAdminControls();
            SetupNamaPelapor();
            await LoadUsersAsync();
            await LoadDataAsync();
        }
        private void SetupDataGridViewStyles()
        {
            dataGridViewDataFasilitas.RowHeadersVisible = true;
            dataGridViewDataFasilitas.TopLeftHeaderCell.Value = "Pilih Data";
            dataGridViewDataFasilitas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewDataFasilitas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewDataFasilitas.AllowUserToAddRows = false;
            dataGridViewDataFasilitas.AllowUserToDeleteRows = false;
            dataGridViewDataFasilitas.ReadOnly = true;

            ApplyDataGridViewStyling(dataGridViewDataFasilitas);

            var headerStyle = dataGridViewDataFasilitas.ColumnHeadersDefaultCellStyle;
            dataGridViewDataFasilitas.TopLeftHeaderCell.Style.ApplyStyle(headerStyle);
        }

        private void ApplyDataGridViewStyling(DataGridView dataGridView)
        {
            dataGridView.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);

            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 152, 219);
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Product Sans", 10, FontStyle.Bold);
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.EnableHeadersVisualStyles = false;

            dataGridView.DefaultCellStyle.Font = new Font("Product Sans", 9);
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(41, 128, 185);
            dataGridView.DefaultCellStyle.SelectionForeColor = Color.White;

            dataGridView.GridColor = Color.FromArgb(200, 200, 200);
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView.BackgroundColor = SystemColors.Control;
        }
        private void SetupComboBoxes()
        {
            comboBoxPrioritas.DataSource = Enum.GetValues(typeof(Prioritas));

            // Load allowed types from config.json
            var allowedTypes = LoadAllowedTypesFromConfig();
            comboBoxJenisFasilitas.Items.Clear();
            comboBoxJenisFasilitas.Items.AddRange(allowedTypes.ToArray());

            comboBoxPrioritas.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxJenisFasilitas.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private List<string> LoadAllowedTypesFromConfig()
        {
            try
            {
                string exeDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string solutionDirectory = Path.GetFullPath(Path.Combine(exeDirectory, "..", "..", "..", ".."));
                string configPath = Path.Combine(solutionDirectory, "App.Core", "Database", "config.json");

                var config = JsonNode.Parse(File.ReadAllText(configPath));
                return config["AllowedTypes"].AsArray().Select(t => t.ToString()).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading config: {ex.Message}. Using default values.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return new List<string> { "Lampu Jalan", "Jalan Lingkungan", "Taman Bermain", "Lapangan" };
            }
        }

        private async Task LoadDataAsync()
        {
            var data = await _pengaduanService.AmbilSemuaPengaduanAsync();
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
                p.Detail.JenisFasilitas,
                p.Detail.Lokasi,
                p.Detail.Deskripsi,
                TanggalDibuat = p.TanggalDibuat.ToString("dd/MM/yyyy HH:mm:ss")
            }).ToList();

            dataGridViewDataFasilitas.DataSource = displayData;
            if (dataGridViewDataFasilitas.Columns["Id"] != null)
            {
                dataGridViewDataFasilitas.Columns["Id"].Visible = false;
            }
            dataGridViewDataFasilitas.ClearSelection();
        }

        private void DataGridViewDataFasilitas_SelectionChanged(object? sender, EventArgs e)
        {
            if (_isClearing) return;

            if (dataGridViewDataFasilitas.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewDataFasilitas.SelectedRows[0];
                _selectedPengaduanId = selectedRow.Cells["Id"].Value?.ToString();
                string namaPelapor = selectedRow.Cells["Pelapor"].Value?.ToString() ?? string.Empty;

                comboBoxPrioritas.SelectedItem = selectedRow.Cells["PrioritasPengaduan"].Value;
                comboBoxJenisFasilitas.SelectedItem = selectedRow.Cells["JenisFasilitas"].Value?.ToString();
                textBoxLokasi.Text = selectedRow.Cells["Lokasi"].Value?.ToString() ?? string.Empty;
                richTextBoxDeskripsi.Text = selectedRow.Cells["Deskripsi"].Value?.ToString() ?? string.Empty;

                // Handle nama pelapor controls ketika edit mode
                if (_currentUser.Role.ToLower() == "admin")
                {
                    textBoxNamaPelapor.Text = namaPelapor;
                    textBoxNamaPelapor.ReadOnly = true;
                    textBoxNamaPelapor.Visible = true;
                    comboBoxUser.Visible = false;

                    // Disable radio buttons ketika edit
                    radioExistingUser.Enabled = false;
                    radioNewUser.Enabled = false;
                }
                else
                {
                    textBoxNamaPelapor.Text = namaPelapor;
                }

                labelTextForm.Text = "Form Ubah Pengaduan Fasilitas";
                buttonSimpanFasilitas.Text = "Ubah Data Pengaduan";
            }
            else
            {
                ClearForm();
            }
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

        private async void buttonSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxPrioritas.SelectedItem is not Prioritas prioritas)
                {
                    MessageBox.Show("Prioritas harus dipilih.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string? jenisFasilitas = comboBoxJenisFasilitas.SelectedItem?.ToString();
                string lokasi = textBoxLokasi.Text;
                string deskripsi = richTextBoxDeskripsi.Text;
                string namaPelapor = textBoxNamaPelapor.Text;

                if (string.IsNullOrWhiteSpace(lokasi) || string.IsNullOrWhiteSpace(deskripsi) || string.IsNullOrWhiteSpace(jenisFasilitas))
                {
                    MessageBox.Show("Semua field harus diisi.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_currentUser.Role.ToLower() == "admin" && radioNewUser.Checked && string.IsNullOrWhiteSpace(namaPelapor))
                {
                    MessageBox.Show("Nama pelapor tidak boleh kosong.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tambah atau Ubah
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
                                namaPelapor = selectedUser.Name;
                            }
                            else
                            {
                                MessageBox.Show("Silakan pilih user terlebih dahulu.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        else // radioNewUser.Checked
                        {
                            try
                            {
                                if (string.IsNullOrWhiteSpace(namaPelapor))
                                {
                                    MessageBox.Show("Nama pelapor tidak boleh kosong.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                                var newUser = await _userCreationService.CreateNewUserAsync(namaPelapor);
                                userId = newUser.Id;
                                string usernames = newUser.Username;
                                string passwords = usernames + "123";

                                var message = $"User baru telah dibuat!\n\n" +
                                     $"Nama: {namaPelapor}\n" +
                                     $"Username: {usernames}\n" +
                                     $"Password: {passwords}\n\n" +
                                     $"PENTING: Mohon catat atau salin informasi ini!\n" +
                                     $"User dapat mengganti password setelah login pertama.";

                                MessageBox.Show(message, "User Baru Dibuat", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Refresh combobox data
                                await LoadUsersAsync();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Gagal membuat user baru: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                    else
                    {
                        userId = _currentUser.Id;
                        namaPelapor = _currentUser.Name;
                    }

                    try
                    {
                        await _pengaduanService.TambahPengaduanAsync(userId, namaPelapor, lokasi, deskripsi, prioritas, jenisFasilitas);
                        MessageBox.Show("Pengaduan berhasil ditambahkan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Gagal menambah pengaduan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    var currentData = await _pengaduanService.AmbilPengaduanByIdAsync(_selectedPengaduanId);
                    if (currentData == null)
                    {
                        MessageBox.Show("Data pengaduan tidak ditemukan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    await _pengaduanService.UbahDataPengaduanAsync(_selectedPengaduanId, currentData.Detail.UserId, namaPelapor, lokasi, deskripsi, prioritas, jenisFasilitas);
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

        private void buttonClearForm_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private async void buttonHapus_Click(object sender, EventArgs e)
        {
            if (_selectedPengaduanId == null)
            {
                MessageBox.Show("Tidak ada pengaduan yang dipilih untuk dihapus.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    MessageBox.Show($"Terjadi kesalahan saat menghapus pengaduan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearForm()
        {
            _isClearing = true;
            _selectedPengaduanId = null;

            textBoxLokasi.Clear();
            richTextBoxDeskripsi.Clear();
            comboBoxPrioritas.SelectedIndex = 0;
            comboBoxJenisFasilitas.SelectedIndex = -1;

            if (_currentUser.Role.ToLower() == "admin")
            {
                radioExistingUser.Enabled = true;
                radioNewUser.Enabled = true;

                // Reset
                radioExistingUser.Checked = true;
                textBoxNamaPelapor.Clear();
                textBoxNamaPelapor.Visible = false;
                comboBoxUser.Visible = true;
                comboBoxUser.SelectedIndex = -1;
            }
            else
            {
                textBoxNamaPelapor.Text = _currentUser.Name;
            }

            labelTextForm.Text = "Form Pengaduan Fasilitas";
            buttonSimpanFasilitas.Text = "Simpan Data";

            dataGridViewDataFasilitas.ClearSelection();
            _isClearing = false;
        }

        private void DataGridViewDataFasilitas_RowPostPaint(object? sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (dataGridViewDataFasilitas.Rows[e.RowIndex].Selected) return;

            string symbol = "▶";
            using (Font font = new Font("Product Sans", 10, FontStyle.Bold))
            using (SolidBrush brush = new SolidBrush(Color.Gray))
            {
                SizeF stringSize = e.Graphics.MeasureString(symbol, font);
                float x = e.RowBounds.Left + (dataGridViewDataFasilitas.RowHeadersWidth - stringSize.Width) / 2;
                float y = e.RowBounds.Top + (e.RowBounds.Height - stringSize.Height) / 2;
                e.Graphics.DrawString(symbol, font, brush, x, y);
            }
        }

        private void panelContentPengaduan_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RadioButton_CheckedChanged(object? sender, EventArgs e)
        {
            if (_currentUser.Role.ToLower() == "admin")
            {
                if (radioExistingUser != null && radioExistingUser.Checked)
                {
                    // When existing user is selected
                    textBoxNamaPelapor.Clear();
                    textBoxNamaPelapor.Visible = false;
                    textBoxNamaPelapor.ReadOnly = true;

                    if (comboBoxUser != null)
                    {
                        comboBoxUser.Visible = true;
                        comboBoxUser.SelectedIndex = -1;
                    }
                }
                else if (radioNewUser != null && radioNewUser.Checked)
                {
                    // When new user is selected
                    comboBoxUser.Visible = false;
                    comboBoxUser.SelectedIndex = -1;
                    textBoxNamaPelapor.Visible = true;
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
                textBoxNamaPelapor.Text = _currentUser.Name;
                textBoxNamaPelapor.ReadOnly = true;
                textBoxNamaPelapor.Enabled = false;
                textBoxNamaPelapor.Visible = true;

                if (comboBoxUser != null)
                {
                    comboBoxUser.Visible = false;
                    comboBoxUser.Enabled = false;
                }
                if (radioExistingUser != null) radioExistingUser.Visible = false;
                if (radioNewUser != null) radioNewUser.Visible = false;
            }
            else // Admin
            {
                textBoxNamaPelapor.ReadOnly = true;
                textBoxNamaPelapor.Visible = false;

                comboBoxUser.Visible = true;
                comboBoxUser.Enabled = true;

                radioExistingUser.Visible = true;
                radioNewUser.Visible = true;
                radioExistingUser.Checked = true;

                RadioButton_CheckedChanged(null, EventArgs.Empty);
            }
        }
    }
}
