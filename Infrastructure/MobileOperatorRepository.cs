using Dapper;
using Microsoft.Data.Sqlite;
using System.Linq;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using technical_assessment.Core;
using technical_assessment.Controllers.Inputs;
 
namespace technical_assessment.Infrastructure
{
    public class MobileOperatorRepository : IMobileOperatorRepository
    {
        private readonly string _connectionString;
 
        public MobileOperatorRepository(IConfiguration configuration)
        {
            this._connectionString = configuration["DBConnectionString"].ToString();
        }
 
        private void Setup()
        {
            using var connection = new SqliteConnection(_connectionString);
 
            connection.Execute(
                @"
                    CREATE TABLE IF NOT EXISTS MobileOperator(
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name varchar(255),
                        Country varchar(255),
                        MobileNetworkSupport varchar(255)
                    )
                ");
        }

        public IEnumerable<MobileOperator> Get()
        {
            Setup();

            using var connection = new SqliteConnection(_connectionString);
            var result = connection.Query<MobileOperator>(
                @" 
                    SELECT * 
                    FROM MobileOperator;
                "
            );

            return result.ToList();
        }

        public string Set(MobileOperatorInput mobileOperatorInput)
        {
            using var connection = new SqliteConnection(_connectionString);
 
            var query = $@"
                    INSERT INTO MobileOperator (Name, Country, MobileNetworkSupport)
                    VALUES
                    (
                        {mobileOperatorInput.Name},
                        {mobileOperatorInput.Country},
                        {mobileOperatorInput.MobileNetworkSupport}
                    )
                ";

            connection.Execute(query);

            return "success";
        }
    }
}