namespace App.Forms
{
    partial class MenuPengaduan
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
            panelMenuPengaduan = new Panel();
            panelContentPengaduan = new Panel();
            panelMenu = new Panel();
            labelTextPilihTipe = new Label();
            comboBoxTipePengaduan = new ComboBox();
            labelTextMenuPengaduan = new Label();
            panelMenuPengaduan.SuspendLayout();
            panelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenuPengaduan
            // 
            panelMenuPengaduan.Controls.Add(panelContentPengaduan);
            panelMenuPengaduan.Controls.Add(panelMenu);
            panelMenuPengaduan.Dock = DockStyle.Right;
            panelMenuPengaduan.Location = new Point(234, 0);
            panelMenuPengaduan.Name = "panelMenuPengaduan";
            panelMenuPengaduan.Size = new Size(948, 673);
            panelMenuPengaduan.TabIndex = 9;
            // 
            // panelContentPengaduan
            // 
            panelContentPengaduan.Dock = DockStyle.Bottom;
            panelContentPengaduan.Location = new Point(0, 115);
            panelContentPengaduan.Name = "panelContentPengaduan";
            panelContentPengaduan.Size = new Size(948, 558);
            panelContentPengaduan.TabIndex = 3;
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
            panelMenu.TabIndex = 2;
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
            // MenuPengaduan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 673);
            Controls.Add(panelMenuPengaduan);
            Name = "MenuPengaduan";
            Text = "MenuPengaduan";
            panelMenuPengaduan.ResumeLayout(false);
            panelMenu.ResumeLayout(false);
            panelMenu.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMenuPengaduan;
        private Panel panelContentPengaduan;
        private Panel panelMenu;
        private Label labelTextPilihTipe;
        private ComboBox comboBoxTipePengaduan;
        private Label labelTextMenuPengaduan;
    }
}