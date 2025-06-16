namespace App.Forms
{
    partial class DaftarPengaduan
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
            panelBase = new Panel();
            panelDaftarPengaduan = new Panel();
            panelCounter = new Panel();
            buttonSelesai = new Button();
            buttonDitolak = new Button();
            buttonDiproses = new Button();
            panelContainerFasilitas = new Panel();
            labelFasilitas = new Label();
            counterFasilitas = new Label();
            labelFasilitasTextTotal = new Label();
            panelContainerKeamanan = new Panel();
            labelKeamanan = new Label();
            counterKeamanan = new Label();
            labelKeamananTextTotal = new Label();
            panelContainerKebersihan = new Panel();
            labelKebersihan = new Label();
            counterKebersihan = new Label();
            labelKebersihanTextTotal = new Label();
            labelTextDaftarPengaduan = new Label();
            dataSemuaPengaduanGridView = new DataGridView();
            panelBase.SuspendLayout();
            panelDaftarPengaduan.SuspendLayout();
            panelCounter.SuspendLayout();
            panelContainerFasilitas.SuspendLayout();
            panelContainerKeamanan.SuspendLayout();
            panelContainerKebersihan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataSemuaPengaduanGridView).BeginInit();
            SuspendLayout();
            // 
            // panelBase
            // 
            panelBase.Controls.Add(panelDaftarPengaduan);
            panelBase.Dock = DockStyle.Right;
            panelBase.Location = new Point(236, 0);
            panelBase.Name = "panelBase";
            panelBase.Size = new Size(946, 673);
            panelBase.TabIndex = 0;
            // 
            // panelDaftarPengaduan
            // 
            panelDaftarPengaduan.Controls.Add(panelCounter);
            panelDaftarPengaduan.Controls.Add(labelTextDaftarPengaduan);
            panelDaftarPengaduan.Controls.Add(dataSemuaPengaduanGridView);
            panelDaftarPengaduan.Dock = DockStyle.Right;
            panelDaftarPengaduan.Location = new Point(-2, 0);
            panelDaftarPengaduan.Name = "panelDaftarPengaduan";
            panelDaftarPengaduan.Size = new Size(948, 673);
            panelDaftarPengaduan.TabIndex = 8;
            // 
            // panelCounter
            // 
            panelCounter.Controls.Add(buttonSelesai);
            panelCounter.Controls.Add(buttonDitolak);
            panelCounter.Controls.Add(buttonDiproses);
            panelCounter.Controls.Add(panelContainerFasilitas);
            panelCounter.Controls.Add(panelContainerKeamanan);
            panelCounter.Controls.Add(panelContainerKebersihan);
            panelCounter.Dock = DockStyle.Top;
            panelCounter.Location = new Point(0, 0);
            panelCounter.Name = "panelCounter";
            panelCounter.Size = new Size(948, 207);
            panelCounter.TabIndex = 7;
            // 
            // buttonSelesai
            // 
            buttonSelesai.FlatStyle = FlatStyle.Flat;
            buttonSelesai.Location = new Point(749, 142);
            buttonSelesai.Name = "buttonSelesai";
            buttonSelesai.Size = new Size(94, 29);
            buttonSelesai.TabIndex = 9;
            buttonSelesai.Text = "Selesai";
            buttonSelesai.UseVisualStyleBackColor = true;
            // 
            // buttonDitolak
            // 
            buttonDitolak.FlatStyle = FlatStyle.Flat;
            buttonDitolak.Location = new Point(749, 29);
            buttonDitolak.Name = "buttonDitolak";
            buttonDitolak.Size = new Size(94, 29);
            buttonDitolak.TabIndex = 8;
            buttonDitolak.Text = "Ditolak";
            buttonDitolak.UseVisualStyleBackColor = true;
            // 
            // buttonDiproses
            // 
            buttonDiproses.FlatStyle = FlatStyle.Flat;
            buttonDiproses.Location = new Point(749, 88);
            buttonDiproses.Name = "buttonDiproses";
            buttonDiproses.Size = new Size(94, 29);
            buttonDiproses.TabIndex = 7;
            buttonDiproses.Text = "Diproses";
            buttonDiproses.UseVisualStyleBackColor = true;
            buttonDiproses.Click += button1_Click;
            // 
            // panelContainerFasilitas
            // 
            panelContainerFasilitas.BorderStyle = BorderStyle.FixedSingle;
            panelContainerFasilitas.Controls.Add(labelFasilitas);
            panelContainerFasilitas.Controls.Add(counterFasilitas);
            panelContainerFasilitas.Controls.Add(labelFasilitasTextTotal);
            panelContainerFasilitas.Location = new Point(266, 23);
            panelContainerFasilitas.Name = "panelContainerFasilitas";
            panelContainerFasilitas.Size = new Size(196, 160);
            panelContainerFasilitas.TabIndex = 6;
            // 
            // labelFasilitas
            // 
            labelFasilitas.AutoSize = true;
            labelFasilitas.Font = new Font("Product Sans", 12F);
            labelFasilitas.Location = new Point(10, 122);
            labelFasilitas.Name = "labelFasilitas";
            labelFasilitas.Size = new Size(87, 25);
            labelFasilitas.TabIndex = 2;
            labelFasilitas.Text = "Diproses";
            // 
            // counterFasilitas
            // 
            counterFasilitas.AutoSize = true;
            counterFasilitas.Font = new Font("Product Sans", 35F);
            counterFasilitas.Location = new Point(29, 40);
            counterFasilitas.Name = "counterFasilitas";
            counterFasilitas.Size = new Size(169, 75);
            counterFasilitas.TabIndex = 1;
            counterFasilitas.Text = "1000";
            // 
            // labelFasilitasTextTotal
            // 
            labelFasilitasTextTotal.AutoSize = true;
            labelFasilitasTextTotal.Font = new Font("Product Sans", 12F);
            labelFasilitasTextTotal.Location = new Point(10, 10);
            labelFasilitasTextTotal.Name = "labelFasilitasTextTotal";
            labelFasilitasTextTotal.Size = new Size(53, 25);
            labelFasilitasTextTotal.TabIndex = 0;
            labelFasilitasTextTotal.Text = "Total";
            // 
            // panelContainerKeamanan
            // 
            panelContainerKeamanan.BorderStyle = BorderStyle.FixedSingle;
            panelContainerKeamanan.Controls.Add(labelKeamanan);
            panelContainerKeamanan.Controls.Add(counterKeamanan);
            panelContainerKeamanan.Controls.Add(labelKeamananTextTotal);
            panelContainerKeamanan.Location = new Point(480, 23);
            panelContainerKeamanan.Name = "panelContainerKeamanan";
            panelContainerKeamanan.Size = new Size(196, 160);
            panelContainerKeamanan.TabIndex = 6;
            // 
            // labelKeamanan
            // 
            labelKeamanan.AutoSize = true;
            labelKeamanan.Font = new Font("Product Sans", 12F);
            labelKeamanan.Location = new Point(10, 122);
            labelKeamanan.Name = "labelKeamanan";
            labelKeamanan.Size = new Size(72, 25);
            labelKeamanan.TabIndex = 2;
            labelKeamanan.Text = "Selesai";
            // 
            // counterKeamanan
            // 
            counterKeamanan.AutoSize = true;
            counterKeamanan.Font = new Font("Product Sans", 35F);
            counterKeamanan.Location = new Point(29, 40);
            counterKeamanan.Name = "counterKeamanan";
            counterKeamanan.Size = new Size(169, 75);
            counterKeamanan.TabIndex = 1;
            counterKeamanan.Text = "1000";
            // 
            // labelKeamananTextTotal
            // 
            labelKeamananTextTotal.AutoSize = true;
            labelKeamananTextTotal.Font = new Font("Product Sans", 12F);
            labelKeamananTextTotal.Location = new Point(10, 10);
            labelKeamananTextTotal.Name = "labelKeamananTextTotal";
            labelKeamananTextTotal.Size = new Size(53, 25);
            labelKeamananTextTotal.TabIndex = 0;
            labelKeamananTextTotal.Text = "Total";
            // 
            // panelContainerKebersihan
            // 
            panelContainerKebersihan.BorderStyle = BorderStyle.FixedSingle;
            panelContainerKebersihan.Controls.Add(labelKebersihan);
            panelContainerKebersihan.Controls.Add(counterKebersihan);
            panelContainerKebersihan.Controls.Add(labelKebersihanTextTotal);
            panelContainerKebersihan.Location = new Point(49, 23);
            panelContainerKebersihan.Name = "panelContainerKebersihan";
            panelContainerKebersihan.Size = new Size(196, 160);
            panelContainerKebersihan.TabIndex = 2;
            // 
            // labelKebersihan
            // 
            labelKebersihan.AutoSize = true;
            labelKebersihan.Font = new Font("Product Sans", 12F);
            labelKebersihan.Location = new Point(10, 122);
            labelKebersihan.Name = "labelKebersihan";
            labelKebersihan.Size = new Size(72, 25);
            labelKebersihan.TabIndex = 2;
            labelKebersihan.Text = "Ditolak";
            // 
            // counterKebersihan
            // 
            counterKebersihan.AutoSize = true;
            counterKebersihan.Font = new Font("Product Sans", 35F);
            counterKebersihan.Location = new Point(29, 40);
            counterKebersihan.Name = "counterKebersihan";
            counterKebersihan.Size = new Size(169, 75);
            counterKebersihan.TabIndex = 1;
            counterKebersihan.Text = "1000";
            // 
            // labelKebersihanTextTotal
            // 
            labelKebersihanTextTotal.AutoSize = true;
            labelKebersihanTextTotal.Font = new Font("Product Sans", 12F);
            labelKebersihanTextTotal.Location = new Point(10, 10);
            labelKebersihanTextTotal.Name = "labelKebersihanTextTotal";
            labelKebersihanTextTotal.Size = new Size(53, 25);
            labelKebersihanTextTotal.TabIndex = 0;
            labelKebersihanTextTotal.Text = "Total";
            // 
            // labelTextDaftarPengaduan
            // 
            labelTextDaftarPengaduan.AutoSize = true;
            labelTextDaftarPengaduan.Font = new Font("Product Sans", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTextDaftarPengaduan.Location = new Point(40, 227);
            labelTextDaftarPengaduan.Name = "labelTextDaftarPengaduan";
            labelTextDaftarPengaduan.Size = new Size(241, 25);
            labelTextDaftarPengaduan.TabIndex = 1;
            labelTextDaftarPengaduan.Text = "Daftar Semua Pengaduan";
            labelTextDaftarPengaduan.Click += labelTextDaftarPengaduan_Click;
            // 
            // dataSemuaPengaduanGridView
            // 
            dataSemuaPengaduanGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataSemuaPengaduanGridView.Location = new Point(49, 272);
            dataSemuaPengaduanGridView.Name = "dataSemuaPengaduanGridView";
            dataSemuaPengaduanGridView.RowHeadersWidth = 51;
            dataSemuaPengaduanGridView.Size = new Size(851, 375);
            dataSemuaPengaduanGridView.TabIndex = 0;
            // 
            // DaftarPengaduan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 673);
            Controls.Add(panelBase);
            Name = "DaftarPengaduan";
            Text = "DaftarPengaduan";
            panelBase.ResumeLayout(false);
            panelDaftarPengaduan.ResumeLayout(false);
            panelDaftarPengaduan.PerformLayout();
            panelCounter.ResumeLayout(false);
            panelContainerFasilitas.ResumeLayout(false);
            panelContainerFasilitas.PerformLayout();
            panelContainerKeamanan.ResumeLayout(false);
            panelContainerKeamanan.PerformLayout();
            panelContainerKebersihan.ResumeLayout(false);
            panelContainerKebersihan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataSemuaPengaduanGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelBase;
        private Panel panelDaftarPengaduan;
        private Label labelTextDaftarPengaduan;
        private DataGridView dataSemuaPengaduanGridView;
        private Panel panelCounter;
        private Button buttonSelesai;
        private Button buttonDitolak;
        private Button buttonDiproses;
        private Panel panelContainerFasilitas;
        private Label labelFasilitas;
        private Label counterFasilitas;
        private Label labelFasilitasTextTotal;
        private Panel panelContainerKeamanan;
        private Label labelKeamanan;
        private Label counterKeamanan;
        private Label labelKeamananTextTotal;
        private Panel panelContainerKebersihan;
        private Label labelKebersihan;
        private Label counterKebersihan;
        private Label labelKebersihanTextTotal;
    }
}