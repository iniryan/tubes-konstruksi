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
            labelTextDaftarPengaduan = new Label();
            dataSemuaPengaduanGridView = new DataGridView();
            panelBase.SuspendLayout();
            panelDaftarPengaduan.SuspendLayout();
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
            panelDaftarPengaduan.Controls.Add(labelTextDaftarPengaduan);
            panelDaftarPengaduan.Controls.Add(dataSemuaPengaduanGridView);
            panelDaftarPengaduan.Dock = DockStyle.Right;
            panelDaftarPengaduan.Location = new Point(-2, 0);
            panelDaftarPengaduan.Name = "panelDaftarPengaduan";
            panelDaftarPengaduan.Size = new Size(948, 673);
            panelDaftarPengaduan.TabIndex = 8;
            // 
            // labelTextDaftarPengaduan
            // 
            labelTextDaftarPengaduan.AutoSize = true;
            labelTextDaftarPengaduan.Font = new Font("Product Sans", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTextDaftarPengaduan.Location = new Point(42, 11);
            labelTextDaftarPengaduan.Name = "labelTextDaftarPengaduan";
            labelTextDaftarPengaduan.Size = new Size(183, 28);
            labelTextDaftarPengaduan.TabIndex = 1;
            labelTextDaftarPengaduan.Text = "Daftar Pengaduan";
            // 
            // dataSemuaPengaduanGridView
            // 
            dataSemuaPengaduanGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataSemuaPengaduanGridView.Location = new Point(49, 54);
            dataSemuaPengaduanGridView.Name = "dataSemuaPengaduanGridView";
            dataSemuaPengaduanGridView.RowHeadersWidth = 51;
            dataSemuaPengaduanGridView.Size = new Size(851, 530);
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
            ((System.ComponentModel.ISupportInitialize)dataSemuaPengaduanGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelBase;
        private Panel panelDaftarPengaduan;
        private Label labelTextDaftarPengaduan;
        private DataGridView dataSemuaPengaduanGridView;
    }
}