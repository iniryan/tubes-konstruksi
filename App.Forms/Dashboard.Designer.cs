namespace App.Forms
{
    partial class Dashboard
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
            labelJudul = new Label();
            panelSidebar = new Panel();
            button1 = new Button();
            logOutBtn = new Button();
            menuPengaduanBtn = new Button();
            menuPenggunaBtn = new Button();
            daftarPengaduanBtn = new Button();
            dashboardBtn = new Button();
            panel3 = new Panel();
            panelBase = new Panel();
            panelCounter = new Panel();
            panelContainerLapTamu = new Panel();
            labelLapTamu = new Label();
            counterTamu = new Label();
            labelLapTamuTextTotal = new Label();
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
            panelContent = new Panel();
            labelTextPengaduanTerbaru = new Label();
            dataPengaduanTerbaruGridView = new DataGridView();
            panelSidebar.SuspendLayout();
            panel3.SuspendLayout();
            panelBase.SuspendLayout();
            panelCounter.SuspendLayout();
            panelContainerLapTamu.SuspendLayout();
            panelContainerFasilitas.SuspendLayout();
            panelContainerKeamanan.SuspendLayout();
            panelContainerKebersihan.SuspendLayout();
            panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataPengaduanTerbaruGridView).BeginInit();
            SuspendLayout();
            // 
            // labelJudul
            // 
            labelJudul.Font = new Font("Product Sans", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelJudul.Location = new Point(12, 23);
            labelJudul.Name = "labelJudul";
            labelJudul.Size = new Size(189, 74);
            labelJudul.TabIndex = 0;
            labelJudul.Text = "Aplikasi Pengaduan";
            // 
            // panelSidebar
            // 
            panelSidebar.Controls.Add(button1);
            panelSidebar.Controls.Add(labelJudul);
            panelSidebar.Controls.Add(logOutBtn);
            panelSidebar.Controls.Add(menuPengaduanBtn);
            panelSidebar.Controls.Add(menuPenggunaBtn);
            panelSidebar.Controls.Add(daftarPengaduanBtn);
            panelSidebar.Controls.Add(dashboardBtn);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(234, 673);
            panelSidebar.TabIndex = 1;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Product Sans", 10.2F);
            button1.Location = new Point(12, 370);
            button1.Name = "button1";
            button1.Size = new Size(200, 40);
            button1.TabIndex = 5;
            button1.Text = "Laporan Tamu";
            button1.TextAlign = ContentAlignment.MiddleLeft;
            button1.UseVisualStyleBackColor = true;
            // 
            // logOutBtn
            // 
            logOutBtn.FlatAppearance.BorderSize = 0;
            logOutBtn.FlatStyle = FlatStyle.Flat;
            logOutBtn.Font = new Font("Product Sans", 10.2F);
            logOutBtn.Location = new Point(12, 544);
            logOutBtn.Name = "logOutBtn";
            logOutBtn.Size = new Size(200, 40);
            logOutBtn.TabIndex = 4;
            logOutBtn.Text = "Log Out";
            logOutBtn.TextAlign = ContentAlignment.MiddleLeft;
            logOutBtn.UseVisualStyleBackColor = true;
            logOutBtn.Click += logOutBtn_Click;
            // 
            // menuPengaduanBtn
            // 
            menuPengaduanBtn.FlatAppearance.BorderSize = 0;
            menuPengaduanBtn.FlatStyle = FlatStyle.Flat;
            menuPengaduanBtn.Font = new Font("Product Sans", 10.2F);
            menuPengaduanBtn.Location = new Point(12, 278);
            menuPengaduanBtn.Name = "menuPengaduanBtn";
            menuPengaduanBtn.Size = new Size(200, 40);
            menuPengaduanBtn.TabIndex = 3;
            menuPengaduanBtn.Text = "Menu Pengaduan";
            menuPengaduanBtn.TextAlign = ContentAlignment.MiddleLeft;
            menuPengaduanBtn.UseVisualStyleBackColor = true;
            menuPengaduanBtn.Click += menuPengaduanBtn_Click;
            // 
            // menuPenggunaBtn
            // 
            menuPenggunaBtn.FlatAppearance.BorderSize = 0;
            menuPenggunaBtn.FlatStyle = FlatStyle.Flat;
            menuPenggunaBtn.Font = new Font("Product Sans", 10.2F);
            menuPenggunaBtn.Location = new Point(12, 324);
            menuPenggunaBtn.Name = "menuPenggunaBtn";
            menuPenggunaBtn.Size = new Size(200, 40);
            menuPenggunaBtn.TabIndex = 2;
            menuPenggunaBtn.Text = "Manajemen Pengguna";
            menuPenggunaBtn.TextAlign = ContentAlignment.MiddleLeft;
            menuPenggunaBtn.UseVisualStyleBackColor = true;
            // 
            // daftarPengaduanBtn
            // 
            daftarPengaduanBtn.FlatAppearance.BorderSize = 0;
            daftarPengaduanBtn.FlatStyle = FlatStyle.Flat;
            daftarPengaduanBtn.Font = new Font("Product Sans", 10.2F);
            daftarPengaduanBtn.Location = new Point(12, 232);
            daftarPengaduanBtn.Name = "daftarPengaduanBtn";
            daftarPengaduanBtn.Size = new Size(200, 40);
            daftarPengaduanBtn.TabIndex = 1;
            daftarPengaduanBtn.Text = "Daftar Pengaduan";
            daftarPengaduanBtn.TextAlign = ContentAlignment.MiddleLeft;
            daftarPengaduanBtn.UseVisualStyleBackColor = true;
            // 
            // dashboardBtn
            // 
            dashboardBtn.BackColor = SystemColors.Control;
            dashboardBtn.FlatAppearance.BorderSize = 0;
            dashboardBtn.FlatStyle = FlatStyle.Flat;
            dashboardBtn.Font = new Font("Product Sans", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dashboardBtn.Location = new Point(12, 186);
            dashboardBtn.Name = "dashboardBtn";
            dashboardBtn.Size = new Size(200, 40);
            dashboardBtn.TabIndex = 0;
            dashboardBtn.Text = "Dashboard";
            dashboardBtn.TextAlign = ContentAlignment.MiddleLeft;
            dashboardBtn.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            panel3.Controls.Add(panelBase);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(234, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(948, 673);
            panel3.TabIndex = 2;
            // 
            // panelBase
            // 
            panelBase.Controls.Add(panelCounter);
            panelBase.Controls.Add(panelContent);
            panelBase.Dock = DockStyle.Top;
            panelBase.Location = new Point(0, 0);
            panelBase.Name = "panelBase";
            panelBase.Size = new Size(948, 673);
            panelBase.TabIndex = 3;
            // 
            // panelCounter
            // 
            panelCounter.Controls.Add(panelContainerLapTamu);
            panelCounter.Controls.Add(panelContainerFasilitas);
            panelCounter.Controls.Add(panelContainerKeamanan);
            panelCounter.Controls.Add(panelContainerKebersihan);
            panelCounter.Dock = DockStyle.Top;
            panelCounter.Location = new Point(0, 0);
            panelCounter.Name = "panelCounter";
            panelCounter.Size = new Size(948, 207);
            panelCounter.TabIndex = 6;
            // 
            // panelContainerLapTamu
            // 
            panelContainerLapTamu.BorderStyle = BorderStyle.FixedSingle;
            panelContainerLapTamu.Controls.Add(labelLapTamu);
            panelContainerLapTamu.Controls.Add(counterTamu);
            panelContainerLapTamu.Controls.Add(labelLapTamuTextTotal);
            panelContainerLapTamu.Location = new Point(704, 23);
            panelContainerLapTamu.Name = "panelContainerLapTamu";
            panelContainerLapTamu.Size = new Size(196, 160);
            panelContainerLapTamu.TabIndex = 6;
            // 
            // labelLapTamu
            // 
            labelLapTamu.AutoSize = true;
            labelLapTamu.Font = new Font("Product Sans", 12F);
            labelLapTamu.Location = new Point(10, 122);
            labelLapTamu.Name = "labelLapTamu";
            labelLapTamu.Size = new Size(134, 28);
            labelLapTamu.TabIndex = 2;
            labelLapTamu.Text = "Laporan Tamu";
            // 
            // counterTamu
            // 
            counterTamu.AutoSize = true;
            counterTamu.Font = new Font("Product Sans", 35F);
            counterTamu.Location = new Point(29, 40);
            counterTamu.Name = "counterTamu";
            counterTamu.Size = new Size(161, 78);
            counterTamu.TabIndex = 1;
            counterTamu.Text = "1000";
            // 
            // labelLapTamuTextTotal
            // 
            labelLapTamuTextTotal.AutoSize = true;
            labelLapTamuTextTotal.Font = new Font("Product Sans", 12F);
            labelLapTamuTextTotal.Location = new Point(10, 10);
            labelLapTamuTextTotal.Name = "labelLapTamuTextTotal";
            labelLapTamuTextTotal.Size = new Size(54, 28);
            labelLapTamuTextTotal.TabIndex = 0;
            labelLapTamuTextTotal.Text = "Total";
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
            labelFasilitas.Size = new Size(79, 28);
            labelFasilitas.TabIndex = 2;
            labelFasilitas.Text = "Fasilitas";
            // 
            // counterFasilitas
            // 
            counterFasilitas.AutoSize = true;
            counterFasilitas.Font = new Font("Product Sans", 35F);
            counterFasilitas.Location = new Point(29, 40);
            counterFasilitas.Name = "counterFasilitas";
            counterFasilitas.Size = new Size(161, 78);
            counterFasilitas.TabIndex = 1;
            counterFasilitas.Text = "1000";
            // 
            // labelFasilitasTextTotal
            // 
            labelFasilitasTextTotal.AutoSize = true;
            labelFasilitasTextTotal.Font = new Font("Product Sans", 12F);
            labelFasilitasTextTotal.Location = new Point(10, 10);
            labelFasilitasTextTotal.Name = "labelFasilitasTextTotal";
            labelFasilitasTextTotal.Size = new Size(54, 28);
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
            labelKeamanan.Size = new Size(103, 28);
            labelKeamanan.TabIndex = 2;
            labelKeamanan.Text = "Keamanan";
            // 
            // counterKeamanan
            // 
            counterKeamanan.AutoSize = true;
            counterKeamanan.Font = new Font("Product Sans", 35F);
            counterKeamanan.Location = new Point(29, 40);
            counterKeamanan.Name = "counterKeamanan";
            counterKeamanan.Size = new Size(161, 78);
            counterKeamanan.TabIndex = 1;
            counterKeamanan.Text = "1000";
            // 
            // labelKeamananTextTotal
            // 
            labelKeamananTextTotal.AutoSize = true;
            labelKeamananTextTotal.Font = new Font("Product Sans", 12F);
            labelKeamananTextTotal.Location = new Point(10, 10);
            labelKeamananTextTotal.Name = "labelKeamananTextTotal";
            labelKeamananTextTotal.Size = new Size(54, 28);
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
            labelKebersihan.Size = new Size(108, 28);
            labelKebersihan.TabIndex = 2;
            labelKebersihan.Text = "Kebersihan";
            // 
            // counterKebersihan
            // 
            counterKebersihan.AutoSize = true;
            counterKebersihan.Font = new Font("Product Sans", 35F);
            counterKebersihan.Location = new Point(29, 40);
            counterKebersihan.Name = "counterKebersihan";
            counterKebersihan.Size = new Size(161, 78);
            counterKebersihan.TabIndex = 1;
            counterKebersihan.Text = "1000";
            // 
            // labelKebersihanTextTotal
            // 
            labelKebersihanTextTotal.AutoSize = true;
            labelKebersihanTextTotal.Font = new Font("Product Sans", 12F);
            labelKebersihanTextTotal.Location = new Point(10, 10);
            labelKebersihanTextTotal.Name = "labelKebersihanTextTotal";
            labelKebersihanTextTotal.Size = new Size(54, 28);
            labelKebersihanTextTotal.TabIndex = 0;
            labelKebersihanTextTotal.Text = "Total";
            // 
            // panelContent
            // 
            panelContent.Controls.Add(labelTextPengaduanTerbaru);
            panelContent.Controls.Add(dataPengaduanTerbaruGridView);
            panelContent.Dock = DockStyle.Bottom;
            panelContent.Location = new Point(0, 205);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(948, 468);
            panelContent.TabIndex = 5;
            // 
            // labelTextPengaduanTerbaru
            // 
            labelTextPengaduanTerbaru.AutoSize = true;
            labelTextPengaduanTerbaru.Font = new Font("Product Sans", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTextPengaduanTerbaru.Location = new Point(44, 13);
            labelTextPengaduanTerbaru.Name = "labelTextPengaduanTerbaru";
            labelTextPengaduanTerbaru.Size = new Size(194, 28);
            labelTextPengaduanTerbaru.TabIndex = 1;
            labelTextPengaduanTerbaru.Text = "Pengaduan Terbaru";
            // 
            // dataPengaduanTerbaruGridView
            // 
            dataPengaduanTerbaruGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataPengaduanTerbaruGridView.Location = new Point(49, 54);
            dataPengaduanTerbaruGridView.Name = "dataPengaduanTerbaruGridView";
            dataPengaduanTerbaruGridView.RowHeadersWidth = 51;
            dataPengaduanTerbaruGridView.Size = new Size(851, 290);
            dataPengaduanTerbaruGridView.TabIndex = 0;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 673);
            Controls.Add(panel3);
            Controls.Add(panelSidebar);
            Name = "Dashboard";
            Text = "Dashboard";
            panelSidebar.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panelBase.ResumeLayout(false);
            panelCounter.ResumeLayout(false);
            panelContainerLapTamu.ResumeLayout(false);
            panelContainerLapTamu.PerformLayout();
            panelContainerFasilitas.ResumeLayout(false);
            panelContainerFasilitas.PerformLayout();
            panelContainerKeamanan.ResumeLayout(false);
            panelContainerKeamanan.PerformLayout();
            panelContainerKebersihan.ResumeLayout(false);
            panelContainerKebersihan.PerformLayout();
            panelContent.ResumeLayout(false);
            panelContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataPengaduanTerbaruGridView).EndInit();
            ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label labelJudul;
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button logOutBtn;
        private System.Windows.Forms.Button menuPengaduanBtn;
        private System.Windows.Forms.Button menuPenggunaBtn;
        private System.Windows.Forms.Button daftarPengaduanBtn;
        private System.Windows.Forms.Button dashboardBtn;
        private Panel panelBase;
        private Panel panelCounter;
        private Panel panelContainerLapTamu;
        private Label labelLapTamu;
        private Label counterTamu;
        private Label labelLapTamuTextTotal;
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
        private Panel panelContent;
        private Label labelTextPengaduanTerbaru;
        private DataGridView dataPengaduanTerbaruGridView;
        private Button button1;
    }
}
