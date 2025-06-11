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
            label6 = new Label();
            btnLogin = new Button();
            daftarButton = new Button();
            label7 = new Label();
            SuspendLayout();
            // 
            // namaLengkap
            // 
            namaLengkap.Location = new Point(438, 149);
            namaLengkap.Name = "namaLengkap";
            namaLengkap.Size = new Size(360, 27);
            namaLengkap.TabIndex = 0;
            // 
            // alamatLengkap
            // 
            alamatLengkap.Location = new Point(438, 222);
            alamatLengkap.Name = "alamatLengkap";
            alamatLengkap.Size = new Size(360, 27);
            alamatLengkap.TabIndex = 1;
            // 
            // noHandphone
            // 
            noHandphone.Location = new Point(438, 302);
            noHandphone.Name = "noHandphone";
            noHandphone.Size = new Size(360, 27);
            noHandphone.TabIndex = 2;
            // 
            // newUsername
            // 
            newUsername.Location = new Point(438, 377);
            newUsername.Name = "newUsername";
            newUsername.Size = new Size(360, 27);
            newUsername.TabIndex = 3;
            newUsername.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(438, 126);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 4;
            label1.Text = "Nama";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(438, 199);
            label2.Name = "label2";
            label2.Size = new Size(57, 20);
            label2.TabIndex = 5;
            label2.Text = "Alamat";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(438, 279);
            label3.Name = "label3";
            label3.Size = new Size(111, 20);
            label3.TabIndex = 6;
            label3.Text = "No Handphone";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(438, 354);
            label4.Name = "label4";
            label4.Size = new Size(75, 20);
            label4.TabIndex = 7;
            label4.Text = "Username";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(438, 423);
            label5.Name = "label5";
            label5.Size = new Size(78, 20);
            label5.TabIndex = 8;
            label5.Text = "Paassword";
            // 
            // newPassword
            // 
            newPassword.Location = new Point(438, 446);
            newPassword.Name = "newPassword";
            newPassword.Size = new Size(360, 27);
            newPassword.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Product Sans", 16.2F, FontStyle.Bold);
            label6.Location = new Point(60, 26);
            label6.Name = "label6";
            label6.Size = new Size(168, 36);
            label6.TabIndex = 11;
            label6.Text = "Daftar Akun";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = SystemColors.Highlight;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLogin.ForeColor = SystemColors.Control;
            btnLogin.Location = new Point(1010, 22);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(132, 40);
            btnLogin.TabIndex = 17;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            // 
            // daftarButton
            // 
            daftarButton.BackColor = SystemColors.Highlight;
            daftarButton.FlatStyle = FlatStyle.Flat;
            daftarButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            daftarButton.ForeColor = SystemColors.Control;
            daftarButton.Location = new Point(438, 499);
            daftarButton.Name = "daftarButton";
            daftarButton.Size = new Size(360, 40);
            daftarButton.TabIndex = 16;
            daftarButton.Text = "Daftar";
            daftarButton.UseVisualStyleBackColor = false;
            daftarButton.Click += daftarButton_Click_1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(854, 32);
            label7.Name = "label7";
            label7.Size = new Size(136, 20);
            label7.TabIndex = 18;
            label7.Text = "Sudah punya akun?";
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 673);
            Controls.Add(label7);
            Controls.Add(btnLogin);
            Controls.Add(daftarButton);
            Controls.Add(label6);
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
        private Label label6;
        private Button btnLogin;
        private Button daftarButton;
        private Label label7;
    }
}