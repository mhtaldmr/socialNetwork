using TP.Net.Hw4.Application.Interfaces.Repositories;
using TP.Net.Hw4.Infrastructure.Persistence.Context;

namespace TP.Net.Hw4.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SocialNetworkDbContext _context;

        public UnitOfWork(SocialNetworkDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
