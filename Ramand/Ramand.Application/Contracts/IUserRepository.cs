using Ramand.Application.Dtos;

namespace Ramand.Application.Contracts
{
    public interface IUserRepository
    {
        Task<List<UsersDto>> GetUsers();
        Task<UserDto> GetFirstUser();
    }
}