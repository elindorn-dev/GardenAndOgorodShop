
namespace GardenAndOgorodShop
{
    partial class dbSettingsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.userpasswordTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dbTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.serverTextBox = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonImport = new System.Windows.Forms.Button();
            this.comboBoxTables = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panelBlock = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.hideshowpwd = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonAuth = new System.Windows.Forms.Button();
            this.buttonHandleBackup = new System.Windows.Forms.Button();
            this.buttonRestoreBackup = new System.Windows.Forms.Button();
            this.panelBlock.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(120)))), ((int)(((byte)(56)))));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Настройки";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(120)))), ((int)(((byte)(56)))));
            this.panel2.Location = new System.Drawing.Point(125, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(180, 3);
            this.panel2.TabIndex = 12;
            // 
            // buttonConnect
            // 
            this.buttonConnect.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(120)))), ((int)(((byte)(56)))));
            this.buttonConnect.FlatAppearance.BorderSize = 2;
            this.buttonConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConnect.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonConnect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(120)))), ((int)(((byte)(56)))));
            this.buttonConnect.Location = new System.Drawing.Point(20, 317);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(275, 50);
            this.buttonConnect.TabIndex = 24;
            this.buttonConnect.Text = "Установить соединение";
            this.buttonConnect.UseVisualStyleBackColor = false;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(120)))), ((int)(((byte)(56)))));
            this.label6.Location = new System.Drawing.Point(16, 233);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(179, 21);
            this.label6.TabIndex = 23;
            this.label6.Text = "Пароль пользователя:";
            // 
            // userpasswordTextBox
            // 
            this.userpasswordTextBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userpasswordTextBox.Location = new System.Drawing.Point(20, 257);
            this.userpasswordTextBox.MaxLength = 100;
            this.userpasswordTextBox.Name = "userpasswordTextBox";
            this.userpasswordTextBox.PasswordChar = '●';
            this.userpasswordTextBox.Size = new System.Drawing.Size(279, 33);
            this.userpasswordTextBox.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(120)))), ((int)(((byte)(56)))));
            this.label5.Location = new System.Drawing.Point(16, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 21);
            this.label5.TabIndex = 21;
            this.label5.Text = "Имя пользователя:";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.usernameTextBox.Location = new System.Drawing.Point(20, 195);
            this.usernameTextBox.MaxLength = 50;
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(279, 33);
            this.usernameTextBox.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(120)))), ((int)(((byte)(56)))));
            this.label4.Location = new System.Drawing.Point(12, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(185, 21);
            this.label4.TabIndex = 19;
            this.label4.Text = "Название базы данных:";
            // 
            // dbTextBox
            // 
            this.dbTextBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dbTextBox.Location = new System.Drawing.Point(16, 131);
            this.dbTextBox.MaxLength = 100;
            this.dbTextBox.Name = "dbTextBox";
            this.dbTextBox.Size = new System.Drawing.Size(279, 33);
            this.dbTextBox.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(120)))), ((int)(((byte)(56)))));
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 21);
            this.label2.TabIndex = 17;
            this.label2.Text = "Название сервера:";
            // 
            // serverTextBox
            // 
            this.serverTextBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.serverTextBox.Location = new System.Drawing.Point(16, 68);
            this.serverTextBox.MaxLength = 100;
            this.serverTextBox.Name = "serverTextBox";
            this.serverTextBox.Size = new System.Drawing.Size(279, 33);
            this.serverTextBox.TabIndex = 16;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(120)))), ((int)(((byte)(56)))));
            this.panel3.Location = new System.Drawing.Point(516, 22);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(104, 3);
            this.panel3.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(120)))), ((int)(((byte)(56)))));
            this.label3.Location = new System.Drawing.Point(322, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(195, 25);
            this.label3.TabIndex = 25;
            this.label3.Text = "Восстановление БД";
            // 
            // buttonImport
            // 
            this.buttonImport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(120)))), ((int)(((byte)(56)))));
            this.buttonImport.FlatAppearance.BorderSize = 2;
            this.buttonImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonImport.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonImport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(120)))), ((int)(((byte)(56)))));
            this.buttonImport.Location = new System.Drawing.Point(649, 217);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(256, 50);
            this.buttonImport.TabIndex = 28;
            this.buttonImport.Text = "Импорт данных";
            this.buttonImport.UseVisualStyleBackColor = false;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // comboBoxTables
            // 
            this.comboBoxTables.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(120)))), ((int)(((byte)(56)))));
            this.comboBoxTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTables.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxTables.ForeColor = System.Drawing.Color.White;
            this.comboBoxTables.FormattingEnabled = true;
            this.comboBoxTables.Items.AddRange(new object[] {
            "brands",
            "categories",
            "employees",
            "orders",
            "products",
            "products_orders",
            "roles",
            "suppliers",
            "users"});
            this.comboBoxTables.Location = new System.Drawing.Point(649, 107);
            this.comboBoxTables.Name = "comboBoxTables";
            this.comboBoxTables.Size = new System.Drawing.Size(256, 32);
            this.comboBoxTables.TabIndex = 29;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(120)))), ((int)(((byte)(56)))));
            this.label7.Location = new System.Drawing.Point(645, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 21);
            this.label7.TabIndex = 30;
            this.label7.Text = "Таблица:";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(120)))), ((int)(((byte)(56)))));
            this.panel4.Location = new System.Drawing.Point(711, 22);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(215, 3);
            this.panel4.TabIndex = 32;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(120)))), ((int)(((byte)(56)))));
            this.label8.Location = new System.Drawing.Point(628, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 25);
            this.label8.TabIndex = 31;
            this.label8.Text = "Импорт";
            // 
            // panelBlock
            // 
            this.panelBlock.Controls.Add(this.label9);
            this.panelBlock.Controls.Add(this.hideshowpwd);
            this.panelBlock.Controls.Add(this.panel5);
            this.panelBlock.Controls.Add(this.panel6);
            this.panelBlock.Controls.Add(this.buttonAuth);
            this.panelBlock.Location = new System.Drawing.Point(-1, -1);
            this.panelBlock.Name = "panelBlock";
            this.panelBlock.Size = new System.Drawing.Size(530, 410);
            this.panelBlock.TabIndex = 33;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.label9.Location = new System.Drawing.Point(13, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(472, 37);
            this.label9.TabIndex = 22;
            this.label9.Text = "Подтвердите права администратора";
            // 
            // hideshowpwd
            // 
            this.hideshowpwd.BackgroundImage = global::GardenAndOgorodShop.Properties.Resources.show_password;
            this.hideshowpwd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.hideshowpwd.FlatAppearance.BorderSize = 0;
            this.hideshowpwd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hideshowpwd.Location = new System.Drawing.Point(387, 183);
            this.hideshowpwd.Name = "hideshowpwd";
            this.hideshowpwd.Size = new System.Drawing.Size(40, 40);
            this.hideshowpwd.TabIndex = 21;
            this.hideshowpwd.UseVisualStyleBackColor = true;
            this.hideshowpwd.Click += new System.EventHandler(this.hideshowpwd_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.textBoxLogin);
            this.panel5.Location = new System.Drawing.Point(65, 100);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(350, 50);
            this.panel5.TabIndex = 20;
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.BackColor = System.Drawing.Color.White;
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
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.textBoxPassword);
            this.panel6.Location = new System.Drawing.Point(65, 176);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(316, 50);
            this.panel6.TabIndex = 19;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.BackColor = System.Drawing.Color.White;
            this.textBoxPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPassword.ForeColor = System.Drawing.Color.Gray;
            this.textBoxPassword.Location = new System.Drawing.Point(17, 15);
            this.textBoxPassword.MaxLength = 100;
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(296, 22);
            this.textBoxPassword.TabIndex = 0;
            this.textBoxPassword.Text = "Пароль";
            this.textBoxPassword.Enter += new System.EventHandler(this.textBoxPassword_Enter);
            this.textBoxPassword.Leave += new System.EventHandler(this.textBoxPassword_Leave);
            // 
            // buttonAuth
            // 
            this.buttonAuth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(120)))), ((int)(((byte)(56)))));
            this.buttonAuth.FlatAppearance.BorderSize = 0;
            this.buttonAuth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAuth.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAuth.ForeColor = System.Drawing.Color.White;
            this.buttonAuth.Location = new System.Drawing.Point(65, 283);
            this.buttonAuth.Name = "buttonAuth";
            this.buttonAuth.Size = new System.Drawing.Size(350, 50);
            this.buttonAuth.TabIndex = 18;
            this.buttonAuth.Text = "Авторизоваться";
            this.buttonAuth.UseVisualStyleBackColor = false;
            this.buttonAuth.Click += new System.EventHandler(this.buttonAuth_Click);
            // 
            // buttonHandleBackup
            // 
            this.buttonHandleBackup.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(120)))), ((int)(((byte)(56)))));
            this.buttonHandleBackup.FlatAppearance.BorderSize = 2;
            this.buttonHandleBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHandleBackup.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonHandleBackup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(120)))), ((int)(((byte)(56)))));
            this.buttonHandleBackup.Location = new System.Drawing.Point(331, 171);
            this.buttonHandleBackup.Name = "buttonHandleBackup";
            this.buttonHandleBackup.Size = new System.Drawing.Size(279, 50);
            this.buttonHandleBackup.TabIndex = 34;
            this.buttonHandleBackup.Text = "Резервное копирование";
            this.buttonHandleBackup.UseVisualStyleBackColor = false;
            this.buttonHandleBackup.Click += new System.EventHandler(this.buttonHandleBackup_Click);
            // 
            // buttonRestoreBackup
            // 
            this.buttonRestoreBackup.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(120)))), ((int)(((byte)(56)))));
            this.buttonRestoreBackup.FlatAppearance.BorderSize = 2;
            this.buttonRestoreBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRestoreBackup.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRestoreBackup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(120)))), ((int)(((byte)(56)))));
            this.buttonRestoreBackup.Location = new System.Drawing.Point(331, 270);
            this.buttonRestoreBackup.Name = "buttonRestoreBackup";
            this.buttonRestoreBackup.Size = new System.Drawing.Size(279, 50);
            this.buttonRestoreBackup.TabIndex = 35;
            this.buttonRestoreBackup.Text = "Восстановить из копии";
            this.buttonRestoreBackup.UseVisualStyleBackColor = false;
            this.buttonRestoreBackup.Click += new System.EventHandler(this.buttonRestoreBackup_Click);
            // 
            // dbSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(527, 408);
            this.Controls.Add(this.panelBlock);
            this.Controls.Add(this.buttonRestoreBackup);
            this.Controls.Add(this.buttonHandleBackup);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBoxTables);
            this.Controls.Add(this.buttonImport);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.userpasswordTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dbTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.serverTextBox);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dbSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки бд";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.dbSettingsForm_FormClosed);
            this.Load += new System.EventHandler(this.dbSettingsForm_Load);
            this.panelBlock.ResumeLayout(false);
            this.panelBlock.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox userpasswordTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox dbTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox serverTextBox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.ComboBox comboBoxTables;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panelBlock;
        private System.Windows.Forms.Button hideshowpwd;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonAuth;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonHandleBackup;
        private System.Windows.Forms.Button buttonRestoreBackup;
    }
}