
namespace ProjectFinal
{
    partial class Sign_In
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sign_In));
            this.buttonclose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.forgetpass = new System.Windows.Forms.Label();
            this.buttonnewacount = new System.Windows.Forms.Button();
            this.labelcheckpass = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.buttonlogin = new System.Windows.Forms.Button();
            this.textBoxuser = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonclose
            // 
            this.buttonclose.BackColor = System.Drawing.Color.Crimson;
            this.buttonclose.FlatAppearance.BorderSize = 0;
            this.buttonclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonclose.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonclose.ForeColor = System.Drawing.Color.Transparent;
            this.buttonclose.Location = new System.Drawing.Point(783, 13);
            this.buttonclose.Name = "buttonclose";
            this.buttonclose.Size = new System.Drawing.Size(76, 41);
            this.buttonclose.TabIndex = 18;
            this.buttonclose.Text = "X";
            this.buttonclose.UseVisualStyleBackColor = false;
            this.buttonclose.Click += new System.EventHandler(this.buttonclose_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.forgetpass);
            this.panel1.Controls.Add(this.buttonnewacount);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Controls.Add(this.labelcheckpass);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.txtpassword);
            this.panel1.Controls.Add(this.pictureBox6);
            this.panel1.Controls.Add(this.buttonlogin);
            this.panel1.Controls.Add(this.textBoxuser);
            this.panel1.Location = new System.Drawing.Point(12, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(847, 801);
            this.panel1.TabIndex = 17;
            // 
            // forgetpass
            // 
            this.forgetpass.AutoSize = true;
            this.forgetpass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.forgetpass.Font = new System.Drawing.Font("FC Iconic", 16.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.forgetpass.Location = new System.Drawing.Point(596, 643);
            this.forgetpass.Name = "forgetpass";
            this.forgetpass.Size = new System.Drawing.Size(124, 28);
            this.forgetpass.TabIndex = 15;
            this.forgetpass.Text = "ลืมรหัสผ่าน ?";
            this.forgetpass.Click += new System.EventHandler(this.forgetpass_Click);
            // 
            // buttonnewacount
            // 
            this.buttonnewacount.BackColor = System.Drawing.Color.MediumTurquoise;
            this.buttonnewacount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonnewacount.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonnewacount.FlatAppearance.BorderSize = 0;
            this.buttonnewacount.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleVioletRed;
            this.buttonnewacount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonnewacount.Font = new System.Drawing.Font("FC Daisy", 22.8F);
            this.buttonnewacount.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonnewacount.Location = new System.Drawing.Point(513, 725);
            this.buttonnewacount.Name = "buttonnewacount";
            this.buttonnewacount.Size = new System.Drawing.Size(319, 57);
            this.buttonnewacount.TabIndex = 9;
            this.buttonnewacount.Text = "สมัครสมาชิกที่นี่";
            this.buttonnewacount.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonnewacount.UseVisualStyleBackColor = false;
            this.buttonnewacount.Click += new System.EventHandler(this.buttonnewacount_Click);
            // 
            // labelcheckpass
            // 
            this.labelcheckpass.AutoSize = true;
            this.labelcheckpass.BackColor = System.Drawing.SystemColors.Window;
            this.labelcheckpass.Font = new System.Drawing.Font("FC Iconic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelcheckpass.ForeColor = System.Drawing.Color.Crimson;
            this.labelcheckpass.Location = new System.Drawing.Point(280, 505);
            this.labelcheckpass.Name = "labelcheckpass";
            this.labelcheckpass.Size = new System.Drawing.Size(0, 28);
            this.labelcheckpass.TabIndex = 14;
            this.labelcheckpass.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.SystemColors.Window;
            this.checkBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBox1.Font = new System.Drawing.Font("FC Home", 14F);
            this.checkBox1.Location = new System.Drawing.Point(666, 450);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(148, 30);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "แสดงรหัสผ่าน";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // txtpassword
            // 
            this.txtpassword.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtpassword.BackColor = System.Drawing.Color.AliceBlue;
            this.txtpassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtpassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtpassword.Font = new System.Drawing.Font("FC Iconic", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpassword.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtpassword.Location = new System.Drawing.Point(177, 442);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.Size = new System.Drawing.Size(479, 42);
            this.txtpassword.TabIndex = 8;
            this.txtpassword.TabStop = false;
            this.txtpassword.Text = "รหัสผ่าน";
            this.txtpassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtpassword.TextChanged += new System.EventHandler(this.txtpassword_TextChanged);
            this.txtpassword.Enter += new System.EventHandler(this.txtpassword_Enter);
            this.txtpassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtpassword_KeyDown);
            this.txtpassword.Leave += new System.EventHandler(this.txtpassword_Leave);
            // 
            // buttonlogin
            // 
            this.buttonlogin.BackColor = System.Drawing.Color.Crimson;
            this.buttonlogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonlogin.FlatAppearance.BorderSize = 0;
            this.buttonlogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PaleVioletRed;
            this.buttonlogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleVioletRed;
            this.buttonlogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonlogin.Font = new System.Drawing.Font("FC Daisy", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonlogin.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonlogin.Location = new System.Drawing.Point(274, 613);
            this.buttonlogin.Name = "buttonlogin";
            this.buttonlogin.Size = new System.Drawing.Size(307, 70);
            this.buttonlogin.TabIndex = 7;
            this.buttonlogin.Text = "เข้าสู่ระบบ";
            this.buttonlogin.UseVisualStyleBackColor = false;
            this.buttonlogin.Click += new System.EventHandler(this.buttonlogin_Click);
            // 
            // textBoxuser
            // 
            this.textBoxuser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxuser.BackColor = System.Drawing.Color.AliceBlue;
            this.textBoxuser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxuser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBoxuser.Font = new System.Drawing.Font("FC Iconic", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxuser.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBoxuser.Location = new System.Drawing.Point(177, 367);
            this.textBoxuser.Name = "textBoxuser";
            this.textBoxuser.Size = new System.Drawing.Size(479, 42);
            this.textBoxuser.TabIndex = 3;
            this.textBoxuser.TabStop = false;
            this.textBoxuser.Text = "บัญชีผู้ใช้";
            this.textBoxuser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxuser.Enter += new System.EventHandler(this.textBoxuser_Enter);
            this.textBoxuser.Leave += new System.EventHandler(this.textBoxuser_Leave);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox2.Image = global::ProjectFinal.Properties.Resources.account_1439373_1214443;
            this.pictureBox2.Location = new System.Drawing.Point(113, 367);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(48, 42);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox5.Image = global::ProjectFinal.Properties.Resources.lock_password_protect_safety_security_icon_1320086045132546966;
            this.pictureBox5.Location = new System.Drawing.Point(113, 442);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(48, 40);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 13;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::ProjectFinal.Properties.Resources.slide1;
            this.pictureBox6.Location = new System.Drawing.Point(17, 23);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(815, 287);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 2;
            this.pictureBox6.TabStop = false;
            // 
            // Sign_In
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(871, 874);
            this.Controls.Add(this.buttonclose);
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Sign_In";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sign_In";
            this.Load += new System.EventHandler(this.Sign_In_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonclose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label forgetpass;
        private System.Windows.Forms.Button buttonnewacount;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label labelcheckpass;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Button buttonlogin;
        private System.Windows.Forms.TextBox textBoxuser;
    }
}