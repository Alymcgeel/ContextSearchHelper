using DAL.Properties;
using Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBReader
    {
        SqlConnection connnection_;

        public DBReader()
        {
            connnection_ = new SqlConnection();
            connnection_.ConnectionString = Settings.Default.ContextSearchHelperConnectionString;
            connnection_.Open();
        }
        
        public SettingsDTO GetSettingsFromDB()
        {
            SettingsDTO dto = new SettingsDTO();

            string queryString = "SELECT TOP 1000 SettingKey,SettingValue FROM dbo.Settings";

            SqlCommand command = new SqlCommand(queryString, connnection_);
            SqlDataReader reader = command.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    string settingsKey = reader[0] as String;
                    string settingValue = reader[1] as String;

                    switch(settingsKey)
                    {
                        case "UrlToSenses":
                            dto.UrlToSenses = settingValue;
                            break;

                        case "UrlToSource":
                            dto.UrlToSource = settingValue;
                            break;
                    }                    
                }
            }
            catch (Exception ex)
            {
                Utilities.Logger.LogInfo("Error Reading Settings from DB...");
                Utilities.Logger.LogError(ex);
            }
            finally
            {
                reader.Close();
            }

            return dto;
        }

        public List<SearchResult> ReadCurrentSearchResults()
        {
            List<SearchResult> toreturn = new List<SearchResult>();

            string queryString = "SELECT TOP 1000 Path,Type,AdditionalInformation,Score FROM dbo.SearchResultQueue ORDER By Score DESC";

            SqlCommand command = new SqlCommand(queryString, connnection_);
            SqlDataReader reader = command.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    SearchResult res = new SearchResult();
                    res.Path = reader[0] as String;
                    res.Type = reader[1] as String;
                    res.AdditionalInformation = reader[2] as String;
                    res.Score = reader[3].ToString();

                    toreturn.Add(res);
                }
            }
            catch (Exception ex)
            {
                Utilities.Logger.LogInfo("Error Reading from DB...");
                Utilities.Logger.LogError(ex);
            }
            finally
            {
                reader.Close();
            }

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

            return toreturn;
        }
    }
}
