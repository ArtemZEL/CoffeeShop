using System.ComponentModel.DataAnnotations;

namespace WebProject.Models.Users
{
    public class UserViewModel
    {
        //[Required]
        public string UserName { get; set; }
        
        //[Required]
        //[EmailAddress]
        public string Email { get; set; }

        //[Required]
        public string Password { get; set; }
        public string AvatarUrl { get; set; }
    }
}
