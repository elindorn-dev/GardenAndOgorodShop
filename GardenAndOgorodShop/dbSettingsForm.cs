using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Reflection;

namespace GardenAndOgorodShop
{
    public partial class dbSettingsForm : Form
    {
        public dbSettingsForm()
        {
            InitializeComponent();
        }

        private void dbSettingsForm_Load(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);

            config.AppSettings.Settings["host"].Value = host;
            config.AppSettings.Settings["db"].Value = database;
            config.AppSettings.Settings["uid"].Value = username;
            config.AppSettings.Settings["pwd"].Value = pwd;

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void guest_button_Click(object sender, EventArgs e)
        {

        }
    }
}
