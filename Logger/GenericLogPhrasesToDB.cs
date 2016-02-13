using DAL.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace DAL
{
    //this class can be used for all types of modules which are more complex than just simple dlls, like
    //Add ins füt Office Software. This Generic Logger makes it possible to save the phrases to a db, which gets
    //read by the contextSourcePorxy later on.
    public class GenericLogPhrasesToDB
    {
        SqlConnection con;

        public GenericLogPhrasesToDB()
        {
            con = new SqlConnection();
            con.ConnectionString = Settings.Default.ContextSearchHelperConnectionString;
            con.Open();
        }

        public void LogPhrasesToDB(string[] phrases)
        {
            string tolog = Helper.ReturnConcattedString(phrases, " ");
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Insert into dbo.GenericContextSources (Phrases, DateTimeSensed) values (@phrases, @DateTimeSensed)";

                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@phrases";
                param1.Value = tolog;
                param1.SqlDbType = SqlDbType.Text;

                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@DateTimeSensed";
                param2.Value = DateTime.Now; ;
                param2.SqlDbType = SqlDbType.DateTime;

                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Utilities.Logger.LogError(ex);
            }
        }
    }
}
