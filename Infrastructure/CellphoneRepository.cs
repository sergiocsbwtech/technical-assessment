using Dapper;
using Microsoft.Data.Sqlite;
using System.Linq;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using technical_assessment.Core;
using technical_assessment.Controllers.Inputs;
 
namespace technical_assessment.Infrastructure
{
    public class CellphoneRepository : ICellphoneRepository
    {
        private readonly string _connectionString;
 
        public CellphoneRepository(IConfiguration configuration)
        {
            this._connectionString = configuration["DBConnectionString"].ToString();
        }
 
        private void Setup()
        {
            using var connection = new SqliteConnection(_connectionString);
 
            connection.Execute(
                @"
                    CREATE TABLE IF NOT EXISTS Cellphone(
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Brand varchar(255),
                        Model varchar(255),
                        MobileNetworkSupport varchar(255)
                    )
                ");
        }

        public IEnumerable<Cellphone> Get()
        {
            Setup();

            using var connection = new SqliteConnection(_connectionString);
            var result = connection.Query<Cellphone>(
                @" 
                    SELECT *
                    FROM Cellphone;
                "
            );

            return result.ToList();
        }

        public string Set(CellphoneInput cellphoneInput)
        {
            using var connection = new SqliteConnection(_connectionString);
 
            var query = $@"
                            INSERT INTO Cellphone (Brand, Model, MobileNetworkSupport)
                            VALUES
                            (
                                '{cellphoneInput.Brand}',
                                '{cellphoneInput.Model}',
                                '{cellphoneInput.MobileNetworkSupport}'
                            )
                        ";

            connection.Execute(query);

            return "success";
        }
    }
}