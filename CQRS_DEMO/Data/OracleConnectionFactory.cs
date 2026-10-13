using Oracle.ManagedDataAccess.Client;
using System.Configuration;
namespace CQRS_DEMO.Data
{
    public class OracleConnectionFactory
    {
        private readonly string _connectionString;
        public OracleConnectionFactory(IConfiguration configuration)
        {
            _connectionString=configuration.GetConnectionString("Oracle")?? throw new InvalidOperationException("Connection string 'Oracle' not found.");
        }
        public OracleConnection CreateConnection()
        {
            return new OracleConnection(_connectionString);
        }
    }
}
