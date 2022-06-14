
using TP.Net.Hw.Application.Dtos.Requests;
using TP.Net.Hw.Domain.Entity;

namespace TP.Net.Hw.Application.Interfaces.Repositories
{
    public interface IUserMessageRepository
    {
        Task<IEnumerable<UserMessage>> GetAllUserMessages(UserMessageQueryDto filter);
        Object GetMetaData(UserMessageQueryDto filter);
    }
}