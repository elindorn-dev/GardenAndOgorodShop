using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GardenAndOgorodShop
{
    public partial class Main : Form
    {
        // переменная для обработки перемещения панели настроек
        bool moving;
        // переменная-флаг активации по нажатию кнопки
        bool setting_active_status = false;
        public Main()
        {
            InitializeComponent();
        }
        // ФУНКЦИЯ ВИДИМОСТИ ЭЛЕМЕНТОВ ПАНЕЛИ НАВИГАЦИИ
        private void VisibleItemsNavigation(bool visible)
        {
            buttonToProductForm.Visible = visible;
            buttonToCategoryForm.Visible = visible;
            buttonToEmployeeForm.Visible = visible;
        }
        // ФУНКЦИЯ ПОЯВЛЕНИЯ ПАНЕЛИ НАВИГАЦИИ
        private async void ActiveSetting()
        {
            // задаём будущее положение панели настроек
            int future_location_pannelSettings = panelNavigation.Width + 110;
            // цикл по пиксельного перемещения с итерационным созданием точки локации на форме
            while (!moving && panelNavigation.Width < future_location_pannelSettings)
            {
                moving = true;
                await Task.Delay(1);
                panelNavigation.Width += 20;
                moving = false;
            }
            setting_active_status = true;
            VisibleItemsNavigation(true);
        }
        // ФУНКЦИЯ СКРЫТИЯ ПАНЕЛИ НАВИГАЦИИ
        private async void DisactiveSetting()
        {
            // задаём будущее положение панели настроек
            int future_location_pannelSettings = panelNavigation.Width - 110;
            // цикл по пиксельного перемещения с итерационным созданием точки локации на форме
            while (!moving && panelNavigation.Width > future_location_pannelSettings)
            {
                moving = true;
                await Task.Delay(1);
                panelNavigation.Width -= 20;
                moving = false;
            }
            setting_active_status = false;
            VisibleItemsNavigation(false);
        }

        private void FormViewProduct_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.DroppedDown = true;
        }

        private void button5_Click(object sender, EventArgs e)
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

        private void buttonToProductForm_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void buttonToCategoryForm_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void buttonToEmployeeForm_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisactiveSetting();
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            DisactiveSetting();
        }

        private void ViewEmployeesPage_Click(object sender, EventArgs e)
        {
            DisactiveSetting();
        }

        private void ViewCategories_Click(object sender, EventArgs e)
        {
            DisactiveSetting();
        }

        private void ViewProductPage_Click(object sender, EventArgs e)
        {
            DisactiveSetting();
        }

        private void panel1_Click(object sender, EventArgs e)
        {

        }
    }
}
