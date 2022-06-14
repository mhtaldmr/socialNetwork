
using TP.Net.Hw.Application.Interfaces.Repositories;
using TP.Net.Hw.Application.Interfaces.Services;

namespace TP.Net.Hw.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly IUserRepository _repository;

        public EmailService(IUserRepository repository)
        {
            _repository = repository;
        }
        public void SendEmailReport()
        {
            var user = _repository.GetAllUsers();
            
        }
    }
}
