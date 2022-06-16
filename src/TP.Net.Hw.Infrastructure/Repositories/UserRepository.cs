using Microsoft.EntityFrameworkCore;
using TP.Net.Hw.Application.Interfaces.Repositories;
using TP.Net.Hw.Domain.Entity;
using TP.Net.Hw.Infrastructure.Persistence.Context;

namespace TP.Net.Hw.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SocialNetworkDbContext _context;

        public UserRepository(SocialNetworkDbContext context)
        {
            _context = context;
        }


        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user is null)
                throw new ArgumentNullException("Userid does not exist!");

            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();

            return users;
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
        }

    }
}
