
using TP.Net.Hw.Domain.Entity;

namespace TP.Net.Hw.Application.Interfaces.Repositories
{
    public interface IAccountRepository
    {
        Task<User> GetRefreshToken(string refreshToken);
    }
}