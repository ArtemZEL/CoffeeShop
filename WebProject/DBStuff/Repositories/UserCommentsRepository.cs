using System.Collections.Generic;
using WebProject.DBStuff;
using WebProject.DBStuff.Models.CoffeShop;

namespace WebProject.DBStuff.Repositories
{
    public class UserCommentsRepository
    {


        private readonly WebProjectContext _dbContext;

        public UserCommentsRepository(WebProjectContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<UserCommentsDB> GetAll()
        {
            return _dbContext.UserComments.ToList();
        }

        public void AddComments(string name, string comments, string? img = null)
        {
            var newComments = new UserCommentsDB
            {
                Name = string.IsNullOrWhiteSpace(name) ? "Guest" : name,
                Img = string.IsNullOrWhiteSpace(img) ? "/image/default.jpg" : img,
                Comments = comments
            };

            _dbContext.UserComments.Add(newComments);
            _dbContext.SaveChanges();
        }
    }
}
