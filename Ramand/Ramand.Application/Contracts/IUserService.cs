using Ramand.Application.Dtos;

namespace Ramand.Application.Contracts
{
    public interface IUserService
    {
        void SendUserToQueue(UserDto user);
    }
}