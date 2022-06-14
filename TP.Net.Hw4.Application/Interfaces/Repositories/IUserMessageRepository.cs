
using TP.Net.Hw4.Application.Dtos.Requests;
using TP.Net.Hw4.Application.Dtos.Responses;
using TP.Net.Hw4.Domain.Entity;

namespace TP.Net.Hw4.Application.Interfaces.Repositories
{
    public interface IUserMessageRepository
    {
        Task<IEnumerable<UserMessage>> GetAllUserMessages(UserMessageQueryDto filter);
        Object GetMetaData(UserMessageQueryDto filter);
    }
}