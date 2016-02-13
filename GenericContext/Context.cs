using GenericContext.Properties;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericContext
{
    public class Context
    {
        public string[] GetContext()
        {
            List<string> returnValue = new List<string>();

            string connectionString = Settings.Default.DBConnectionString;

            #region Read Entries

            string queryString = "SELECT TOP 10 Phrases FROM dbo.GenericContextSources";
                  
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
               
                SqlCommand command = new SqlCommand(queryString, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        returnValue.Add("Phrase;" + reader[0]);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    //silent catch here
                }
            }

            #endregion

            #region Delete old Entries

            //string queryStringtoDelete = "DELETE FROM dbo.GenericContextSources";
            string queryStringtoDelete = "DELETE FROM dbo.GenericContextSources where DateTimeSensed < DATEADD(MINUTE, -1, GETDATE())";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryStringtoDelete, connection);

                try
                {
                    connection.Open();
                    command.ExecuteReader();
                }
                catch (Exception ex)
                {
                    //silent catch her
                }
            }

            #endregion

            return returnValue.ToArray();
        }
    }
}
