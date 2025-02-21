using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            textBoxPassword.PasswordChar = '●';
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

        private void buttonAuth_Click(object sender, EventArgs e)
        {
            Main form = new Main();
            form.Show();
            this.Hide();
        }

        private void hideshowpwd_Click(object sender, EventArgs e)
        {
            textBoxPassword.PasswordChar = '\0';
        }
    }
}
