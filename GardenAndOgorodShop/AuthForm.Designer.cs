namespace GardenAndOgorodShop
{
    partial class AuthForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthForm));
            this.panelAuth = new System.Windows.Forms.Panel();
            this.panelCaptcha = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.panelShoom = new System.Windows.Forms.Panel();
            this.newLabel4 = new GardenAndOgorodShop.newLabel();
            this.newLabel3 = new GardenAndOgorodShop.newLabel();
            this.newLabel2 = new GardenAndOgorodShop.newLabel();
            this.newLabel1 = new GardenAndOgorodShop.newLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxCaptcha = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.hideshowpwd = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAuth = new System.Windows.Forms.Button();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.buttonSettingsDB = new System.Windows.Forms.Button();
            this.buttonExitApp = new System.Windows.Forms.Button();
            this.buttonMenu = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelAuth.SuspendLayout();
            this.panelCaptcha.SuspendLayout();
            this.panelShoom.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // panelAuth
            // 
            this.panelAuth.BackColor = System.Drawing.Color.White;
            this.panelAuth.Controls.Add(this.panelCaptcha);
            this.panelAuth.Controls.Add(this.pictureBox1);
            this.panelAuth.Controls.Add(this.hideshowpwd);
            this.panelAuth.Controls.Add(this.panel3);
            this.panelAuth.Controls.Add(this.panel2);
            this.panelAuth.Controls.Add(this.label1);
            this.panelAuth.Controls.Add(this.buttonAuth);
            this.panelAuth.Location = new System.Drawing.Point(55, 12);
            this.panelAuth.Name = "panelAuth";
            this.panelAuth.Size = new System.Drawing.Size(400, 423);
            this.panelAuth.TabIndex = 0;
            this.panelAuth.Click += new System.EventHandler(this.panelAuth_Click);
            // 
            // panelCaptcha
            // 
            this.panelCaptcha.Controls.Add(this.button2);
            this.panelCaptcha.Controls.Add(this.panelShoom);
            this.panelCaptcha.Controls.Add(this.button1);
            this.panelCaptcha.Controls.Add(this.panel1);
            this.panelCaptcha.Location = new System.Drawing.Point(0, 74);
            this.panelCaptcha.Name = "panelCaptcha";
            this.panelCaptcha.Size = new System.Drawing.Size(400, 346);
            this.panelCaptcha.TabIndex = 19;
            this.panelCaptcha.Visible = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = global::GardenAndOgorodShop.Properties.Resources.refresh;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(23, 229);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 50);
            this.button2.TabIndex = 17;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panelShoom
            // 
            this.panelShoom.BackgroundImage = global::GardenAndOgorodShop.Properties.Resources.shoom;
            this.panelShoom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelShoom.Controls.Add(this.newLabel4);
            this.panelShoom.Controls.Add(this.newLabel3);
            this.panelShoom.Controls.Add(this.newLabel2);
            this.panelShoom.Controls.Add(this.newLabel1);
            this.panelShoom.Location = new System.Drawing.Point(26, 31);
            this.panelShoom.Name = "panelShoom";
            this.panelShoom.Size = new System.Drawing.Size(350, 63);
            this.panelShoom.TabIndex = 16;
            // 
            // newLabel4
            // 
            this.newLabel4.AutoSize = true;
            this.newLabel4.BackColor = System.Drawing.Color.Transparent;
            this.newLabel4.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.newLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.newLabel4.Location = new System.Drawing.Point(260, -33);
            this.newLabel4.Name = "newLabel4";
            this.newLabel4.NewText = null;
            this.newLabel4.RotateAngle = 0;
            this.newLabel4.Size = new System.Drawing.Size(35, 39);
            this.newLabel4.TabIndex = 25;
            this.newLabel4.Text = "n";
            // 
            // newLabel3
            // 
            this.newLabel3.AutoSize = true;
            this.newLabel3.BackColor = System.Drawing.Color.Transparent;
            this.newLabel3.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.newLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.newLabel3.Location = new System.Drawing.Point(172, -33);
            this.newLabel3.Name = "newLabel3";
            this.newLabel3.NewText = null;
            this.newLabel3.RotateAngle = 0;
            this.newLabel3.Size = new System.Drawing.Size(35, 39);
            this.newLabel3.TabIndex = 24;
            this.newLabel3.Text = "n";
            // 
            // newLabel2
            // 
            this.newLabel2.AutoSize = true;
            this.newLabel2.BackColor = System.Drawing.Color.Transparent;
            this.newLabel2.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.newLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.newLabel2.Location = new System.Drawing.Point(80, -33);
            this.newLabel2.Name = "newLabel2";
            this.newLabel2.NewText = null;
            this.newLabel2.RotateAngle = 0;
            this.newLabel2.Size = new System.Drawing.Size(35, 39);
            this.newLabel2.TabIndex = 22;
            this.newLabel2.Text = "n";
            // 
            // newLabel1
            // 
            this.newLabel1.AutoSize = true;
            this.newLabel1.BackColor = System.Drawing.Color.Transparent;
            this.newLabel1.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.newLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.newLabel1.Location = new System.Drawing.Point(-5, -33);
            this.newLabel1.Name = "newLabel1";
            this.newLabel1.NewText = null;
            this.newLabel1.RotateAngle = 0;
            this.newLabel1.Size = new System.Drawing.Size(35, 39);
            this.newLabel1.TabIndex = 20;
            this.newLabel1.Text = "n";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(76, 229);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(300, 50);
            this.button1.TabIndex = 11;
            this.button1.Text = "Проверить";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.textBoxCaptcha);
            this.panel1.Location = new System.Drawing.Point(91, 136);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(230, 50);
            this.panel1.TabIndex = 5;
            // 
            // textBoxCaptcha
            // 
            this.textBoxCaptcha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBoxCaptcha.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCaptcha.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxCaptcha.ForeColor = System.Drawing.Color.Gray;
            this.textBoxCaptcha.Location = new System.Drawing.Point(17, 15);
            this.textBoxCaptcha.MaxLength = 4;
            this.textBoxCaptcha.Name = "textBoxCaptcha";
            this.textBoxCaptcha.Size = new System.Drawing.Size(210, 22);
            this.textBoxCaptcha.TabIndex = 0;
            this.textBoxCaptcha.Text = "Введите каптчу...";
            this.textBoxCaptcha.Enter += new System.EventHandler(this.textBoxCaptcha_Enter);
            this.textBoxCaptcha.Leave += new System.EventHandler(this.textBoxCaptcha_Leave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::GardenAndOgorodShop.Properties.Resources.logo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(153, 88);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 80);
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // hideshowpwd
            // 
            this.hideshowpwd.BackgroundImage = global::GardenAndOgorodShop.Properties.Resources.show_password;
            this.hideshowpwd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.hideshowpwd.FlatAppearance.BorderSize = 0;
            this.hideshowpwd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hideshowpwd.Location = new System.Drawing.Point(345, 265);
            this.hideshowpwd.Name = "hideshowpwd";
            this.hideshowpwd.Size = new System.Drawing.Size(40, 40);
            this.hideshowpwd.TabIndex = 17;
            this.hideshowpwd.UseVisualStyleBackColor = true;
            this.hideshowpwd.Click += new System.EventHandler(this.hideshowpwd_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel3.Controls.Add(this.textBoxLogin);
            this.panel3.Location = new System.Drawing.Point(23, 195);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(350, 50);
            this.panel3.TabIndex = 4;
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBoxLogin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxLogin.ForeColor = System.Drawing.Color.Gray;
            this.textBoxLogin.Location = new System.Drawing.Point(17, 15);
            this.textBoxLogin.MaxLength = 100;
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(330, 22);
            this.textBoxLogin.TabIndex = 0;
            this.textBoxLogin.Text = "Логин";
            this.textBoxLogin.TextChanged += new System.EventHandler(this.textBoxLogin_TextChanged);
            this.textBoxLogin.Enter += new System.EventHandler(this.textBoxLogin_Enter);
            this.textBoxLogin.Leave += new System.EventHandler(this.textBoxLogin_Leave);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.Controls.Add(this.textBoxPassword);
            this.panel2.Location = new System.Drawing.Point(23, 260);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(316, 50);
            this.panel2.TabIndex = 3;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBoxPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPassword.ForeColor = System.Drawing.Color.Gray;
            this.textBoxPassword.Location = new System.Drawing.Point(17, 15);
            this.textBoxPassword.MaxLength = 100;
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(296, 22);
            this.textBoxPassword.TabIndex = 0;
            this.textBoxPassword.Text = "Пароль";
            this.textBoxPassword.TextChanged += new System.EventHandler(this.textBoxPassword_TextChanged);
            this.textBoxPassword.Enter += new System.EventHandler(this.textBoxPassword_Enter);
            this.textBoxPassword.Leave += new System.EventHandler(this.textBoxPassword_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.label1.Location = new System.Drawing.Point(106, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 37);
            this.label1.TabIndex = 2;
            this.label1.Text = "Авторизация";
            // 
            // buttonAuth
            // 
            this.buttonAuth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(120)))), ((int)(((byte)(56)))));
            this.buttonAuth.FlatAppearance.BorderSize = 0;
            this.buttonAuth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAuth.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAuth.ForeColor = System.Drawing.Color.White;
            this.buttonAuth.Location = new System.Drawing.Point(23, 348);
            this.buttonAuth.Name = "buttonAuth";
            this.buttonAuth.Size = new System.Drawing.Size(350, 50);
            this.buttonAuth.TabIndex = 1;
            this.buttonAuth.Text = "Авторизоваться";
            this.buttonAuth.UseVisualStyleBackColor = false;
            this.buttonAuth.Click += new System.EventHandler(this.buttonAuth_Click);
            // 
            // panelSettings
            // 
            this.panelSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(120)))), ((int)(((byte)(56)))));
            this.panelSettings.Controls.Add(this.buttonSettingsDB);
            this.panelSettings.Controls.Add(this.buttonExitApp);
            this.panelSettings.Location = new System.Drawing.Point(1167, 61);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(210, 161);
            this.panelSettings.TabIndex = 2;
            // 
            // buttonSettingsDB
            // 
            this.buttonSettingsDB.BackColor = System.Drawing.Color.DarkGray;
            this.buttonSettingsDB.FlatAppearance.BorderSize = 0;
            this.buttonSettingsDB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSettingsDB.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSettingsDB.ForeColor = System.Drawing.Color.White;
            this.buttonSettingsDB.Location = new System.Drawing.Point(17, 77);
            this.buttonSettingsDB.Name = "buttonSettingsDB";
            this.buttonSettingsDB.Size = new System.Drawing.Size(167, 73);
            this.buttonSettingsDB.TabIndex = 6;
            this.buttonSettingsDB.Text = "Настройки\r\nбазы даных";
            this.buttonSettingsDB.UseVisualStyleBackColor = false;
            this.buttonSettingsDB.Click += new System.EventHandler(this.buttonSettingsDB_Click);
            // 
            // buttonExitApp
            // 
            this.buttonExitApp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.buttonExitApp.FlatAppearance.BorderSize = 0;
            this.buttonExitApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExitApp.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonExitApp.ForeColor = System.Drawing.Color.White;
            this.buttonExitApp.Location = new System.Drawing.Point(17, 13);
            this.buttonExitApp.Name = "buttonExitApp";
            this.buttonExitApp.Size = new System.Drawing.Size(167, 50);
            this.buttonExitApp.TabIndex = 5;
            this.buttonExitApp.Text = "Выйти";
            this.buttonExitApp.UseVisualStyleBackColor = false;
            this.buttonExitApp.Click += new System.EventHandler(this.buttonExitApp_Click);
            // 
            // buttonMenu
            // 
            this.buttonMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMenu.BackgroundImage = global::GardenAndOgorodShop.Properties.Resources.burger_menu;
            this.buttonMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonMenu.Location = new System.Drawing.Point(1114, 2);
            this.buttonMenu.Name = "buttonMenu";
            this.buttonMenu.Size = new System.Drawing.Size(50, 50);
            this.buttonMenu.TabIndex = 1;
            this.buttonMenu.TabStop = false;
            this.buttonMenu.Click += new System.EventHandler(this.buttonMenu_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 42);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(830, 483);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // AuthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(186)))), ((int)(((byte)(93)))));
            this.ClientSize = new System.Drawing.Size(1167, 525);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panelSettings);
            this.Controls.Add(this.buttonMenu);
            this.Controls.Add(this.panelAuth);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AuthForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AuthForm_FormClosed);
            this.Load += new System.EventHandler(this.AuthForm_Load);
            this.panelAuth.ResumeLayout(false);
            this.panelAuth.PerformLayout();
            this.panelCaptcha.ResumeLayout(false);
            this.panelShoom.ResumeLayout(false);
            this.panelShoom.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.buttonMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelAuth;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonAuth;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox buttonMenu;
        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.Button buttonExitApp;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.Button hideshowpwd;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonSettingsDB;
        private System.Windows.Forms.Panel panelCaptcha;
        private System.Windows.Forms.Panel panelShoom;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxCaptcha;
        private newLabel newLabel1;
        private newLabel newLabel2;
        private newLabel newLabel4;
        private newLabel newLabel3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}

