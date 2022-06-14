using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Net.Hw4.Domain.Entity;

namespace TP.Net.Hw4.Application.Interfaces.Repositories
{
    public interface IAccountRepository
    {
        Task<User>? GetRefreshToken(string refreshToken);
    }
}
