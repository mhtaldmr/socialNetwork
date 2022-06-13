using TP.Net.Hw4.Application.Interfaces.Repositories;
using TP.Net.Hw4.Domain.Entity;
using TP.Net.Hw4.Infrastructure.Persistence.Context;


namespace TP.Net.Hw4.Infrastructure.Repositories
{
    public class UserMessageRepository : IUserMessageRepository
    {
        private readonly SocialNetworkDbContext _context;

        public UserMessageRepository(SocialNetworkDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserMessage>> GetAllUserMessages(UserMessageQuery queryObj)
        {
            var result = new List<UserMessage>();

            var query = _context.UserMessages.AsQueryable();

            

            if(!string.IsNullOrWhiteSpace(queryObj.MessageBody))
                query = _context.UserMessages.Where(m => m.MessageBody.Contains(queryObj.MessageBody));

            if (queryObj.CreatedAt.HasValue)
                query = _context.UserMessages.Where(m => m.CreatedAt > queryObj.CreatedAt.Value);


            if (queryObj.Page <= 0)
                queryObj.Page = 1;

            if (queryObj.PageSize <= 0)
                queryObj.PageSize = 5;

            query = query.Skip((queryObj.Page -1) * queryObj.PageSize).Take(queryObj.PageSize);



            result = query.ToList();

            return result;
        }
    }
}
