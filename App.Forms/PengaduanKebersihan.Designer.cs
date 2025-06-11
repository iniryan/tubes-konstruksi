namespace App.Forms
{
    partial class PengaduanKebersihan
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
            panelContentPengaduan = new Panel();
            buttonClear = new Button();
            buttonDelete = new Button();
            labelTextDaftarPengaduan = new Label();
            dataGridViewDataKebersihan = new DataGridView();
            panelFormKebersihan = new Panel();
            buttonSave = new Button();
            labelTextDeskripsiPengaduan = new Label();
            labelTextLokasi = new Label();
            labelTextKategori = new Label();
            labelTextPrioritas = new Label();
            labelTextFormKebersihan = new Label();
            comboBoxKategori = new ComboBox();
            richTextBoxDeskripsi = new RichTextBox();
            textBoxLokasi = new TextBox();
            comboBoxPrioritas = new ComboBox();
            panelMenuPengaduan = new Panel();
            panelContentPengaduan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDataKebersihan).BeginInit();
            panelFormKebersihan.SuspendLayout();
            panelMenuPengaduan.SuspendLayout();
            SuspendLayout();
            // 
            // panelContentPengaduan
            // 
            panelContentPengaduan.Controls.Add(buttonClear);
            panelContentPengaduan.Controls.Add(buttonDelete);
            panelContentPengaduan.Controls.Add(labelTextDaftarPengaduan);
            panelContentPengaduan.Controls.Add(dataGridViewDataKebersihan);
            panelContentPengaduan.Controls.Add(panelFormKebersihan);
            panelContentPengaduan.Dock = DockStyle.Bottom;
            panelContentPengaduan.Location = new Point(0, 115);
            panelContentPengaduan.Name = "panelContentPengaduan";
            panelContentPengaduan.Size = new Size(948, 558);
            panelContentPengaduan.TabIndex = 1;
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
            // 
            // labelTextDaftarPengaduan
            // 
            labelTextDaftarPengaduan.AutoSize = true;
            labelTextDaftarPengaduan.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTextDaftarPengaduan.Location = new Point(21, 14);
            labelTextDaftarPengaduan.Name = "labelTextDaftarPengaduan";
            labelTextDaftarPengaduan.Size = new Size(294, 28);
            labelTextDaftarPengaduan.TabIndex = 9;
            labelTextDaftarPengaduan.Text = "Daftar Pengaduan Kebersihan";
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
            // panelFormKebersihan
            // 
            panelFormKebersihan.Controls.Add(buttonSave);
            panelFormKebersihan.Controls.Add(labelTextDeskripsiPengaduan);
            panelFormKebersihan.Controls.Add(labelTextLokasi);
            panelFormKebersihan.Controls.Add(labelTextKategori);
            panelFormKebersihan.Controls.Add(labelTextPrioritas);
            panelFormKebersihan.Controls.Add(labelTextFormKebersihan);
            panelFormKebersihan.Controls.Add(comboBoxKategori);
            panelFormKebersihan.Controls.Add(richTextBoxDeskripsi);
            panelFormKebersihan.Controls.Add(textBoxLokasi);
            panelFormKebersihan.Controls.Add(comboBoxPrioritas);
            panelFormKebersihan.Dock = DockStyle.Right;
            panelFormKebersihan.Location = new Point(531, 0);
            panelFormKebersihan.Name = "panelFormKebersihan";
            panelFormKebersihan.Size = new Size(417, 558);
            panelFormKebersihan.TabIndex = 0;
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
            labelTextKategori.Size = new Size(66, 20);
            labelTextKategori.TabIndex = 10;
            labelTextKategori.Text = "Kategori";
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
            labelTextFormKebersihan.Size = new Size(281, 28);
            labelTextFormKebersihan.TabIndex = 8;
            labelTextFormKebersihan.Text = "Form Pengaduan Kebersihan";
            // 
            // comboBoxKategori
            // 
            comboBoxKategori.FlatStyle = FlatStyle.Flat;
            comboBoxKategori.FormattingEnabled = true;
            comboBoxKategori.Location = new Point(29, 176);
            comboBoxKategori.Name = "comboBoxKategori";
            comboBoxKategori.Size = new Size(360, 28);
            comboBoxKategori.TabIndex = 7;
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
            // panelMenuPengaduan
            // 
            panelMenuPengaduan.Controls.Add(panelContentPengaduan);
            panelMenuPengaduan.Dock = DockStyle.Right;
            panelMenuPengaduan.Location = new Point(234, 0);
            panelMenuPengaduan.Name = "panelMenuPengaduan";
            panelMenuPengaduan.Size = new Size(948, 673);
            panelMenuPengaduan.TabIndex = 10;
            // 
            // PengaduanKebersihan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelMenuPengaduan);
            Name = "PengaduanKebersihan";
            Size = new Size(1182, 673);
            panelContentPengaduan.ResumeLayout(false);
            panelContentPengaduan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDataKebersihan).EndInit();
            panelFormKebersihan.ResumeLayout(false);
            panelFormKebersihan.PerformLayout();
            panelMenuPengaduan.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelContentPengaduan;
        private Label labelTextDaftarPengaduan;
        private DataGridView dataGridViewDataKebersihan;
        private Panel panelFormKebersihan;
        private Button buttonSave;
        private Label labelTextDeskripsiPengaduan;
        private Label labelTextLokasi;
        private Label labelTextKategori;
        private Label labelTextPrioritas;
        private Label labelTextFormKebersihan;
        private ComboBox comboBoxKategori;
        private RichTextBox richTextBoxDeskripsi;
        private TextBox textBoxLokasi;
        private ComboBox comboBoxPrioritas;
        private Panel panelMenuPengaduan;
        private Button buttonClear;
        private Button buttonDelete;
    }
}