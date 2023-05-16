namespace Ramand.Domain.Contracts
{
    public interface IRabbitMQService
    {
        void SendMessage<T>(T message);
    }
}