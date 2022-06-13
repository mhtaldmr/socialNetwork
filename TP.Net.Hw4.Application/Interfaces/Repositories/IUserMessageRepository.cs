
using TP.Net.Hw4.Domain.Entity;

namespace TP.Net.Hw4.Application.Interfaces.Repositories
{
    public interface IUserMessageRepository
    {
        Task<IEnumerable<UserMessage>> GetUserMessage();
    }
}