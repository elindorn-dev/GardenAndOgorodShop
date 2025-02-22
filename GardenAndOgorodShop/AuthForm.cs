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

namespace GardenAndOgorodShop
{
    public partial class AuthForm : Form
    {
        // переменные для сохранения текста textbox при обработке placeholder
        private string save_login_textbox;
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

        private void AuthForm_Load(object sender, EventArgs e)
        {

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
    }
}
