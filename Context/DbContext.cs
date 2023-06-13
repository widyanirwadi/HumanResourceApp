using System.Data;
using System.Data.SqlClient;

namespace HumanResourceApp.Context
{
    public class DbContext
    {
        private readonly IConfiguration _configuration;

        private readonly string _connectionString;

        /* Constructor */
        public DbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
