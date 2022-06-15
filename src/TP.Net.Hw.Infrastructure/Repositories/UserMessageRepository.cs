using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TP.Net.Hw.Application.Dtos.Requests;
using TP.Net.Hw.Application.Interfaces.Repositories;
using TP.Net.Hw.Domain.Entity;
using TP.Net.Hw.Infrastructure.Common.Extensions;
using TP.Net.Hw.Infrastructure.Persistence.Context;

namespace TP.Net.Hw.Infrastructure.Repositories
{
    public class UserMessageRepository : IUserMessageRepository
    {
        private readonly SocialNetworkDbContext _context;
        private int _totalItems;

        public UserMessageRepository(SocialNetworkDbContext context) => _context = context;

        //Taking All th messages and filtering them!
        public async Task<IEnumerable<UserMessage>> GetAllUserMessages(UserMessageQueryDto queryObj)
        {
            //taking the datas from the database
            var query = _context.UserMessages
                .Include(u => u.Sender)
                .Include(u => u.Receiver)
                .Include(m => m.MessageType)
                .AsQueryable();
            
            //creating a dictionary for sorting query for expresions
            var messageColumns = new Dictionary<string, Expression<Func<UserMessage, object>>>()
            {
                ["Id"] = m => m.Id,
                ["messagebody"] = m => m.MessageBody,
                ["createdAt"] = m => m.CreatedAt,
            };

            //Applying filters, orderings and paging
            query = query.ApplyOrdering(queryObj, messageColumns);
            query = query.ApplyFiltering(queryObj);

            //setting the total items filtered! and this will send in the header By GgetMetaData method!
            _totalItems = await query.CountAsync();
            query = query.ApplyPaging(queryObj);

            return await query.ToListAsync();
        }

        //Sending the total pages and everything else for Header Response.
        public object GetMetaData(UserMessageQueryDto queryObj)
        {
            int totalPage = (int)Math.Ceiling(_totalItems / (double)queryObj.PageSize);
            bool hasPrevious = queryObj.Page > 1;
            bool hasNext = queryObj.Page < totalPage;

            return new { _totalItems, queryObj.Page, queryObj.PageSize, totalPage, hasNext, hasPrevious };   
        }
    }
}
