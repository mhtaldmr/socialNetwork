using TP.Net.Hw.Domain.Entity;

namespace TP.Net.Hw.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUser(int id);  
        Task<IEnumerable<User>> GetAllUsers();  
        void Add(User user); 
        void Delete(User user);
    }
}