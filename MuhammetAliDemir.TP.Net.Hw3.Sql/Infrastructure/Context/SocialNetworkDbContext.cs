using Microsoft.EntityFrameworkCore;

namespace MuhammetAliDemir.TP.Net.Hw3.Sql.Infrastructure.Context
{
    public class SocialNetworkDbContext : DbContext
    {
        public SocialNetworkDbContext(DbContextOptions<SocialNetworkDbContext> options) : base(options)
        {
        }


    }
}
