using Microsoft.EntityFrameworkCore;
using MuhammetAliDemir.TP.Net.Hw3.Sql.Domain.Entity;

namespace MuhammetAliDemir.TP.Net.Hw3.Sql.Infrastructure.Context
{
    public class SocialNetworkDbContext : DbContext
    {
        public SocialNetworkDbContext(DbContextOptions<SocialNetworkDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
