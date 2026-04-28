using WebProject.DBStuff.Models.CoffeShop;
using WebProject.Enum;

namespace WebProject.Service
{
    public interface IAuthService
    {
        int GetId();
        Language GetLanguage();
        UserDB GetUser();
        string GetUserName();
        bool IsAdmin();
        bool IsAuthenticated();
    }
}