using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SearchHost
{
    public partial class TestFileQuery : Form
    {
        public TestFileQuery()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtResults.Text = string.Empty;
                using (OleDbConnection conn = new OleDbConnection(
                   "Provider=Search.CollatorDSO;Extended Properties='Application=Windows';"))
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand(txtquery.Text, conn);

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        int cnt = 0;
                        while (reader.Read())
                        {

                            txtResults.Text += "FILE;" + reader.GetString(0) + Environment.NewLine;
                            cnt++;
                        }

                        lblResCount.Text = cnt.ToString();
                    }
                }


            }
            catch (Exception ex)
            {
                txtResults.Text = ex.Message;
            }
        }
    }
}
