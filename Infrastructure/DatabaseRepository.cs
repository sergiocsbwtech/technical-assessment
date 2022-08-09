using Dapper;
using Microsoft.Data.Sqlite;
using System.Linq;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using technical_assessment.Core;
 
namespace technical_assessment.Infrastructure
{
    public class DatabaseRepository : IDatabaseRepository
    {
        private readonly string _connectionString;
 
        public DatabaseRepository(IConfiguration configuration)
        {
            this._connectionString = configuration.GetSection("DBConnectionString");
        }
 
        public Task<string> Setup()
        {
            using var connection = new SqliteConnection(_connectionString);
 
            var table = connection.Query<string>("SELECT 1;");
            var tableName = table.FirstOrDefault();
            return "1";
 
            /*connection.Execute("Create Table Product (" +
                "Name VARCHAR(100) NOT NULL," +
                "Description VARCHAR(1000) NULL);");*/
        }
    }
}