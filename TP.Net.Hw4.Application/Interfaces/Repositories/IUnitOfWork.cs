using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.Net.Hw4.Application.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
