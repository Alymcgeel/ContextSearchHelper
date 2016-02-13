using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchChromeHistory
{
    public class Search
    {
        public string[] DoSearch(string[] phrases)
        {
            List<string> result = new List<string>();

            string userpath = System.Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string filetoCopy = userpath + @"\AppData\Local\Google\Chrome\User Data\Default\History";
           string fileAfterCopy = Environment.CurrentDirectory + @"\ChromeHistory";
            File.Copy(filetoCopy, fileAfterCopy, true);

            if (File.Exists(fileAfterCopy))
            {
                SQLiteConnection conn = new SQLiteConnection(@"Data Source=" + fileAfterCopy);
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = conn;

                cmd.CommandText = "select url from urls where (";
                for (int cnt = 0; cnt < phrases.Count(); cnt++)
                {
                    cmd.CommandText += "(title LIKE '%" + phrases[cnt] + "%' or url LIKE '%" + phrases[cnt] + "%')";
                    if (cnt != phrases.Count() - 1)
                    {
                        cmd.CommandText += " or ";
                    }
                }

                cmd.CommandText += ") LIMIT 30";

                SQLiteDataReader dr = cmd.ExecuteReader();
                //Debugger.Launch();
                while (dr.Read())
                {
                    result.Add("chrome;1;" + dr[0].ToString());
                }
            }

            if (result.Count() == 0)
            {
                result.Add("Nothing found in Chrome");
            }

            return result.ToArray();
        }
    }
}
