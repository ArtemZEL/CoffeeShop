using WebProject.Enum;

namespace WebProject.Models.Users
{
    public class ProfileViewModel
    {
        public string UserName { get; set; }


        public Language Language { get; set; }
        public List<Language> Languages { get; set; }
    }
}
