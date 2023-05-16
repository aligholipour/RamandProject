namespace Ramand.Domain.Contracts
{
    public interface IJwtService
    {
        string GenerateJwt(string userId);
    }
}
