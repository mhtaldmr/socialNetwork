using TP.Net.Hw4.Domain.Entity;

namespace TP.Net.Hw4.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUser(int id);  
        Task<IEnumerable<User>> GetAllUsers();  
        void Add(User user); 
        void Delete(User user);
    }
}