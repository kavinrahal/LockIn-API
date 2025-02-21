using LockIn_API.Entities;

namespace LockIn_API.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
