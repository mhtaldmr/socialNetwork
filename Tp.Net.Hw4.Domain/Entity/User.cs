using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP.Net.Hw4.Domain.Entity
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RegisteredAt { get; set; }
        public bool IsActive { get; set; }
    }
}
