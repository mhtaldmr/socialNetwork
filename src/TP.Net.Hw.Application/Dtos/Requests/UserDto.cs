
namespace TP.Net.Hw.Application.Dtos.Requests
{
    public class UserDto
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegisteredAt { get; set; }
        public bool IsActive { get; set; }
    }
}