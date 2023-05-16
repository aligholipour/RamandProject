using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Ramand.Domain.Contracts;
using System.Data;

namespace Ramand.Infrastructure.Persistence
{
    public class DapperContext : IDapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("SqlConnection");
        }

        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}
