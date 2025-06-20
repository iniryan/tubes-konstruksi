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
            panelContainerDiproses = new Panel();
            labelDiproses = new Label();
            counterDiproses = new Label();
            labelDiprosesTextTotal = new Label();
            panelContainerSelesai = new Panel();
            labelSelesai = new Label();
            counterSelesai = new Label();
            labelSelesaiTextTotal = new Label();
            panelContainerDitolak = new Panel();
            labelDitolak = new Label();
            counterDitolak = new Label();
            labelDitolakTextTotal = new Label();
            labelTextDaftarPengaduan = new Label();
            daftarSemuaPengaduan = new DataGridView();
            panelBase.SuspendLayout();
            panelDaftarPengaduan.SuspendLayout();
            panelCounter.SuspendLayout();
            panelContainerDiproses.SuspendLayout();
            panelContainerSelesai.SuspendLayout();
            panelContainerDitolak.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)daftarSemuaPengaduan).BeginInit();
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
            panelDaftarPengaduan.Controls.Add(daftarSemuaPengaduan);
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
            panelCounter.Controls.Add(panelContainerDiproses);
            panelCounter.Controls.Add(panelContainerSelesai);
            panelCounter.Controls.Add(panelContainerDitolak);
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
            // panelContainerDiproses
            // 
            panelContainerDiproses.BorderStyle = BorderStyle.FixedSingle;
            panelContainerDiproses.Controls.Add(labelDiproses);
            panelContainerDiproses.Controls.Add(counterDiproses);
            panelContainerDiproses.Controls.Add(labelDiprosesTextTotal);
            panelContainerDiproses.Location = new Point(266, 23);
            panelContainerDiproses.Name = "panelContainerDiproses";
            panelContainerDiproses.Size = new Size(196, 160);
            panelContainerDiproses.TabIndex = 6;
            // 
            // labelDiproses
            // 
            labelDiproses.AutoSize = true;
            labelDiproses.Font = new Font("Product Sans", 12F);
            labelDiproses.Location = new Point(10, 122);
            labelDiproses.Name = "labelDiproses";
            labelDiproses.Size = new Size(87, 25);
            labelDiproses.TabIndex = 2;
            labelDiproses.Text = "Diproses";
            // 
            // counterDiproses
            // 
            counterDiproses.AutoSize = true;
            counterDiproses.Font = new Font("Product Sans", 35F);
            counterDiproses.Location = new Point(29, 40);
            counterDiproses.Name = "counterDiproses";
            counterDiproses.Size = new Size(169, 75);
            counterDiproses.TabIndex = 1;
            counterDiproses.Text = "1000";
            // 
            // labelDiprosesTextTotal
            // 
            labelDiprosesTextTotal.AutoSize = true;
            labelDiprosesTextTotal.Font = new Font("Product Sans", 12F);
            labelDiprosesTextTotal.Location = new Point(10, 10);
            labelDiprosesTextTotal.Name = "labelDiprosesTextTotal";
            labelDiprosesTextTotal.Size = new Size(53, 25);
            labelDiprosesTextTotal.TabIndex = 0;
            labelDiprosesTextTotal.Text = "Total";
            // 
            // panelContainerSelesai
            // 
            panelContainerSelesai.BorderStyle = BorderStyle.FixedSingle;
            panelContainerSelesai.Controls.Add(labelSelesai);
            panelContainerSelesai.Controls.Add(counterSelesai);
            panelContainerSelesai.Controls.Add(labelSelesaiTextTotal);
            panelContainerSelesai.Location = new Point(480, 23);
            panelContainerSelesai.Name = "panelContainerSelesai";
            panelContainerSelesai.Size = new Size(196, 160);
            panelContainerSelesai.TabIndex = 6;
            // 
            // labelSelesai
            // 
            labelSelesai.AutoSize = true;
            labelSelesai.Font = new Font("Product Sans", 12F);
            labelSelesai.Location = new Point(10, 122);
            labelSelesai.Name = "labelSelesai";
            labelSelesai.Size = new Size(72, 25);
            labelSelesai.TabIndex = 2;
            labelSelesai.Text = "Selesai";
            // 
            // counterSelesai
            // 
            counterSelesai.AutoSize = true;
            counterSelesai.Font = new Font("Product Sans", 35F);
            counterSelesai.Location = new Point(29, 40);
            counterSelesai.Name = "counterSelesai";
            counterSelesai.Size = new Size(169, 75);
            counterSelesai.TabIndex = 1;
            counterSelesai.Text = "1000";
            // 
            // labelSelesaiTextTotal
            // 
            labelSelesaiTextTotal.AutoSize = true;
            labelSelesaiTextTotal.Font = new Font("Product Sans", 12F);
            labelSelesaiTextTotal.Location = new Point(10, 10);
            labelSelesaiTextTotal.Name = "labelSelesaiTextTotal";
            labelSelesaiTextTotal.Size = new Size(53, 25);
            labelSelesaiTextTotal.TabIndex = 0;
            labelSelesaiTextTotal.Text = "Total";
            // 
            // panelContainerDitolak
            // 
            panelContainerDitolak.BorderStyle = BorderStyle.FixedSingle;
            panelContainerDitolak.Controls.Add(labelDitolak);
            panelContainerDitolak.Controls.Add(counterDitolak);
            panelContainerDitolak.Controls.Add(labelDitolakTextTotal);
            panelContainerDitolak.Location = new Point(49, 23);
            panelContainerDitolak.Name = "panelContainerDitolak";
            panelContainerDitolak.Size = new Size(196, 160);
            panelContainerDitolak.TabIndex = 2;
            // 
            // labelDitolak
            // 
            labelDitolak.AutoSize = true;
            labelDitolak.Font = new Font("Product Sans", 12F);
            labelDitolak.Location = new Point(10, 122);
            labelDitolak.Name = "labelDitolak";
            labelDitolak.Size = new Size(72, 25);
            labelDitolak.TabIndex = 2;
            labelDitolak.Text = "Ditolak";
            // 
            // counterDitolak
            // 
            counterDitolak.AutoSize = true;
            counterDitolak.Font = new Font("Product Sans", 35F);
            counterDitolak.Location = new Point(29, 40);
            counterDitolak.Name = "counterDitolak";
            counterDitolak.Size = new Size(169, 75);
            counterDitolak.TabIndex = 1;
            counterDitolak.Text = "1000";
            // 
            // labelDitolakTextTotal
            // 
            labelDitolakTextTotal.AutoSize = true;
            labelDitolakTextTotal.Font = new Font("Product Sans", 12F);
            labelDitolakTextTotal.Location = new Point(10, 10);
            labelDitolakTextTotal.Name = "labelDitolakTextTotal";
            labelDitolakTextTotal.Size = new Size(53, 25);
            labelDitolakTextTotal.TabIndex = 0;
            labelDitolakTextTotal.Text = "Total";
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
            // daftarSemuaPengaduan
            // 
            daftarSemuaPengaduan.BackgroundColor = SystemColors.Control;
            daftarSemuaPengaduan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            daftarSemuaPengaduan.Location = new Point(49, 272);
            daftarSemuaPengaduan.Name = "daftarSemuaPengaduan";
            daftarSemuaPengaduan.RowHeadersWidth = 51;
            daftarSemuaPengaduan.Size = new Size(851, 375);
            daftarSemuaPengaduan.TabIndex = 0;
            // 
            // DaftarPengaduan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 673);
            Controls.Add(panelBase);
            Name = "DaftarPengaduan";
            panelBase.ResumeLayout(false);
            panelDaftarPengaduan.ResumeLayout(false);
            panelDaftarPengaduan.PerformLayout();
            panelCounter.ResumeLayout(false);
            panelContainerDiproses.ResumeLayout(false);
            panelContainerDiproses.PerformLayout();
            panelContainerSelesai.ResumeLayout(false);
            panelContainerSelesai.PerformLayout();
            panelContainerDitolak.ResumeLayout(false);
            panelContainerDitolak.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)daftarSemuaPengaduan).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelBase;
        private Panel panelDaftarPengaduan;
        private Label labelTextDaftarPengaduan;
        private DataGridView daftarSemuaPengaduan;
        private Panel panelCounter;
        private Button buttonSelesai;
        private Button buttonDitolak;
        private Button buttonDiproses;
        private Panel panelContainerDiproses;
        private Label labelDiproses;
        private Label counterDiproses;
        private Label labelDiprosesTextTotal;
        private Panel panelContainerSelesai;
        private Label labelSelesai;
        private Label counterSelesai;
        private Label labelSelesaiTextTotal;
        private Panel panelContainerDitolak;
        private Label labelDitolak;
        private Label counterDitolak;
        private Label labelDitolakTextTotal;
    }
}