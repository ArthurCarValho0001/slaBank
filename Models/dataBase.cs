using MySql.Data.MySqlClient;

namespace mvc.Models
{
    public class DataBase
    {
        private string connectionString = "server=localhost;database=mysql;user=root;pwd=arthur8271";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
