using AjmeraPracticalAssessment.Contracts.Write;
using AjmeraPracticalAssessment.Repository.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using AjmeraPracticalAssessment.Contracts.Read;
using Dapper;

namespace AjmeraPracticalAssessment.Repository
{
    public class BookkeepingRepositoryWrite : IBookkeepingRepositoryWrite
    {
        #region Private Variables
        private readonly IConfiguration configuration;
        private readonly string connectionString = string.Empty;
        private const string connectionStringName = "conn";
        private readonly IDbConnection dbConnection;
        private readonly string tableName = string.Empty;
        #endregion

        #region Constructor
        public BookkeepingRepositoryWrite(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionString = configuration.GetConnectionString(connectionStringName);
            dbConnection = new SqlConnection(connectionString);
            // optimization: remove tablename here and put it in stored-procedure
            this.tableName = configuration.GetSection("HealthChecks:TableNames").Value.Split(',')[0];
        }
        #endregion

        #region Public Methods
        public async Task<string> InsertBookDetails(BookkeeperWrite bookDetails)
        {
            // optimization: execute stored-procedure instead of query
            string query = @$"INSERT INTO {tableName} (BookID, BookName, AuthorName) 
                                OUTPUT INSERTED.[BookID] 
                                VALUES (default, '{bookDetails.BookName}', '{bookDetails.AuthorName}')";
            string response = (await dbConnection.ExecuteScalarAsync(query)).ToString();
            return response;
        }

        public async Task<bool> UpdateBookDetails(BookkeeperRead bookDetails)
        {
            // optimization: execute stored-procedure instead of query
            string query = $"UPDATE {tableName} SET BookName = '{bookDetails.BookName}', AuthorName = '{bookDetails.AuthorName}' WHERE BookID = '{bookDetails.BookID}')";
            var response = await dbConnection.QueryAsync<bool>(query);
            bool res = false;
            if (response != null)
            {
                res = true;
            }
            return res;
        }

        public async Task<bool> DeleteBookDetails(string id)
        {
            // optimization: Execute SP instead and before deleting store it in a seperate table for data retention.
            string query = $"DELETE FROM {tableName} WHERE BookID = {id}";
            var response = await dbConnection.QueryAsync<bool>(query);
            bool res = false;
            if (response != null)
            {
                res = true;
            }
            return res;
        }
        #endregion
    }
}
