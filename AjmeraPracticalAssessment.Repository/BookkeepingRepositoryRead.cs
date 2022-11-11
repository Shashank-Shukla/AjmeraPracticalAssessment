using AjmeraPracticalAssessment.Contracts.Read;
using AjmeraPracticalAssessment.Contracts.Write;
using AjmeraPracticalAssessment.Repository.Interface;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<List<BookkeeperRead>> GetAllBookDetails()
        {
            // optimization: execute stored-procedure instead of query
            string query = "select BookID, BookName, AuthorName from BookKeeping";
            var res = (await dbConnection.QueryAsync<BookDetailsWriteResponse>(query)).ToList();
            //List<BookkeeperRead> response = (await dbConnection.QueryAsync<BookkeeperRead>(query)).ToList();
            List<BookkeeperRead> response = new List<BookkeeperRead>();
            foreach (var r in res)
            {
                response.Add(new BookkeeperRead
                {
                    BookID = r.BookID.ToString(),
                    BookName = r.BookName.ToString(),
                    AuthorName = r.AuthorName.ToString(),
                });
            }
            return response;
        }

        public async Task<BookkeeperWrite> GetBookDetailById(string id)
        {
            // optimization: execute stored-procedure instead of query
            string query = $"select BookName, AuthorName from BookKeeping where BookID = '{id}'";
            BookkeeperWrite response = (await dbConnection.QueryAsync<BookkeeperWrite>(query)).FirstOrDefault();
            return response;
        }
        #endregion
    }
}
