using Microsoft.EntityFrameworkCore;
using WebProject.DBStuff.Models.CoffeShop;
using WebProject.DBStuff.Repositories.Interface;

namespace WebProject.DBStuff.Repositories
{
    public class UserRepository : BaseRepository<UserDB>, IUserRepository
    {
        public UserRepository(WebProjectContext portalContexnt) : base(portalContexnt)
        {

        }

        public override UserDB Add(UserDB model)
        {
            throw new Exception("Do not use Add.User Registration method");
        }


        public UserDB Login(string userName, string password)
        {
            var hashPassword = HashPassword(password);
            return _dbSet.First(x => x.UserName == userName && x.Password == hashPassword);
        }

        public void Registration(string userName, string password,string email)
        {
            var user = new UserDB
            {
                UserName = userName,
                Password = HashPassword(password),
                Email = email,
                AvatarUrl ="/image/default.jpg"
            };

            _dbSet.Add(user);
            _portalContext.SaveChanges();
        }


        private string HashPassword(string password)
        {
            return password.Replace("d", "") + password.Length;
        }

    }
}
