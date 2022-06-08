using MuhammetAliDemir.TP.Net.Hw4.Domain.Common;

namespace MuhammetAliDemir.TP.Net.Hw4.Domain.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime RegisteredAt { get; set; }
        public bool IsActive { get; set; }
    }
}
