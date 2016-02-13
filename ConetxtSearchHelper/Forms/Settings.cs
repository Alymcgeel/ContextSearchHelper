using DAL;
using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConetxtSearchHelper.Forms
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();

            LoadSettingsFromDB();
        }

        private void LoadSettingsFromDB()
        {
            DBReader reader = new DBReader();
            SettingsDTO settings = reader.GetSettingsFromDB();

            txtUrlToSenses.Text = settings.UrlToSenses;
            txtUrlToSources.Text = settings.UrlToSource;
        }

        //Save button clicked
        private void button1_Click(object sender, EventArgs e)
        {
            //save here data to DB

            //now close the form
            this.Close();
        }
    }
}
