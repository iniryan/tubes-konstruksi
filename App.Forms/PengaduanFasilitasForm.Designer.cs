namespace App.Forms
{
    partial class PengaduanFasilitasForm
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
            buttonSimpan = new Button();
            labelTextDeskripsiPengaduan = new Label();
            labelTextLokasi = new Label();
            labelTextKategori = new Label();
            labelTextPrioritas = new Label();
            labelTextFormKebersihan = new Label();
            comboBoxJenisFasilitas = new ComboBox();
            richTextBoxDeskripsi = new RichTextBox();
            textBoxLokasi = new TextBox();
            comboBoxPrioritas = new ComboBox();
            buttonClearForm = new Button();
            buttonHapus = new Button();
            labelTextDaftarPengaduan = new Label();
            dataGridViewDataKebersihan = new DataGridView();
            panelContentPengaduan = new Panel();
            panelFormKebersihan = new Panel();
            panelMenuPengaduan = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDataKebersihan).BeginInit();
            panelContentPengaduan.SuspendLayout();
            panelFormKebersihan.SuspendLayout();
            panelMenuPengaduan.SuspendLayout();
            SuspendLayout();
            // 
            // buttonSimpan
            // 
            buttonSimpan.BackColor = SystemColors.Highlight;
            buttonSimpan.FlatStyle = FlatStyle.Flat;
            buttonSimpan.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonSimpan.ForeColor = SystemColors.Control;
            buttonSimpan.Location = new Point(29, 476);
            buttonSimpan.Name = "buttonSimpan";
            buttonSimpan.Size = new Size(360, 40);
            buttonSimpan.TabIndex = 13;
            buttonSimpan.Text = "Simpan Data";
            buttonSimpan.UseVisualStyleBackColor = false;
            buttonSimpan.Click += buttonSimpan_Click;
            // 
            // labelTextDeskripsiPengaduan
            // 
            labelTextDeskripsiPengaduan.AutoSize = true;
            labelTextDeskripsiPengaduan.Location = new Point(25, 300);
            labelTextDeskripsiPengaduan.Name = "labelTextDeskripsiPengaduan";
            labelTextDeskripsiPengaduan.Size = new Size(146, 20);
            labelTextDeskripsiPengaduan.TabIndex = 12;
            labelTextDeskripsiPengaduan.Text = "Deskripsi Pengaduan";
            // 
            // labelTextLokasi
            // 
            labelTextLokasi.AutoSize = true;
            labelTextLokasi.Location = new Point(29, 220);
            labelTextLokasi.Name = "labelTextLokasi";
            labelTextLokasi.Size = new Size(50, 20);
            labelTextLokasi.TabIndex = 11;
            labelTextLokasi.Text = "Lokasi";
            // 
            // labelTextKategori
            // 
            labelTextKategori.AutoSize = true;
            labelTextKategori.Location = new Point(25, 140);
            labelTextKategori.Name = "labelTextKategori";
            labelTextKategori.Size = new Size(95, 20);
            labelTextKategori.TabIndex = 10;
            labelTextKategori.Text = "Jenis Fasilitas";
            // 
            // labelTextPrioritas
            // 
            labelTextPrioritas.AutoSize = true;
            labelTextPrioritas.Location = new Point(25, 60);
            labelTextPrioritas.Name = "labelTextPrioritas";
            labelTextPrioritas.Size = new Size(95, 20);
            labelTextPrioritas.TabIndex = 9;
            labelTextPrioritas.Text = "Pilih Prioritas";
            // 
            // labelTextFormKebersihan
            // 
            labelTextFormKebersihan.AutoSize = true;
            labelTextFormKebersihan.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTextFormKebersihan.Location = new Point(21, 14);
            labelTextFormKebersihan.Name = "labelTextFormKebersihan";
            labelTextFormKebersihan.Size = new Size(251, 28);
            labelTextFormKebersihan.TabIndex = 8;
            labelTextFormKebersihan.Text = "Form Pengaduan Fasilitas";
            // 
            // comboBoxJenisFasilitas
            // 
            comboBoxJenisFasilitas.FlatStyle = FlatStyle.Flat;
            comboBoxJenisFasilitas.FormattingEnabled = true;
            comboBoxJenisFasilitas.Location = new Point(29, 176);
            comboBoxJenisFasilitas.Name = "comboBoxJenisFasilitas";
            comboBoxJenisFasilitas.Size = new Size(360, 28);
            comboBoxJenisFasilitas.TabIndex = 7;
            // 
            // richTextBoxDeskripsi
            // 
            richTextBoxDeskripsi.BorderStyle = BorderStyle.None;
            richTextBoxDeskripsi.Location = new Point(29, 336);
            richTextBoxDeskripsi.Name = "richTextBoxDeskripsi";
            richTextBoxDeskripsi.Size = new Size(360, 120);
            richTextBoxDeskripsi.TabIndex = 6;
            richTextBoxDeskripsi.Text = "";
            // 
            // textBoxLokasi
            // 
            textBoxLokasi.BorderStyle = BorderStyle.None;
            textBoxLokasi.Location = new Point(29, 256);
            textBoxLokasi.Name = "textBoxLokasi";
            textBoxLokasi.Size = new Size(360, 20);
            textBoxLokasi.TabIndex = 5;
            // 
            // comboBoxPrioritas
            // 
            comboBoxPrioritas.FlatStyle = FlatStyle.Flat;
            comboBoxPrioritas.FormattingEnabled = true;
            comboBoxPrioritas.Location = new Point(29, 96);
            comboBoxPrioritas.Name = "comboBoxPrioritas";
            comboBoxPrioritas.Size = new Size(360, 28);
            comboBoxPrioritas.TabIndex = 4;
            // 
            // buttonClearForm
            // 
            buttonClearForm.BackColor = SystemColors.Info;
            buttonClearForm.FlatStyle = FlatStyle.Flat;
            buttonClearForm.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonClearForm.ForeColor = SystemColors.ActiveCaptionText;
            buttonClearForm.Location = new Point(348, 476);
            buttonClearForm.Name = "buttonClearForm";
            buttonClearForm.Size = new Size(164, 40);
            buttonClearForm.TabIndex = 11;
            buttonClearForm.Text = "Clear Form";
            buttonClearForm.UseVisualStyleBackColor = false;
            buttonClearForm.Click += buttonClearForm_Click;
            // 
            // buttonHapus
            // 
            buttonHapus.BackColor = Color.Firebrick;
            buttonHapus.FlatStyle = FlatStyle.Flat;
            buttonHapus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonHapus.ForeColor = SystemColors.Control;
            buttonHapus.Location = new Point(126, 476);
            buttonHapus.Name = "buttonHapus";
            buttonHapus.Size = new Size(202, 40);
            buttonHapus.TabIndex = 10;
            buttonHapus.Text = "Hapus Data";
            buttonHapus.UseVisualStyleBackColor = false;
            buttonHapus.Click += buttonHapus_Click;
            // 
            // labelTextDaftarPengaduan
            // 
            labelTextDaftarPengaduan.AutoSize = true;
            labelTextDaftarPengaduan.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTextDaftarPengaduan.Location = new Point(21, 14);
            labelTextDaftarPengaduan.Name = "labelTextDaftarPengaduan";
            labelTextDaftarPengaduan.Size = new Size(264, 28);
            labelTextDaftarPengaduan.TabIndex = 9;
            labelTextDaftarPengaduan.Text = "Daftar Pengaduan Fasilitas";
            // 
            // dataGridViewDataKebersihan
            // 
            dataGridViewDataKebersihan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDataKebersihan.Location = new Point(21, 60);
            dataGridViewDataKebersihan.Name = "dataGridViewDataKebersihan";
            dataGridViewDataKebersihan.RowHeadersWidth = 51;
            dataGridViewDataKebersihan.Size = new Size(491, 396);
            dataGridViewDataKebersihan.TabIndex = 1;
            // 
            // panelContentPengaduan
            // 
            panelContentPengaduan.Controls.Add(buttonClearForm);
            panelContentPengaduan.Controls.Add(buttonHapus);
            panelContentPengaduan.Controls.Add(labelTextDaftarPengaduan);
            panelContentPengaduan.Controls.Add(dataGridViewDataKebersihan);
            panelContentPengaduan.Controls.Add(panelFormKebersihan);
            panelContentPengaduan.Dock = DockStyle.Bottom;
            panelContentPengaduan.Location = new Point(0, 115);
            panelContentPengaduan.Name = "panelContentPengaduan";
            panelContentPengaduan.Size = new Size(948, 558);
            panelContentPengaduan.TabIndex = 1;
            // 
            // panelFormKebersihan
            // 
            panelFormKebersihan.Controls.Add(buttonSimpan);
            panelFormKebersihan.Controls.Add(labelTextDeskripsiPengaduan);
            panelFormKebersihan.Controls.Add(labelTextLokasi);
            panelFormKebersihan.Controls.Add(labelTextKategori);
            panelFormKebersihan.Controls.Add(labelTextPrioritas);
            panelFormKebersihan.Controls.Add(labelTextFormKebersihan);
            panelFormKebersihan.Controls.Add(comboBoxJenisFasilitas);
            panelFormKebersihan.Controls.Add(richTextBoxDeskripsi);
            panelFormKebersihan.Controls.Add(textBoxLokasi);
            panelFormKebersihan.Controls.Add(comboBoxPrioritas);
            panelFormKebersihan.Dock = DockStyle.Right;
            panelFormKebersihan.Location = new Point(531, 0);
            panelFormKebersihan.Name = "panelFormKebersihan";
            panelFormKebersihan.Size = new Size(417, 558);
            panelFormKebersihan.TabIndex = 0;
            // 
            // panelMenuPengaduan
            // 
            panelMenuPengaduan.Controls.Add(panelContentPengaduan);
            panelMenuPengaduan.Dock = DockStyle.Right;
            panelMenuPengaduan.Location = new Point(234, 0);
            panelMenuPengaduan.Name = "panelMenuPengaduan";
            panelMenuPengaduan.Size = new Size(948, 673);
            panelMenuPengaduan.TabIndex = 11;
            // 
            // PengaduanFasilitasForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 673);
            Controls.Add(panelMenuPengaduan);
            Name = "PengaduanFasilitasForm";
            Text = "PengaduanFasilitasForm";
            ((System.ComponentModel.ISupportInitialize)dataGridViewDataKebersihan).EndInit();
            panelContentPengaduan.ResumeLayout(false);
            panelContentPengaduan.PerformLayout();
            panelFormKebersihan.ResumeLayout(false);
            panelFormKebersihan.PerformLayout();
            panelMenuPengaduan.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button buttonSimpan;
        private Label labelTextDeskripsiPengaduan;
        private Label labelTextLokasi;
        private Label labelTextKategori;
        private Label labelTextPrioritas;
        private Label labelTextFormKebersihan;
        private ComboBox comboBoxJenisFasilitas;
        private RichTextBox richTextBoxDeskripsi;
        private TextBox textBoxLokasi;
        private ComboBox comboBoxPrioritas;
        private Button buttonClearForm;
        private Button buttonHapus;
        private Label labelTextDaftarPengaduan;
        private DataGridView dataGridViewDataKebersihan;
        private Panel panelContentPengaduan;
        private Panel panelFormKebersihan;
        private Panel panelMenuPengaduan;
    }
}