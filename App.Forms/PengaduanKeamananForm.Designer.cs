namespace App.Forms
{
    partial class PengaduanKeamananForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button buttonSimpanKeamanan;
        private System.Windows.Forms.Label labelTextDeskripsiPengaduan;
        private System.Windows.Forms.Label labelTextLokasi;
        private System.Windows.Forms.Label labelTextRT;
        private System.Windows.Forms.Label labelTextJenisKejadian;
        private System.Windows.Forms.Label labelTextForm;
        private System.Windows.Forms.TextBox textBoxRT;
        private System.Windows.Forms.TextBox textBoxJenisKejadian;
        private System.Windows.Forms.RichTextBox richTextBoxDeskripsi;
        private System.Windows.Forms.TextBox textBoxLokasi;
        private System.Windows.Forms.Button buttonClearFormKeamanan;
        private System.Windows.Forms.Button buttonHapusKeamanan;
        private System.Windows.Forms.Label labelTextDaftarPengaduan;
        private System.Windows.Forms.DataGridView dataGridViewDataKeamanan;
        private System.Windows.Forms.Panel panelContentPengaduan;
        private System.Windows.Forms.Panel panelFormKeamanan;
        private System.Windows.Forms.Panel panelMenuPengaduan;

        private void InitializeComponent()
        {
            buttonSimpanKeamanan = new System.Windows.Forms.Button();
            labelTextDeskripsiPengaduan = new System.Windows.Forms.Label();
            labelTextLokasi = new System.Windows.Forms.Label();
            labelTextRT = new System.Windows.Forms.Label();
            labelTextJenisKejadian = new System.Windows.Forms.Label();
            labelTextForm = new System.Windows.Forms.Label();
            textBoxRT = new System.Windows.Forms.TextBox();
            textBoxJenisKejadian = new System.Windows.Forms.TextBox();
            richTextBoxDeskripsi = new System.Windows.Forms.RichTextBox();
            textBoxLokasi = new System.Windows.Forms.TextBox();
            buttonClearFormKeamanan = new System.Windows.Forms.Button();
            buttonHapusKeamanan = new System.Windows.Forms.Button();
            labelTextDaftarPengaduan = new System.Windows.Forms.Label();
            dataGridViewDataKeamanan = new System.Windows.Forms.DataGridView();
            panelContentPengaduan = new System.Windows.Forms.Panel();
            panelFormKeamanan = new System.Windows.Forms.Panel();
            panelMenuPengaduan = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDataKeamanan).BeginInit();
            panelContentPengaduan.SuspendLayout();
            panelFormKeamanan.SuspendLayout();
            panelMenuPengaduan.SuspendLayout();
            SuspendLayout();
            // 
            // buttonSimpanKeamanan
            // 
            buttonSimpanKeamanan.BackColor = System.Drawing.SystemColors.Highlight;
            buttonSimpanKeamanan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonSimpanKeamanan.Font = new System.Drawing.Font("Product Sans", 9F, System.Drawing.FontStyle.Bold);
            buttonSimpanKeamanan.ForeColor = System.Drawing.SystemColors.Control;
            buttonSimpanKeamanan.Location = new System.Drawing.Point(29, 476);
            buttonSimpanKeamanan.Name = "buttonSimpanKeamanan";
            buttonSimpanKeamanan.Size = new System.Drawing.Size(360, 40);
            buttonSimpanKeamanan.TabIndex = 13;
            buttonSimpanKeamanan.Text = "Simpan Data";
            buttonSimpanKeamanan.UseVisualStyleBackColor = false;
            buttonSimpanKeamanan.Click += buttonSimpan_Click;
            // 
            // labelTextDeskripsiPengaduan
            // 
            labelTextDeskripsiPengaduan.AutoSize = true;
            labelTextDeskripsiPengaduan.Location = new System.Drawing.Point(25, 300);
            labelTextDeskripsiPengaduan.Name = "labelTextDeskripsiPengaduan";
            labelTextDeskripsiPengaduan.Size = new System.Drawing.Size(146, 20);
            labelTextDeskripsiPengaduan.TabIndex = 12;
            labelTextDeskripsiPengaduan.Text = "Deskripsi Pengaduan";
            // 
            // labelTextLokasi
            // 
            labelTextLokasi.AutoSize = true;
            labelTextLokasi.Location = new System.Drawing.Point(29, 220);
            labelTextLokasi.Name = "labelTextLokasi";
            labelTextLokasi.Size = new System.Drawing.Size(50, 20);
            labelTextLokasi.TabIndex = 11;
            labelTextLokasi.Text = "Lokasi";
            // 
            // labelTextRT
            // 
            labelTextRT.AutoSize = true;
            labelTextRT.Location = new System.Drawing.Point(25, 60);
            labelTextRT.Name = "labelTextRT";
            labelTextRT.Size = new System.Drawing.Size(28, 20);
            labelTextRT.TabIndex = 9;
            labelTextRT.Text = "RT";
            // 
            // labelTextJenisKejadian
            // 
            labelTextJenisKejadian.AutoSize = true;
            labelTextJenisKejadian.Location = new System.Drawing.Point(25, 140);
            labelTextJenisKejadian.Name = "labelTextJenisKejadian";
            labelTextJenisKejadian.Size = new System.Drawing.Size(104, 20);
            labelTextJenisKejadian.TabIndex = 10;
            labelTextJenisKejadian.Text = "Jenis Kejadian";
            // 
            // labelTextForm
            // 
            labelTextForm.AutoSize = true;
            labelTextForm.Font = new System.Drawing.Font("Product Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            labelTextForm.Location = new System.Drawing.Point(21, 14);
            labelTextForm.Name = "labelTextForm";
            labelTextForm.Size = new System.Drawing.Size(260, 25);
            labelTextForm.TabIndex = 8;
            labelTextForm.Text = "Form Pengaduan Keamanan";
            // 
            // textBoxRT
            // 
            textBoxRT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBoxRT.Location = new System.Drawing.Point(29, 96);
            textBoxRT.Name = "textBoxRT";
            textBoxRT.Size = new System.Drawing.Size(360, 20);
            textBoxRT.TabIndex = 4;
            // 
            // textBoxJenisKejadian
            // 
            textBoxJenisKejadian.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBoxJenisKejadian.Location = new System.Drawing.Point(29, 176);
            textBoxJenisKejadian.Name = "textBoxJenisKejadian";
            textBoxJenisKejadian.Size = new System.Drawing.Size(360, 20);
            textBoxJenisKejadian.TabIndex = 7;
            // 
            // richTextBoxDeskripsi
            // 
            richTextBoxDeskripsi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            richTextBoxDeskripsi.Location = new System.Drawing.Point(29, 336);
            richTextBoxDeskripsi.Name = "richTextBoxDeskripsi";
            richTextBoxDeskripsi.Size = new System.Drawing.Size(360, 120);
            richTextBoxDeskripsi.TabIndex = 6;
            richTextBoxDeskripsi.Text = "";
            // 
            // textBoxLokasi
            // 
            textBoxLokasi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBoxLokasi.Location = new System.Drawing.Point(29, 256);
            textBoxLokasi.Name = "textBoxLokasi";
            textBoxLokasi.Size = new System.Drawing.Size(360, 20);
            textBoxLokasi.TabIndex = 5;
            // 
            // buttonClearFormKeamanan
            // 
            buttonClearFormKeamanan.BackColor = System.Drawing.SystemColors.Info;
            buttonClearFormKeamanan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonClearFormKeamanan.Font = new System.Drawing.Font("Product Sans", 9F, System.Drawing.FontStyle.Bold);
            buttonClearFormKeamanan.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            buttonClearFormKeamanan.Location = new System.Drawing.Point(348, 476);
            buttonClearFormKeamanan.Name = "buttonClearFormKeamanan";
            buttonClearFormKeamanan.Size = new System.Drawing.Size(164, 40);
            buttonClearFormKeamanan.TabIndex = 11;
            buttonClearFormKeamanan.Text = "Clear Form";
            buttonClearFormKeamanan.UseVisualStyleBackColor = false;
            buttonClearFormKeamanan.Click += buttonClear_Click;
            // 
            // buttonHapusKeamanan
            // 
            buttonHapusKeamanan.BackColor = System.Drawing.Color.Firebrick;
            buttonHapusKeamanan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonHapusKeamanan.Font = new System.Drawing.Font("Product Sans", 9F, System.Drawing.FontStyle.Bold);
            buttonHapusKeamanan.ForeColor = System.Drawing.SystemColors.Control;
            buttonHapusKeamanan.Location = new System.Drawing.Point(126, 476);
            buttonHapusKeamanan.Name = "buttonHapusKeamanan";
            buttonHapusKeamanan.Size = new System.Drawing.Size(202, 40);
            buttonHapusKeamanan.TabIndex = 10;
            buttonHapusKeamanan.Text = "Hapus Data";
            buttonHapusKeamanan.UseVisualStyleBackColor = false;
            buttonHapusKeamanan.Click += buttonHapus_Click;
            // 
            // labelTextDaftarPengaduan
            // 
            labelTextDaftarPengaduan.AutoSize = true;
            labelTextDaftarPengaduan.Font = new System.Drawing.Font("Product Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            labelTextDaftarPengaduan.Location = new System.Drawing.Point(21, 14);
            labelTextDaftarPengaduan.Name = "labelTextDaftarPengaduan";
            labelTextDaftarPengaduan.Size = new System.Drawing.Size(265, 25);
            labelTextDaftarPengaduan.TabIndex = 9;
            labelTextDaftarPengaduan.Text = "Daftar Pengaduan Keamanan";
            // 
            // dataGridViewDataKeamanan
            // 
            dataGridViewDataKeamanan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDataKeamanan.Location = new System.Drawing.Point(21, 60);
            dataGridViewDataKeamanan.Name = "dataGridViewDataKeamanan";
            dataGridViewDataKeamanan.RowHeadersWidth = 51;
            dataGridViewDataKeamanan.Size = new System.Drawing.Size(491, 396);
            dataGridViewDataKeamanan.TabIndex = 1;
            dataGridViewDataKeamanan.SelectionChanged += dataGridView_SelectionChanged;
            // 
            // panelContentPengaduan
            // 
            panelContentPengaduan.Controls.Add(buttonClearFormKeamanan);
            panelContentPengaduan.Controls.Add(buttonHapusKeamanan);
            panelContentPengaduan.Controls.Add(labelTextDaftarPengaduan);
            panelContentPengaduan.Controls.Add(dataGridViewDataKeamanan);
            panelContentPengaduan.Controls.Add(panelFormKeamanan);
            panelContentPengaduan.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelContentPengaduan.Location = new System.Drawing.Point(0, 115);
            panelContentPengaduan.Name = "panelContentPengaduan";
            panelContentPengaduan.Size = new System.Drawing.Size(948, 558);
            panelContentPengaduan.TabIndex = 1;
            // 
            // panelFormKeamanan
            // 
            panelFormKeamanan.Controls.Add(buttonSimpanKeamanan);
            panelFormKeamanan.Controls.Add(labelTextDeskripsiPengaduan);
            panelFormKeamanan.Controls.Add(labelTextLokasi);
            panelFormKeamanan.Controls.Add(labelTextRT);
            panelFormKeamanan.Controls.Add(labelTextJenisKejadian);
            panelFormKeamanan.Controls.Add(labelTextForm);
            panelFormKeamanan.Controls.Add(textBoxRT);
            panelFormKeamanan.Controls.Add(textBoxJenisKejadian);
            panelFormKeamanan.Controls.Add(richTextBoxDeskripsi);
            panelFormKeamanan.Controls.Add(textBoxLokasi);
            panelFormKeamanan.Dock = System.Windows.Forms.DockStyle.Right;
            panelFormKeamanan.Location = new System.Drawing.Point(531, 0);
            panelFormKeamanan.Name = "panelFormKeamanan";
            panelFormKeamanan.Size = new System.Drawing.Size(417, 558);
            panelFormKeamanan.TabIndex = 0;
            // 
            // panelMenuPengaduan
            // 
            panelMenuPengaduan.Controls.Add(panelContentPengaduan);
            panelMenuPengaduan.Dock = System.Windows.Forms.DockStyle.Right;
            panelMenuPengaduan.Location = new System.Drawing.Point(234, 0);
            panelMenuPengaduan.Name = "panelMenuPengaduan";
            panelMenuPengaduan.Size = new System.Drawing.Size(948, 673);
            panelMenuPengaduan.TabIndex = 11;
            // 
            // PengaduanKeamananForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(panelMenuPengaduan);
            Name = "PengaduanKeamananForm";
            Size = new System.Drawing.Size(1182, 673);
            ((System.ComponentModel.ISupportInitialize)dataGridViewDataKeamanan).EndInit();
            panelContentPengaduan.ResumeLayout(false);
            panelContentPengaduan.PerformLayout();
            panelFormKeamanan.ResumeLayout(false);
            panelFormKeamanan.PerformLayout();
            panelMenuPengaduan.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
} 