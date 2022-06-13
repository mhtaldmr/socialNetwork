using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Net.Hw4.Application.Interfaces.Repositories;
using TP.Net.Hw4.Domain.Entity;

namespace TP.Net.Hw4.Infrastructure.Repositories
{
    public class UserMessageRepository : IUserMessageRepository
    {
        public async Task<IEnumerable<UserMessage>> GetUserMessage()
        {
            var list = new List<UserMessage>();

            return list;
        }
    }
}
