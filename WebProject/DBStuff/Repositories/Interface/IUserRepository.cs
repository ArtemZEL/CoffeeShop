using WebProject.DBStuff.Models.CoffeShop;

namespace WebProject.DBStuff.Repositories.Interface
{
    public interface IUserRepository : IBaseRepository<UserDB>
    {
        UserDB Login(string userName, string password);
        void Registration(string userName, string password, string email);
        UserDB? GetByName(string name);
    }
}