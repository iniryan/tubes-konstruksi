namespace App.Forms
{
    partial class Pengguna
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
            panelMenuPengguna = new Panel();
            labelTextDaftarPengguna = new Label();
            daftarPengguna = new DataGridView();
            panelMenuPengguna.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)daftarPengguna).BeginInit();
            SuspendLayout();
            // 
            // panelMenuPengguna
            // 
            panelMenuPengguna.Controls.Add(labelTextDaftarPengguna);
            panelMenuPengguna.Controls.Add(daftarPengguna);
            panelMenuPengguna.Dock = DockStyle.Right;
            panelMenuPengguna.Location = new Point(234, 0);
            panelMenuPengguna.Name = "panelMenuPengguna";
            panelMenuPengguna.Size = new Size(948, 673);
            panelMenuPengguna.TabIndex = 9;
            //            // labelTextDaftarPengguna
            // 
            labelTextDaftarPengguna.AutoSize = true;
            labelTextDaftarPengguna.Font = new Font("Product Sans", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTextDaftarPengguna.Location = new Point(33, 27);
            labelTextDaftarPengguna.Name = "labelTextDaftarPengguna";
            labelTextDaftarPengguna.Size = new Size(215, 25);
            labelTextDaftarPengguna.TabIndex = 1;
            labelTextDaftarPengguna.Text = "Daftar Semua Pengguna";
            // 
            // daftarPengguna
            // 
            daftarPengguna.BackgroundColor = SystemColors.Control;
            daftarPengguna.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            daftarPengguna.Location = new Point(42, 72);
            daftarPengguna.Name = "daftarPengguna";
            daftarPengguna.RowHeadersWidth = 51;
            daftarPengguna.Size = new Size(851, 574);
            daftarPengguna.TabIndex = 0;
            // 
            // Pengguna
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 673);
            Controls.Add(panelMenuPengguna);
            Name = "Pengguna";
            Text = "Pengguna";
            panelMenuPengguna.ResumeLayout(false);
            panelMenuPengguna.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)daftarPengguna).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMenuPengguna;
        private Label labelTextDaftarPengguna;
        private DataGridView daftarPengguna;
    }
}