
using TP.Net.Hw.Application.Interfaces.Repositories;
using TP.Net.Hw.Application.Interfaces.Services;

namespace TP.Net.Hw.Infrastructure.Services
{
    public class ReportService : IReportService
    {
        private readonly IUserRepository _repository;

        public ReportService(IUserRepository repository)
        {
            _repository = repository;
        }
        public void SendExcelReport(string path)
        {
            var users = _repository.GetAllUsers();

        }
    }
}
