using System.ComponentModel.DataAnnotations;

namespace API.DTO
{
    public class RegisterDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [Compare("Password",ErrorMessage="Password Not Matching")]
        public string ConfirmPassword { get; set; }
        public string? Address { get; set; }
    }
}
