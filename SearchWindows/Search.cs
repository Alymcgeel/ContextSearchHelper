using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchWindows
{
    public class Search
    {
        public string[] DoSearch(string[] phrases)
        {
            string folder = string.Empty;

            string connectionString = "Provider=Search.CollatorDSO;Extended Properties=\"Application=Windows\"";
            OleDbConnection connection = new OleDbConnection(connectionString);

            string query = @"SELECT TOP 1000 System.ItemPathDisplay,System.ItemType,System.Search.Rank FROM SystemIndex " +
               @"WHERE (System.ItemType = '.pdf' OR System.ItemType = '.docx' OR System.ItemType = '.xlsx' OR System.ItemType = '.pptx') AND ((";

            //TODO - Windows Search

            //for (int cnt = 0; cnt < phrases.Count(); cnt++)
            //{
            //    query += "FREETEXT('" + phrases[cnt] + "')";
            //    if (cnt != phrases.Count() - 1)
            //    {
            //        query += " OR ";
            //    }
            //}
            //query += ") OR (";

            for (int cnt = 0; cnt < phrases.Count(); cnt++)
            {
                query += "System.ItemName LIKE '%" + phrases[cnt] + "%'";
                if (cnt != phrases.Count() - 1)
                {
                    query += " OR ";
                }
            }

            query += ") OR (";

            for (int cnt = 0; cnt < phrases.Count(); cnt++)
            {
                query += "System.Author LIKE '%" + phrases[cnt] + "%'";
                if (cnt != phrases.Count() - 1)
                {
                    query += " OR ";
                }
            }

            query += ")) AND SCOPE = 'C:\\Users\\Administrator\\Desktop' ORDER BY System.Search.Rank DESC";
            OleDbCommand command = new OleDbCommand(query, connection);
            connection.Open();

            List<string> result = new List<string>();


            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    string itempath = reader.GetString(0);
                    string itemtype = reader.GetString(1);
                    double rank = Double.Parse(reader.GetInt32(2).ToString()) / 1000.0f;

                    result.Add(itemtype.Replace(".", String.Empty).ToLower() + ";" + rank.ToString() + ";" + itempath);// + ";" + rank.ToString());
                }
                catch(Exception ex)
                {
                    //silent catch if a row has an error...
                }
            }
            connection.Close();

            return result.ToArray();
        }
    }
}
