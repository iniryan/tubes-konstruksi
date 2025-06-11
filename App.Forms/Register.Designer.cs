namespace App.Forms
{
    partial class Register
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
            namaLengkap = new TextBox();
            alamatLengkap = new TextBox();
            noHandphone = new TextBox();
            newUsername = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            newPassword = new TextBox();
            daftarButton = new Button();
            label6 = new Label();
            SuspendLayout();
            // 
            // namaLengkap
            // 
            namaLengkap.Location = new Point(101, 77);
            namaLengkap.Name = "namaLengkap";
            namaLengkap.Size = new Size(255, 27);
            namaLengkap.TabIndex = 0;
            // 
            // alamatLengkap
            // 
            alamatLengkap.Location = new Point(101, 140);
            alamatLengkap.Name = "alamatLengkap";
            alamatLengkap.Size = new Size(255, 27);
            alamatLengkap.TabIndex = 1;
            // 
            // noHandphone
            // 
            noHandphone.Location = new Point(101, 206);
            noHandphone.Name = "noHandphone";
            noHandphone.Size = new Size(255, 27);
            noHandphone.TabIndex = 2;
            // 
            // newUsername
            // 
            newUsername.Location = new Point(101, 274);
            newUsername.Name = "newUsername";
            newUsername.Size = new Size(255, 27);
            newUsername.TabIndex = 3;
            newUsername.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(101, 54);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 4;
            label1.Text = "Nama";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(101, 117);
            label2.Name = "label2";
            label2.Size = new Size(57, 20);
            label2.TabIndex = 5;
            label2.Text = "Alamat";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(101, 183);
            label3.Name = "label3";
            label3.Size = new Size(111, 20);
            label3.TabIndex = 6;
            label3.Text = "No Handphone";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(101, 251);
            label4.Name = "label4";
            label4.Size = new Size(75, 20);
            label4.TabIndex = 7;
            label4.Text = "Username";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(101, 320);
            label5.Name = "label5";
            label5.Size = new Size(78, 20);
            label5.TabIndex = 8;
            label5.Text = "Paassword";
            // 
            // newPassword
            // 
            newPassword.Location = new Point(101, 343);
            newPassword.Name = "newPassword";
            newPassword.Size = new Size(255, 27);
            newPassword.TabIndex = 9;
            // 
            // daftarButton
            // 
            daftarButton.Location = new Point(630, 392);
            daftarButton.Name = "daftarButton";
            daftarButton.Size = new Size(94, 29);
            daftarButton.TabIndex = 10;
            daftarButton.Text = "Daftar";
            daftarButton.UseVisualStyleBackColor = true;
            daftarButton.Click += daftarButton_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(357, 20);
            label6.Name = "label6";
            label6.Size = new Size(88, 20);
            label6.TabIndex = 11;
            label6.Text = "Daftar Akun";
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label6);
            Controls.Add(daftarButton);
            Controls.Add(newPassword);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(newUsername);
            Controls.Add(noHandphone);
            Controls.Add(alamatLengkap);
            Controls.Add(namaLengkap);
            Name = "Register";
            Text = "Register";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox namaLengkap;
        private TextBox alamatLengkap;
        private TextBox noHandphone;
        private TextBox newUsername;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox newPassword;
        private Button daftarButton;
        private Label label6;
    }
}