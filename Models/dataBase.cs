using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace mvc.Models
{
    public class DataBase
    {
        private readonly string _connectionString;

        public DataBase(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }
    }
}
