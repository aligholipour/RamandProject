using System.Data;

namespace Ramand.Domain.Contracts
{
    public interface IDapperContext
    {
        IDbConnection CreateConnection();
    }
}