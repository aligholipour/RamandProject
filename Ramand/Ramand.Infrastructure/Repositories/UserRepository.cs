using Dapper;
using Ramand.Application.Contracts;
using Ramand.Application.Dtos;
using Ramand.Domain.Contracts;
using System.Data;

namespace Ramand.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDapperContext _dapperContext;
        public UserRepository(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<List<UsersDto>> GetUsers()
        {
            using var connection = _dapperContext.CreateConnection();

            var users = await connection.QueryAsync<UsersDto>("GetUsersProcedure", commandType: CommandType.StoredProcedure);

            return users.ToList();
        }

        public async Task<UserDto> GetFirstUser()
        {
            using var connection = _dapperContext.CreateConnection();

            var user = await connection.QueryFirstOrDefaultAsync<UserDto>("GetFirstUser", commandType: CommandType.StoredProcedure);

            return user;
        }
    }
}
