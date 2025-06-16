namespace App.Forms
{
    partial class CivilianPage
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
            panelMenu = new Panel();
            labelTextPilihTipe = new Label();
            comboBoxTipePengaduan = new ComboBox();
            labelTextMenuPengaduan = new Label();
            panelContent = new Panel();
            panel3 = new Panel();
            logOutBtn = new Button();
            dashboardBtn = new Button();
            panelSidebar = new Panel();
            labelNama = new Label();
            labelJudul = new Label();
            panelBase.SuspendLayout();
            panelMenu.SuspendLayout();
            panel3.SuspendLayout();
            panelSidebar.SuspendLayout();
            SuspendLayout();
            // 
            // panelBase
            // 
            panelBase.Controls.Add(panelMenu);
            panelBase.Controls.Add(panelContent);
            panelBase.Dock = DockStyle.Top;
            panelBase.Location = new Point(0, 0);
            panelBase.Name = "panelBase";
            panelBase.Size = new Size(948, 673);
            panelBase.TabIndex = 3;
            // 
            // panelMenu
            // 
            panelMenu.Controls.Add(labelTextPilihTipe);
            panelMenu.Controls.Add(comboBoxTipePengaduan);
            panelMenu.Controls.Add(labelTextMenuPengaduan);
            panelMenu.Dock = DockStyle.Top;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(948, 116);
            panelMenu.TabIndex = 8;
            // 
            // labelTextPilihTipe
            // 
            labelTextPilihTipe.AutoSize = true;
            labelTextPilihTipe.Location = new Point(46, 44);
            labelTextPilihTipe.Name = "labelTextPilihTipe";
            labelTextPilihTipe.Size = new Size(147, 20);
            labelTextPilihTipe.TabIndex = 6;
            labelTextPilihTipe.Text = "Pilih Tipe Pengaduan";
            // 
            // comboBoxTipePengaduan
            // 
            comboBoxTipePengaduan.FormattingEnabled = true;
            comboBoxTipePengaduan.Location = new Point(50, 75);
            comboBoxTipePengaduan.Name = "comboBoxTipePengaduan";
            comboBoxTipePengaduan.Size = new Size(170, 28);
            comboBoxTipePengaduan.TabIndex = 5;
            // 
            // labelTextMenuPengaduan
            // 
            labelTextMenuPengaduan.AutoSize = true;
            labelTextMenuPengaduan.Font = new Font("Product Sans", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTextMenuPengaduan.Location = new Point(42, 11);
            labelTextMenuPengaduan.Name = "labelTextMenuPengaduan";
            labelTextMenuPengaduan.Size = new Size(167, 25);
            labelTextMenuPengaduan.TabIndex = 4;
            labelTextMenuPengaduan.Text = "Menu Pengaduan";
            // 
            // panelContent
            // 
            panelContent.Dock = DockStyle.Bottom;
            panelContent.Location = new Point(0, 109);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(948, 564);
            panelContent.TabIndex = 7;
            // 
            // panel3
            // 
            panel3.Controls.Add(panelBase);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(234, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(948, 673);
            panel3.TabIndex = 4;
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
            dashboardBtn.Text = "Pengaduan";
            dashboardBtn.TextAlign = ContentAlignment.MiddleLeft;
            dashboardBtn.UseVisualStyleBackColor = false;
            // 
            // panelSidebar
            // 
            panelSidebar.Controls.Add(labelNama);
            panelSidebar.Controls.Add(labelJudul);
            panelSidebar.Controls.Add(logOutBtn);
            panelSidebar.Controls.Add(dashboardBtn);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(234, 673);
            panelSidebar.TabIndex = 3;
            // 
            // labelNama
            // 
            labelNama.Font = new Font("Product Sans", 12F);
            labelNama.Location = new Point(12, 104);
            labelNama.Name = "labelNama";
            labelNama.Size = new Size(161, 55);
            labelNama.TabIndex = 5;
            labelNama.Text = "Selamat datang! Santoso";
            labelNama.Click += label1_Click;
            // 
            // labelJudul
            // 
            labelJudul.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelJudul.Location = new Point(12, 23);
            labelJudul.Name = "labelJudul";
            labelJudul.Size = new Size(189, 74);
            labelJudul.TabIndex = 0;
            labelJudul.Text = "Aplikasi Pengaduan";
            // 
            // CivilianPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 673);
            Controls.Add(panel3);
            Controls.Add(panelSidebar);
            Name = "CivilianPage";
            Text = "CivilianPage";
            panelBase.ResumeLayout(false);
            panelMenu.ResumeLayout(false);
            panelMenu.PerformLayout();
            panel3.ResumeLayout(false);
            panelSidebar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panelBase;
        private Panel panel3;
        private Button logOutBtn;
        private Button dashboardBtn;
        private Panel panelSidebar;
        private Label labelJudul;
        private Label labelNama;
        private Panel panelMenu;
        private Label labelTextPilihTipe;
        private ComboBox comboBoxTipePengaduan;
        private Label labelTextMenuPengaduan;
        private Panel panelContent;
    }
}