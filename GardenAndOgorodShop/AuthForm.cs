using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Configuration;
using System.Reflection;

namespace GardenAndOgorodShop
{
    
    public partial class AuthForm : Form
    {
        // переменные для сохранения текста textbox при обработке placeholder
        private string save_login_textbox;
        private string save_captcha_textbox;
        private string save_password_textbox;
        // переменная для обработки перемещения панели настроек
        bool moving;
        // переменная-флаг активации по нажатию кнопки
        bool setting_active_status = false;
        // переменная-флаг показа пароля в textbox
        bool show_password = false;
        public AuthForm()
        {
            InitializeComponent();
        }
        // ФУНКЦИЯ ПОЯВЛЕНИЯ ПАНЕЛИ НАСТРОЕК
        private async void ActiveSetting()
        {
            // задаём будущее положение панели настроек
            int future_location_pannelSettings = panelSettings.Location.X - 210;
            // цикл по пиксельного перемещения с итерационным созданием точки локации на форме
            while (!moving && panelSettings.Location.X > future_location_pannelSettings)
            {
                moving = true;
                await Task.Delay(1);
                panelSettings.Location = new Point(panelSettings.Location.X - panelSettings.Location.X / 50, panelSettings.Location.Y);
                moving = false;
            }
            setting_active_status = true;
        }
        // ФУНКЦИЯ СКРЫТИЯ ПАНЕЛИ НАСТРОЕК
        private async void DisactiveSetting()
        {
            // задаём будущее положение панели настроек
            int future_location_pannelSettings = panelSettings.Location.X + 210;
            // цикл по пиксельного перемещения с итерационным созданием точки локации на форме
            while (!moving && panelSettings.Location.X < future_location_pannelSettings)
            {
                moving = true;
                await Task.Delay(1);
                panelSettings.Location = new Point(panelSettings.Location.X + panelSettings.Location.X / 50, panelSettings.Location.Y);
                moving = false;
            }
            setting_active_status = false;
        }
        private string TextGenerate()
        {
            Random random = new Random();
            string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string result = "";
            for (int i = 0; i < 4; i++)
            {
                result += Convert.ToString(chars[random.Next(0, chars.Length - 1)]);
            }
            return result;
        }
        private void RefreshCaptcha()
        {
            Random random = new Random();
            int count = 3;
            string captcha = TextGenerate();

            foreach (Control control in panelShoom.Controls)
            {
                if (control is newLabel newLabel)
                {
                    newLabel.Width = 80;
                    newLabel.Height = 80;
                    newLabel.Text = captcha[count].ToString();
                    newLabel.AutoSize = false;
                    newLabel.NewText = captcha[count].ToString();
                    newLabel.RotateAngle = random.Next(-40, 40);
                    count--;
                }
            }
        }
        private void AuthForm_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = Convert.ToBoolean(ConfigurationManager.AppSettings["sleep"]);
            RefreshCaptcha();
            if (!DBHandler.checkConnection())
            {
                MessageBox.Show("Ошибка подключения к серверу.\nВызовите системного администратора", "Проверка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                buttonAuth.Enabled = false;
            }
        }
        // ФУНКЦИЯ ОБРАБОТКИ placeholder для логина при фокусе textbox
        private void textBoxLogin_Enter(object sender, EventArgs e)
        {
            textBoxLogin.ForeColor = Color.Black;
            if (save_login_textbox != "")
            {
                textBoxLogin.Text = save_login_textbox;
            }
            else
            {
                textBoxLogin.Text = "";
            }
        }
        // ФУНКЦИЯ ОБРАБОТКИ placeholder для логина при уходе из фокуса textbox
        private void textBoxLogin_Leave(object sender, EventArgs e)
        {
            if (textBoxLogin.Text == "")
            {
                textBoxLogin.Text = "Логин";
                textBoxLogin.ForeColor = Color.Gray;
                save_login_textbox = "";
            }
            else
            {
                save_login_textbox = textBoxLogin.Text;
            }
        }
        // ФУНКЦИЯ ОБРАБОТКИ placeholder для пароля при фокусе textbox
        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            textBoxPassword.ForeColor = Color.Black;

