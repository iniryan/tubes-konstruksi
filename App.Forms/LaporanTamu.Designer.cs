namespace App.Forms
{
    partial class LaporanTamu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelMenuLaporanTamu = new Panel();
            panelContentLaporanTamu = new Panel();
            buttonClear = new Button();
            buttonDelete = new Button();
            labelTextDaftarLaporanTamu = new Label();
            dataGridViewDataLaporanTamu = new DataGridView();
            panelFormKebersihan = new Panel();
            textPegawai = new TextBox();
            textTujuan = new TextBox();
            textNomorIdentitas = new TextBox();
            textNama = new TextBox();
            buttonSave = new Button();
            labelTextDeskripsiPengaduan = new Label();
            labelTextLokasi = new Label();
            labelTextKategori = new Label();
            labelTextPrioritas = new Label();
            labelTextFormTambahTamu = new Label();
            label1 = new Label();
            dateTimePickerWaktuKeluar = new DateTimePicker();
            panelMenuLaporanTamu.SuspendLayout();
            panelContentLaporanTamu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDataLaporanTamu).BeginInit();
            panelFormKebersihan.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenuLaporanTamu
            // 
            panelMenuLaporanTamu.Controls.Add(panelContentLaporanTamu);
            panelMenuLaporanTamu.Dock = DockStyle.Right;
            panelMenuLaporanTamu.Location = new Point(234, 0);
            panelMenuLaporanTamu.Name = "panelMenuLaporanTamu";
            panelMenuLaporanTamu.Size = new Size(948, 673);
            panelMenuLaporanTamu.TabIndex = 11;
            // 
            // panelContentLaporanTamu
            // 
            panelContentLaporanTamu.Controls.Add(buttonClear);
            panelContentLaporanTamu.Controls.Add(buttonDelete);
            panelContentLaporanTamu.Controls.Add(labelTextDaftarLaporanTamu);
            panelContentLaporanTamu.Controls.Add(dataGridViewDataLaporanTamu);
            panelContentLaporanTamu.Controls.Add(panelFormKebersihan);
            panelContentLaporanTamu.Dock = DockStyle.Bottom;
            panelContentLaporanTamu.Location = new Point(0, 0);
            panelContentLaporanTamu.Name = "panelContentLaporanTamu";
            panelContentLaporanTamu.Size = new Size(948, 673);
            panelContentLaporanTamu.TabIndex = 1;
            // 
            // buttonClear
            // 
            buttonClear.BackColor = SystemColors.Info;
            buttonClear.FlatStyle = FlatStyle.Flat;
            buttonClear.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonClear.ForeColor = SystemColors.ActiveCaptionText;
            buttonClear.Location = new Point(348, 476);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(164, 40);
            buttonClear.TabIndex = 11;
            buttonClear.Text = "Clear Form";
            buttonClear.UseVisualStyleBackColor = false;
            // 
            // buttonDelete
            // 
            buttonDelete.BackColor = Color.Firebrick;
            buttonDelete.FlatStyle = FlatStyle.Flat;
            buttonDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonDelete.ForeColor = SystemColors.Control;
            buttonDelete.Location = new Point(126, 476);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(202, 40);
            buttonDelete.TabIndex = 10;
            buttonDelete.Text = "Hapus Data";
            buttonDelete.UseVisualStyleBackColor = false;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // labelTextDaftarLaporanTamu
            // 
            labelTextDaftarLaporanTamu.AutoSize = true;
            labelTextDaftarLaporanTamu.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTextDaftarLaporanTamu.Location = new Point(21, 14);
            labelTextDaftarLaporanTamu.Name = "labelTextDaftarLaporanTamu";
            labelTextDaftarLaporanTamu.Size = new Size(212, 28);
            labelTextDaftarLaporanTamu.TabIndex = 9;
            labelTextDaftarLaporanTamu.Text = "Daftar Laporan Tamu";
            // 
            // dataGridViewDataLaporanTamu
            // 
            dataGridViewDataLaporanTamu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDataLaporanTamu.Location = new Point(21, 60);
            dataGridViewDataLaporanTamu.Name = "dataGridViewDataLaporanTamu";
            dataGridViewDataLaporanTamu.RowHeadersWidth = 51;
            dataGridViewDataLaporanTamu.Size = new Size(491, 396);
            dataGridViewDataLaporanTamu.TabIndex = 1;
            dataGridViewDataLaporanTamu.CellContentClick += dataGridViewDataLaporanTamu_CellContentClick;
            // 
            // panelFormKebersihan
            // 
            panelFormKebersihan.Controls.Add(dateTimePickerWaktuKeluar);
            panelFormKebersihan.Controls.Add(label1);
            panelFormKebersihan.Controls.Add(textPegawai);
            panelFormKebersihan.Controls.Add(textTujuan);
            panelFormKebersihan.Controls.Add(textNomorIdentitas);
            panelFormKebersihan.Controls.Add(textNama);
            panelFormKebersihan.Controls.Add(buttonSave);
            panelFormKebersihan.Controls.Add(labelTextDeskripsiPengaduan);
            panelFormKebersihan.Controls.Add(labelTextLokasi);
            panelFormKebersihan.Controls.Add(labelTextKategori);
            panelFormKebersihan.Controls.Add(labelTextPrioritas);
            panelFormKebersihan.Controls.Add(labelTextFormTambahTamu);
            panelFormKebersihan.Dock = DockStyle.Right;
            panelFormKebersihan.Location = new Point(531, 0);
            panelFormKebersihan.Name = "panelFormKebersihan";
            panelFormKebersihan.Size = new Size(417, 673);
            panelFormKebersihan.TabIndex = 0;
            // 
            // textPegawai
            // 
            textPegawai.Location = new Point(25, 334);
            textPegawai.Name = "textPegawai";
            textPegawai.Size = new Size(254, 27);
            textPegawai.TabIndex = 17;
            // 
            // textTujuan
            // 
            textTujuan.Location = new Point(21, 253);
            textTujuan.Name = "textTujuan";
            textTujuan.Size = new Size(258, 27);
            textTujuan.TabIndex = 16;
            // 
            // textNomorIdentitas
            // 
            textNomorIdentitas.Location = new Point(21, 172);
            textNomorIdentitas.Name = "textNomorIdentitas";
            textNomorIdentitas.Size = new Size(258, 27);
            textNomorIdentitas.TabIndex = 15;
            // 
            // textNama
            // 
            textNama.Location = new Point(25, 96);
            textNama.Name = "textNama";
            textNama.Size = new Size(254, 27);
            textNama.TabIndex = 14;
            // 
            // buttonSave
            // 
            buttonSave.BackColor = SystemColors.Highlight;
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonSave.ForeColor = SystemColors.Control;
            buttonSave.Location = new Point(29, 476);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(360, 40);
            buttonSave.TabIndex = 13;
            buttonSave.Text = "Simpan Data";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += buttonSave_Click;
            // 
            // labelTextDeskripsiPengaduan
            // 
            labelTextDeskripsiPengaduan.AutoSize = true;
            labelTextDeskripsiPengaduan.Location = new Point(25, 300);
            labelTextDeskripsiPengaduan.Name = "labelTextDeskripsiPengaduan";
            labelTextDeskripsiPengaduan.Size = new Size(64, 20);
            labelTextDeskripsiPengaduan.TabIndex = 12;
            labelTextDeskripsiPengaduan.Text = "Pegawai";
            // 
            // labelTextLokasi
            // 
            labelTextLokasi.AutoSize = true;
            labelTextLokasi.Location = new Point(29, 220);
            labelTextLokasi.Name = "labelTextLokasi";
            labelTextLokasi.Size = new Size(53, 20);
            labelTextLokasi.TabIndex = 11;
            labelTextLokasi.Text = "Tujuan";
            labelTextLokasi.Click += labelTextLokasi_Click;
            // 
            // labelTextKategori
            // 
            labelTextKategori.AutoSize = true;
            labelTextKategori.Location = new Point(25, 140);
            labelTextKategori.Name = "labelTextKategori";
            labelTextKategori.Size = new Size(117, 20);
            labelTextKategori.TabIndex = 10;
            labelTextKategori.Text = "Nomor Identitas";
            // 
            // labelTextPrioritas
            // 
            labelTextPrioritas.AutoSize = true;
            labelTextPrioritas.Location = new Point(25, 60);
            labelTextPrioritas.Name = "labelTextPrioritas";
            labelTextPrioritas.Size = new Size(49, 20);
            labelTextPrioritas.TabIndex = 9;
            labelTextPrioritas.Text = "Nama";
            // 
            // labelTextFormTambahTamu
            // 
            labelTextFormTambahTamu.AutoSize = true;
            labelTextFormTambahTamu.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTextFormTambahTamu.Location = new Point(21, 14);
            labelTextFormTambahTamu.Name = "labelTextFormTambahTamu";
            labelTextFormTambahTamu.Size = new Size(197, 28);
            labelTextFormTambahTamu.TabIndex = 8;
            labelTextFormTambahTamu.Text = "Form Tambah Tamu";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 386);
            label1.Name = "label1";
            label1.Size = new Size(96, 20);
            label1.TabIndex = 18;
            label1.Text = "Waktu Keluar";
            label1.Click += label1_Click;
            // 
            // dateTimePickerWaktuKeluar
            // 
            dateTimePickerWaktuKeluar.Location = new Point(29, 419);
            dateTimePickerWaktuKeluar.Name = "dateTimePickerWaktuKeluar";
            dateTimePickerWaktuKeluar.Size = new Size(250, 27);
            dateTimePickerWaktuKeluar.TabIndex = 19;
            dateTimePickerWaktuKeluar.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // LaporanTamu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 673);
            Controls.Add(panelMenuLaporanTamu);
            Name = "LaporanTamu";
            Text = "LaporanTamu";
            Load += LaporanTamu_Load;
            panelMenuLaporanTamu.ResumeLayout(false);
            panelContentLaporanTamu.ResumeLayout(false);
            panelContentLaporanTamu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDataLaporanTamu).EndInit();
            panelFormKebersihan.ResumeLayout(false);
            panelFormKebersihan.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMenuLaporanTamu;
        private Panel panelContentLaporanTamu;
        private Button buttonClear;
        private Button buttonDelete;
        private Label labelTextDaftarLaporanTamu;
        private DataGridView dataGridViewDataLaporanTamu;
        private Panel panelFormKebersihan;
        private Button buttonSave;
        private Label labelTextDeskripsiPengaduan;
        private Label labelTextLokasi;
        private Label labelTextKategori;
        private Label labelTextPrioritas;
        private Label labelTextFormTambahTamu;
        private TextBox textTujuan;
        private TextBox textNomorIdentitas;
        private TextBox textNama;
        private TextBox textPegawai;
        private Label label1;
        private DateTimePicker dateTimePickerWaktuKeluar;
    }
}