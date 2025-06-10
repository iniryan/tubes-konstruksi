namespace App.Forms
{
    partial class LaporanTamu
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
            txtNama = new TextBox();
            txtNomorIdentitas = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtTujuan = new TextBox();
            txtPegawai = new TextBox();
            btnSimpan_Click = new Button();
            label6 = new Label();
            SuspendLayout();
            // 
            // txtNama
            // 
            txtNama.Location = new Point(50, 103);
            txtNama.Name = "txtNama";
            txtNama.Size = new Size(324, 27);
            txtNama.TabIndex = 0;
            txtNama.TextChanged += textBox1_TextChanged;
            // 
            // txtNomorIdentitas
            // 
            txtNomorIdentitas.Location = new Point(50, 183);
            txtNomorIdentitas.Name = "txtNomorIdentitas";
            txtNomorIdentitas.Size = new Size(324, 27);
            txtNomorIdentitas.TabIndex = 1;
            txtNomorIdentitas.TextChanged += textBox2_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(50, 151);
            label1.Name = "label1";
            label1.Size = new Size(117, 20);
            label1.TabIndex = 2;
            label1.Text = "Nomor Identitas";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(50, 80);
            label2.Name = "label2";
            label2.Size = new Size(49, 20);
            label2.TabIndex = 3;
            label2.Text = "Nama";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(407, 131);
            label3.Name = "label3";
            label3.Size = new Size(0, 20);
            label3.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(46, 233);
            label4.Name = "label4";
            label4.Size = new Size(53, 20);
            label4.TabIndex = 5;
            label4.Text = "Tujuan";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(50, 320);
            label5.Name = "label5";
            label5.Size = new Size(64, 20);
            label5.TabIndex = 6;
            label5.Text = "Pegawai";
            // 
            // txtTujuan
            // 
            txtTujuan.Location = new Point(50, 266);
            txtTujuan.Name = "txtTujuan";
            txtTujuan.Size = new Size(324, 27);
            txtTujuan.TabIndex = 7;
            // 
            // txtPegawai
            // 
            txtPegawai.Location = new Point(46, 343);
            txtPegawai.Name = "txtPegawai";
            txtPegawai.Size = new Size(328, 27);
            txtPegawai.TabIndex = 8;
            // 
            // btnSimpan_Click
            // 
            btnSimpan_Click.Location = new Point(46, 416);
            btnSimpan_Click.Name = "btnSimpan_Click";
            btnSimpan_Click.Size = new Size(94, 29);
            btnSimpan_Click.TabIndex = 9;
            btnSimpan_Click.Text = "simpan";
            btnSimpan_Click.UseVisualStyleBackColor = true;
            btnSimpan_Click.Click += button1_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(502, 49);
            label6.Name = "label6";
            label6.Size = new Size(164, 20);
            label6.TabIndex = 10;
            label6.Text = "Halaman Tambah Tamu";
            label6.Click += label6_Click;
            // 
            // LaporanTamu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1099, 498);
            Controls.Add(label6);
            Controls.Add(btnSimpan_Click);
            Controls.Add(txtPegawai);
            Controls.Add(txtTujuan);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtNomorIdentitas);
            Controls.Add(txtNama);
            Name = "LaporanTamu";
            Text = "LaporanTamu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNama;
        private TextBox txtNomorIdentitas;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtTujuan;
        private TextBox txtPegawai;
        private Button btnSimpan_Click;
        private Label label6;
    }
}