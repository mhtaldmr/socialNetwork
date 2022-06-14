using TP.Net.Hw.Application.Interfaces.Repositories;
using TP.Net.Hw.Infrastructure.Persistence.Context;

namespace TP.Net.Hw.Infrastructure.Repositories
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
