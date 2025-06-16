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
            buttonSimpanFasilitas = new Button();
            labelTextDeskripsiPengaduan = new Label();
            labelTextLokasi = new Label();
            labelTextFasilitas = new Label();
            labelTextPrioritas = new Label();
            labelTextForm = new Label();
            comboBoxJenisFasilitas = new ComboBox();
            richTextBoxDeskripsi = new RichTextBox();
            textBoxLokasi = new TextBox();
            comboBoxPrioritas = new ComboBox();
            buttonClearFormFasilitas = new Button();
            buttonHapusFasilitas = new Button();
            labelTextDaftarPengaduan = new Label();
            dataGridViewDataFasilitas = new DataGridView();
            panelContentPengaduan = new Panel();
            panelFormFasilitas = new Panel();
            panelMenuPengaduan = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDataFasilitas).BeginInit();
            panelContentPengaduan.SuspendLayout();
            panelFormFasilitas.SuspendLayout();
            panelMenuPengaduan.SuspendLayout();
            SuspendLayout();
            // 
            // buttonSimpanFasilitas
            // 
            buttonSimpanFasilitas.BackColor = SystemColors.Highlight;
            buttonSimpanFasilitas.FlatStyle = FlatStyle.Flat;
            buttonSimpanFasilitas.Font = new Font("Product Sans", 9F, FontStyle.Bold);
            buttonSimpanFasilitas.ForeColor = SystemColors.Control;
            buttonSimpanFasilitas.Location = new Point(29, 476);
            buttonSimpanFasilitas.Name = "buttonSimpanFasilitas";
            buttonSimpanFasilitas.Size = new Size(360, 40);
            buttonSimpanFasilitas.TabIndex = 13;
            buttonSimpanFasilitas.Text = "Simpan Data";
            buttonSimpanFasilitas.UseVisualStyleBackColor = false;
            buttonSimpanFasilitas.Click += buttonSimpan_Click;
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
            // labelTextFasilitas
            // 
            labelTextFasilitas.AutoSize = true;
            labelTextFasilitas.Location = new Point(25, 140);
            labelTextFasilitas.Name = "labelTextFasilitas";
            labelTextFasilitas.Size = new Size(95, 20);
            labelTextFasilitas.TabIndex = 10;
            labelTextFasilitas.Text = "Jenis Fasilitas";
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
            // labelTextForm
            // 
            labelTextForm.AutoSize = true;
            labelTextForm.Font = new Font("Product Sans", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTextForm.Location = new Point(21, 14);
            labelTextForm.Name = "labelTextForm";
            labelTextForm.Size = new Size(245, 25);
            labelTextForm.TabIndex = 8;
            labelTextForm.Text = "Form Pengaduan Fasilitas";
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
            // buttonClearFormFasilitas
            // 
            buttonClearFormFasilitas.BackColor = SystemColors.Info;
            buttonClearFormFasilitas.FlatStyle = FlatStyle.Flat;
            buttonClearFormFasilitas.Font = new Font("Product Sans", 9F, FontStyle.Bold);
            buttonClearFormFasilitas.ForeColor = SystemColors.ActiveCaptionText;
            buttonClearFormFasilitas.Location = new Point(348, 476);
            buttonClearFormFasilitas.Name = "buttonClearFormFasilitas";
            buttonClearFormFasilitas.Size = new Size(164, 40);
            buttonClearFormFasilitas.TabIndex = 11;
            buttonClearFormFasilitas.Text = "Clear Form";
            buttonClearFormFasilitas.UseVisualStyleBackColor = false;
            buttonClearFormFasilitas.Click += buttonClearForm_Click;
            // 
            // buttonHapusFasilitas
            // 
            buttonHapusFasilitas.BackColor = Color.Firebrick;
            buttonHapusFasilitas.FlatStyle = FlatStyle.Flat;
            buttonHapusFasilitas.Font = new Font("Product Sans", 9F, FontStyle.Bold);
            buttonHapusFasilitas.ForeColor = SystemColors.Control;
            buttonHapusFasilitas.Location = new Point(126, 476);
            buttonHapusFasilitas.Name = "buttonHapusFasilitas";
            buttonHapusFasilitas.Size = new Size(202, 40);
            buttonHapusFasilitas.TabIndex = 10;
            buttonHapusFasilitas.Text = "Hapus Data";
            buttonHapusFasilitas.UseVisualStyleBackColor = false;
            buttonHapusFasilitas.Click += buttonHapus_Click;
            // 
            // labelTextDaftarPengaduan
            // 
            labelTextDaftarPengaduan.AutoSize = true;
            labelTextDaftarPengaduan.Font = new Font("Product Sans", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTextDaftarPengaduan.Location = new Point(21, 14);
            labelTextDaftarPengaduan.Name = "labelTextDaftarPengaduan";
            labelTextDaftarPengaduan.Size = new Size(255, 25);
            labelTextDaftarPengaduan.TabIndex = 9;
            labelTextDaftarPengaduan.Text = "Daftar Pengaduan Fasilitas";
            // 
            // dataGridViewDataFasilitas
            // 
            dataGridViewDataFasilitas.BackgroundColor = SystemColors.Control;
            dataGridViewDataFasilitas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDataFasilitas.Location = new Point(21, 60);
            dataGridViewDataFasilitas.Name = "dataGridViewDataFasilitas";
            dataGridViewDataFasilitas.RowHeadersWidth = 51;
            dataGridViewDataFasilitas.Size = new Size(491, 396);
            dataGridViewDataFasilitas.TabIndex = 1;
            // 
            // panelContentPengaduan
            // 
            panelContentPengaduan.Controls.Add(buttonClearFormFasilitas);
            panelContentPengaduan.Controls.Add(buttonHapusFasilitas);
            panelContentPengaduan.Controls.Add(labelTextDaftarPengaduan);
            panelContentPengaduan.Controls.Add(dataGridViewDataFasilitas);
            panelContentPengaduan.Controls.Add(panelFormFasilitas);
            panelContentPengaduan.Dock = DockStyle.Bottom;
            panelContentPengaduan.Location = new Point(0, 115);
            panelContentPengaduan.Name = "panelContentPengaduan";
            panelContentPengaduan.Size = new Size(948, 558);
            panelContentPengaduan.TabIndex = 1;
            panelContentPengaduan.Paint += panelContentPengaduan_Paint;
            // 
            // panelFormFasilitas
            // 
            panelFormFasilitas.Controls.Add(buttonSimpanFasilitas);
            panelFormFasilitas.Controls.Add(labelTextDeskripsiPengaduan);
            panelFormFasilitas.Controls.Add(labelTextLokasi);
            panelFormFasilitas.Controls.Add(labelTextFasilitas);
            panelFormFasilitas.Controls.Add(labelTextPrioritas);
            panelFormFasilitas.Controls.Add(labelTextForm);
            panelFormFasilitas.Controls.Add(comboBoxJenisFasilitas);
            panelFormFasilitas.Controls.Add(richTextBoxDeskripsi);
            panelFormFasilitas.Controls.Add(textBoxLokasi);
            panelFormFasilitas.Controls.Add(comboBoxPrioritas);
            panelFormFasilitas.Dock = DockStyle.Right;
            panelFormFasilitas.Location = new Point(531, 0);
            panelFormFasilitas.Name = "panelFormFasilitas";
            panelFormFasilitas.Size = new Size(417, 558);
            panelFormFasilitas.TabIndex = 0;
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
            Controls.Add(panelMenuPengaduan);
            Name = "PengaduanFasilitasForm";
            Size = new Size(1182, 673);
            ((System.ComponentModel.ISupportInitialize)dataGridViewDataFasilitas).EndInit();
            panelContentPengaduan.ResumeLayout(false);
            panelContentPengaduan.PerformLayout();
            panelFormFasilitas.ResumeLayout(false);
            panelFormFasilitas.PerformLayout();
            panelMenuPengaduan.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button buttonSimpanFasilitas;
        private Label labelTextDeskripsiPengaduan;
        private Label labelTextLokasi;
        private Label labelTextFasilitas;
        private Label labelTextPrioritas;
        private Label labelTextForm;
        private ComboBox comboBoxJenisFasilitas;
        private RichTextBox richTextBoxDeskripsi;
        private TextBox textBoxLokasi;
        private ComboBox comboBoxPrioritas;
        private Button buttonClearFormFasilitas;
        private Button buttonHapusFasilitas;
        private Label labelTextDaftarPengaduan;
        private DataGridView dataGridViewDataFasilitas;
        private Panel panelContentPengaduan;
        private Panel panelFormFasilitas;
        private Panel panelMenuPengaduan;
    }
}