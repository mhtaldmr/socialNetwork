

namespace TP.Net.Hw.Application.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
