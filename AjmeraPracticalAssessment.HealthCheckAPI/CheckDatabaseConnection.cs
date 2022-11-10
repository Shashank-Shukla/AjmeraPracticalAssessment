using System;
using System.Data.SqlClient;

namespace AjmeraPracticalAssessment.HealthCheckAPI
{
    public class CheckDatabaseConnection
    {
		public CheckDatabaseConnection(string connectionString, string tableName) 
		{
			if (!IsServerConnected(connectionString))
			{
				// Call a service to create connection
			}
            if (!IsTableCreated(connectionString, tableName))
            {
                // Call a service to create table
            }
        }

        private bool IsServerConnected(string connectionString)
        {
			try
			{
				using (SqlConnection con = new SqlConnection(connectionString))
				{
					con.Open();
					return true;
				}
			}
			catch (Exception ex)
			{
				return false;
			}
        }

        private bool IsTableCreated(string connectionString, string tableName)
        {
            try
            {
                string query = $"SELECT TOP(1) FROM " + tableName;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(query, con);
                    sqlCommand.Connection.Open();
                    var res = sqlCommand.ExecuteNonQuery();
                    if (res != 0) 
                    { 
                        return true; 
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
