using Ramand.Application.Contracts;
using Ramand.Application.Dtos;
using Ramand.Domain.Contracts;

namespace Ramand.Application.UseCases.UserIntraction
{
    public class UserService : IUserService
    {
        private readonly IRabbitMQService _rabbitMQService;
        public UserService(IRabbitMQService rabbitMQService)
        {
            _rabbitMQService = rabbitMQService;
        }

        public void SendUserToQueue(UserDto user)
        {
            _rabbitMQService.SendMessage(user);
        }
    }
}
