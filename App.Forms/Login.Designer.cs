namespace App.Forms
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            labelTextAplikasiPengaduan = new Label();
            btnLogin = new Button();
            btnRegister = new Button();
            SuspendLayout();
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(426, 271);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(360, 27);
            txtUsername.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(426, 375);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(360, 27);
            txtPassword.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(426, 248);
            label1.Name = "label1";
            label1.Size = new Size(75, 20);
            label1.TabIndex = 3;
            label1.Text = "Username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(426, 352);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 4;
            label2.Text = "Password";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(851, 27);
            label3.Name = "label3";
            label3.Size = new Size(137, 20);
            label3.TabIndex = 5;
            label3.Text = "Belum punya akun?";
            // 
            // labelTextAplikasiPengaduan
            // 
            labelTextAplikasiPengaduan.AutoSize = true;
            labelTextAplikasiPengaduan.Font = new Font("Product Sans", 16.2F, FontStyle.Bold);
            labelTextAplikasiPengaduan.Location = new Point(24, 21);
            labelTextAplikasiPengaduan.Name = "labelTextAplikasiPengaduan";
            labelTextAplikasiPengaduan.Size = new Size(343, 36);
            labelTextAplikasiPengaduan.TabIndex = 7;
            labelTextAplikasiPengaduan.Text = "Login Aplikasi Pengaduan";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = SystemColors.Highlight;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Product Sans", 9F, FontStyle.Bold);
            btnLogin.ForeColor = SystemColors.Control;
            btnLogin.Location = new Point(426, 465);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(360, 40);
            btnLogin.TabIndex = 14;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = SystemColors.Highlight;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Product Sans", 9F, FontStyle.Bold);
            btnRegister.ForeColor = SystemColors.Control;
            btnRegister.Location = new Point(1009, 17);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(132, 40);
            btnRegister.TabIndex = 15;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = false;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 673);
            Controls.Add(btnRegister);
            Controls.Add(btnLogin);
            Controls.Add(labelTextAplikasiPengaduan);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Name = "Login";
            Text = "Login Form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnRegister;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label labelTextAplikasiPengaduan;
    }
}