            if (save_password_textbox != "")
            {
                textBoxPassword.Text = save_password_textbox;
            }
            else
            {
                textBoxPassword.Text = "";
            }
        }
        // ФУНКЦИЯ ОБРАБОТКИ placeholder для пароля при уходе из фокуса textbox
        private void textBoxPassword_Leave(object sender, EventArgs e)
        {
            
            if (textBoxPassword.Text == "")
            {
                textBoxPassword.Text = "Пароль";
                textBoxPassword.ForeColor = Color.Gray;
                save_password_textbox = "";
            }
            else
            {
                save_password_textbox = textBoxPassword.Text;
            }
        }
        // ФУНКЦИЯ АКТИВАЦИИ ПАНЕЛИ НАСТРОЕК
        private void buttonMenu_Click(object sender, EventArgs e)
        {
            if (!setting_active_status)
            {
                ActiveSetting();
            }
            else
            {
                DisactiveSetting();
            }
        }
        // ФУНКЦИЯ СОЗДАНИЯ ХЭША
        static string ComputeSha256Hash(string rawData)
        {
            // Создаем новый экземпляр SHA256
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Вычисляем хэш
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Преобразуем байты в строку
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2")); // Преобразуем в шестнадцатеричный формат
                }
                return builder.ToString();
            }
        }
        private void buttonAuth_Click(object sender, EventArgs e)
        {
            string login = textBoxLogin.Text;
            string pwd = ComputeSha256Hash(textBoxPassword.Text);
            if (DBHandler.checkAutorization(login, pwd))
            {
                if (UserConfiguration.UserID != 0)
                {
                    DBHandler.updateLastLogInUser();

                    Main form = new Main();
                    form.Show();
                    this.Hide();
                }
            }
            else
            {
                panelCaptcha.Visible = true;
            }
        }

        private void hideshowpwd_Click(object sender, EventArgs e)
        {
            if (setting_active_status)
            {
                DisactiveSetting();
            }
            if (show_password)
            {
                hideshowpwd.BackgroundImage = GardenAndOgorodShop.Properties.Resources.show_password;
                textBoxPassword.PasswordChar = '\0';
                show_password = false;
            }
            else
            {
                hideshowpwd.BackgroundImage = GardenAndOgorodShop.Properties.Resources.hide_password;
                textBoxPassword.PasswordChar = '●';
                show_password = true;
            }
        }

        private void buttonExitApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panelAuth_Click(object sender, EventArgs e)
        {
            if (setting_active_status)
            {
                DisactiveSetting();
            }
        }

        private void textBoxLogin_TextChanged(object sender, EventArgs e)
        {
            if (setting_active_status)
            {
                DisactiveSetting();
            }
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            if (setting_active_status)
            {
                DisactiveSetting();
            }
        }

        private void AuthForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
        }

        private void buttonSettingsDB_Click(object sender, EventArgs e)
        {
            dbSettingsForm form = new dbSettingsForm();
            form.ShowDialog();
        }
        private void EnabledCaptchaItems(bool enabled)
        {
            button1.Enabled = enabled;
            button2.Enabled = enabled;
            textBoxCaptcha.Enabled = enabled;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string captcha = $"{newLabel1.NewText}{newLabel2.NewText}{newLabel3.NewText}{newLabel4.NewText}";
            if (captcha == textBoxCaptcha.Text)
            {
                panelCaptcha.Visible = false;
                RefreshCaptcha();
            }
            else
            {
                EnabledCaptchaItems(false);
                timer1.Start();
                RefreshCaptcha();
            }
            textBoxCaptcha.Text = "";
            save_captcha_textbox = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RefreshCaptcha();
        }

        private void textBoxCaptcha_Enter(object sender, EventArgs e)
        {
            textBoxCaptcha.ForeColor = Color.Black;
            if (save_captcha_textbox != "")
            {
                textBoxCaptcha.Text = save_captcha_textbox;
            }
            else
            {
                textBoxCaptcha.Text = "";
            }
        }

        private void textBoxCaptcha_Leave(object sender, EventArgs e)
        {
            if (textBoxCaptcha.Text == "")
            {
                textBoxCaptcha.Text = "Введите каптчу...";
                textBoxCaptcha.ForeColor = Color.Gray;
                save_captcha_textbox = "";
            }
            else
            {
                save_captcha_textbox = textBoxCaptcha.Text;
            }
        }
        int counter_timer = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (counter_timer > 10)
            {
                timer1.Stop();
                counter_timer = 0;
                EnabledCaptchaItems(true);
            }
            else
            {
                counter_timer++;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);

            if (checkBox1.Checked)
            {
                checkBox1.BackColor = Color.Teal;
                checkBox1.Text = "ВКЛ ";
                config.AppSettings.Settings["sleep"].Value = "true";
            }
            else
            {
                checkBox1.BackColor = Color.White;
                checkBox1.Text = "ВЫКЛ";
                config.AppSettings.Settings["sleep"].Value = "false";
            }
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
    class newLabel : System.Windows.Forms.Label
    {
        public int RotateAngle { get; set; }
        public string NewText { get; set; }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Brush b = new SolidBrush(Color.FromArgb(192, 64, 0));
            e.Graphics.TranslateTransform(this.Width / 2, this.Height / 2);
            e.Graphics.RotateTransform(this.RotateAngle);
            e.Graphics.DrawString(this.NewText, this.Font, b, 0f, 0f);
            base.OnPaint(e);
        }
    }
    
}
