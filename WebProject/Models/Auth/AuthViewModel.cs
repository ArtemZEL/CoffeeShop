using System.ComponentModel.DataAnnotations;

namespace WebProject.Models.Auth
{
    public class AuthViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public string Email { get; set; }
        public string ?ReturnUrl { get;  set; }
    }
}
