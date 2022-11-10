using AjmeraPracticalAssessment.Contracts.Read;
using AjmeraPracticalAssessment.Repository.Interface;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace AjmeraPracticalAssessment.Repository
{
    public class BookkeepingRepositoryRead : IBookkeepingRepositoryRead
    {
        #region Private Variables
        private readonly IConfiguration configuration;
        private readonly string connectionString = string.Empty;
        private const string connectionStringName = "conn";
        private readonly IDbConnection dbConnection;
        #endregion

        #region Constructor
        public BookkeepingRepositoryRead(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionString = configuration.GetConnectionString(connectionStringName);
            dbConnection = new SqlConnection(connectionString);
        }
        #endregion

        #region Public Methods
        public List<BookkeeperRead> GetAllBookDetails()
        {
            string query = "select BookID, BookName, Author from BookKeeping";
            List<BookkeeperRead> response = (dbConnection.Query<BookkeeperRead>(query)).ToList();
            return response;
        }

        public BookkeeperRead GetBookDetailById(string id)
        {
            string query = $"select BookID, BookName, Author from BookKeeping where id = {id}";
            BookkeeperRead response = dbConnection.Query<BookkeeperRead>(query).FirstOrDefault();
            return response;
        }
        #endregion
    }
}
