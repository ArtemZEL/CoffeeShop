using WebProject.DBStuff.Models.CoffeShop;
using WebProject.DBStuff.Repositories.Interface;

namespace WebProject.DBStuff.Repositories
{
    public class UserRepository : BaseRepository<UserDB>, IUserRepository
    {

        public UserRepository(WebProjectContext portalContexnt) : base(portalContexnt)
        {

        }




    }
}
