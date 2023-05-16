using Microsoft.Data.SqlClient;
using System.Data;

namespace RamandTest.Common
{
    public abstract class PersistTest : IDisposable
    {
        protected IDbConnection DbConnection;
        protected PersistTest()
        {
            DbConnection = new SqlConnection(Constants.ConnectionStrng);
        }

        public void Dispose()
        {
            DbConnection.Dispose();
        }
    }
}