using AjmeraPracticalAssessment.HealthCheckAPI.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace AjmeraPracticalAssessment.HealthCheckAPI
{
    public class CheckDatabaseConnection : ICheckDatabaseConnection
    {
		public async Task CheckDatabaseHealth(string connectionString, List<string> tableNames) 
		{
            if (!IsServerConnected(connectionString))
            {
                // Call a service to create connection
            }
            foreach (string tableName in tableNames) 
            {
                if (string.IsNullOrEmpty(tableName)) continue;
                if (!IsTableCreated(connectionString, tableName))
                {
                    // Call a service to create table
                    CreateTable(connectionString, tableName);
                    // Needs optimization
                }
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
                string query = $"SELECT TOP 1 * FROM {tableName}";
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

        private async void CreateTable(string connectionString, string tableName)
        {
            string query = @$"CREATE TABLE {tableName} (
                                BookID UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
                                BookName VARCHAR(50) NOT NULL,
                                AuthorName VARCHAR(50) NOT NULL );";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, con);
                sqlCommand.Connection.Open();
                await sqlCommand.ExecuteNonQueryAsync();
                sqlCommand.Connection.Close();
            }
        }
    }
}
