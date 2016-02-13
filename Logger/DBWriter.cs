using Data;
using DAL.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBWriter : IDisposable
    {
        SqlConnection connnection_;

        public DBWriter()
        {
            connnection_ = new SqlConnection();
            connnection_.ConnectionString = Settings.Default.ContextSearchHelperConnectionString;
            connnection_.Open();
        }

        public void ClearSearchResults()
        {
            string queryStringtoDelete = "DELETE FROM dbo.SearchResultQueue";
            //string queryStringtoDelete = "DELETE FROM dbo.GenericContextSources where DateTimeSensed < " + DateTime.Now.AddMinutes(-1);

            SqlCommand commandDel = new SqlCommand(queryStringtoDelete, connnection_);
            SqlDataReader readerDel = null;

            try
            {
                readerDel = commandDel.ExecuteReader();
            }
            catch (Exception ex)
            {
                Utilities.Logger.LogInfo("Error Deleting SearchResultQueue...");
                Utilities.Logger.LogError(ex);
            }
            finally
            {
                readerDel.Close();
            }
        }

        public void LogSearchResults(List<SearchResult> results)
        {
            ClearSearchResults();

            foreach (SearchResult res in results)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connnection_;
                    cmd.CommandText = "Insert into dbo.SearchResultQueue (AdditionalInformation, Path, Type, Score) values (@AdditionalInformation,@Path,@Type,@Score)";
                    
                    SqlParameter param1 = new SqlParameter();
                    param1.ParameterName = "@AdditionalInformation";
                    param1.Value = res.AdditionalInformation;
                    param1.SqlDbType = SqlDbType.Text;

                    SqlParameter param2 = new SqlParameter();
                    param2.ParameterName = "@Path";
                    param2.Value = res.Path;
                    param2.SqlDbType = SqlDbType.Text;

                    SqlParameter param3 = new SqlParameter();
                    param3.ParameterName = "@Type";
                    param3.Value = res.Type;
                    param3.SqlDbType = SqlDbType.Text;

                    SqlParameter param4 = new SqlParameter();
                    param4.ParameterName = "@Score";
                    param4.Value = Double.Parse(res.Score);

                    cmd.Parameters.Add(param1);
                    cmd.Parameters.Add(param2);
                    cmd.Parameters.Add(param3);
                    cmd.Parameters.Add(param4);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Utilities.Logger.LogInfo("Error logging SearchResultQueue. Value trying to add: " + res.Path + " with a score of: " + res.Score);
                    Utilities.Logger.LogError(ex);
                }
            }
        }

        public void LogPhrases(string contextphrases, string resultphrases)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connnection_;
                cmd.CommandText = "Insert into dbo.LogEntries (ContextPhrases, ResultPhrases) values (@context,@result)";

                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@context";
                param1.Value = contextphrases;
                param1.SqlDbType = SqlDbType.Text;

                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@result";
                param2.Value = resultphrases;
                param2.SqlDbType = SqlDbType.Text;


                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);

                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Utilities.Logger.LogError(ex);
            }
        }

        public void Dispose()
        {
            connnection_.Close();
        }
    }
}
