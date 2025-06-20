using System;
using System.Collections.Generic;
using System.Windows.Forms;
using App.Core.Models;
using App.Core.Services;

namespace App.Forms
{
    public partial class PengaduanKeamananForm : UserControl
    {
        private readonly User _currentUser;
        private readonly PengaduanKeamananService _service = new PengaduanKeamananService();
        private List<Pengaduan<DetailKeamanan>> _pengaduanList = new List<Pengaduan<DetailKeamanan>>();
        private string? _selectedId = null;

        // DTO untuk binding DataGridView
        private class PengaduanKeamananView
        {
            public string Id { get; set; }
            public string NamaPelapor { get; set; }
            public string RT { get; set; }
            public string JenisKejadian { get; set; }
            public string Lokasi { get; set; }
            public string Deskripsi { get; set; }
            public string Status { get; set; }
            public DateTime TanggalDibuat { get; set; }
        }

        public PengaduanKeamananForm(User user)
        {
            InitializeComponent();
            _currentUser = user;
            LoadDataAsync();
            SetupDataGridView();
        }

        private async void LoadDataAsync()
        {
            _pengaduanList = await _service.AmbilSemuaPengaduanAsync();
            var viewList = _pengaduanList.ConvertAll(p => new PengaduanKeamananView
            {
                Id = p.Id,
                NamaPelapor = p.Detail.NamaPelapor,
                RT = p.Detail.RT,
                JenisKejadian = p.Detail.JenisKejadian,
                Lokasi = p.Detail.Lokasi,
                Deskripsi = p.Detail.Deskripsi,
                Status = p.Status.ToString(),
                TanggalDibuat = p.TanggalDibuat
            });
            dataGridViewDataKeamanan.DataSource = null;
            dataGridViewDataKeamanan.DataSource = viewList;
        }

        private void SetupDataGridView()
        {
            dataGridViewDataKeamanan.AutoGenerateColumns = false;
            dataGridViewDataKeamanan.Columns.Clear();
            dataGridViewDataKeamanan.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Pilih Data", DataPropertyName = "Id", Width = 120 });
            dataGridViewDataKeamanan.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Pelapor", DataPropertyName = "NamaPelapor", Width = 100 });
            dataGridViewDataKeamanan.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Status", DataPropertyName = "Status", Width = 80 });
            dataGridViewDataKeamanan.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "RT", DataPropertyName = "RT", Width = 60 });
            dataGridViewDataKeamanan.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Jenis Kejadian", DataPropertyName = "JenisKejadian", Width = 120 });
            dataGridViewDataKeamanan.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Lokasi", DataPropertyName = "Lokasi", Width = 120 });
            dataGridViewDataKeamanan.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Deskripsi", DataPropertyName = "Deskripsi", Width = 180 });
            dataGridViewDataKeamanan.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tanggal Dibuat", DataPropertyName = "TanggalDibuat", Width = 120 });
        }

        private void ClearForm()
        {
            textBoxRT.Text = "";
            textBoxJenisKejadian.Text = "";
            textBoxLokasi.Text = "";
            richTextBoxDeskripsi.Text = "";
            _selectedId = null;
        }

        private async void buttonSimpan_Click(object sender, EventArgs e)
        {
            if (_selectedId == null)
            {
                // Tambah baru
                await _service.TambahPengaduanAsync(_currentUser.Name, textBoxLokasi.Text, richTextBoxDeskripsi.Text, textBoxRT.Text, textBoxJenisKejadian.Text);
            }
            else
            {
                // Update
                await _service.UbahDataPengaduanAsync(_selectedId, _currentUser.Name, richTextBoxDeskripsi.Text, textBoxLokasi.Text, textBoxRT.Text, textBoxJenisKejadian.Text);
            }
            LoadDataAsync();
            ClearForm();
        }

        private async void buttonHapus_Click(object sender, EventArgs e)
        {
            if (_selectedId != null)
            {
                await _service.HapusPengaduanAsync(_selectedId);
                LoadDataAsync();
                ClearForm();
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewDataKeamanan.SelectedRows.Count > 0)
            {
                var selectedView = dataGridViewDataKeamanan.SelectedRows[0].DataBoundItem as PengaduanKeamananView;
                if (selectedView != null)
                {
                    _selectedId = selectedView.Id;
                    textBoxRT.Text = selectedView.RT;
                    textBoxJenisKejadian.Text = selectedView.JenisKejadian;
                    textBoxLokasi.Text = selectedView.Lokasi;
                    richTextBoxDeskripsi.Text = selectedView.Deskripsi;
                }
            }
        }
    }
} 