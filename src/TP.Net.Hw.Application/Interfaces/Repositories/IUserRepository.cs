using TP.Net.Hw.Domain.Entity;

namespace TP.Net.Hw.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUser(int id);  
        Task<IEnumerable<User>> GetAllUsers();  
        IEnumerable<User> GetAllUsersForReport();  
        void Add(User user); 
        void Delete(User user);
    }
}