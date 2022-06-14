using Microsoft.EntityFrameworkCore;
using TP.Net.Hw4.Application.Interfaces.Repositories;
using TP.Net.Hw4.Domain.Entity;
using TP.Net.Hw4.Infrastructure.Persistence.Context;

namespace TP.Net.Hw4.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly SocialNetworkDbContext _context;

        public AccountRepository(SocialNetworkDbContext context) =>  _context = context;
        

        public async Task<User>? GetRefreshToken(string refreshToken)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken && u.RefreshTokenExpireDate > DateTime.Now);
        }
    }
}
