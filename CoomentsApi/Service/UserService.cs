using CoffeeApi.DbStuff.Model;
using CooffeeApi.DbStuff;
using System.Diagnostics.Eventing.Reader;

namespace CoffeeApi.Service
{
    public class UserService
    {
        private CoffeeDBContext _coffeeDBContext;

        public UserService(CoffeeDBContext coffeeDBContext)
        {
            _coffeeDBContext = coffeeDBContext;
        }

        public List<UserComments> GetAllCommentsOfUsers()
        {
            return _coffeeDBContext.UserComments.ToList();
        }

        public int CreateComments(string name, string img, string comment)
        {
            var comments = new UserComments
            {
                Name = name,
                Image = img,
                Comment = comment
            };

            _coffeeDBContext.UserComments.Add(comments);
            _coffeeDBContext.SaveChanges();
            return comments.Id;
        }

        public bool UpdateComment(int id, string name, string img, string comment)
        {
            var userComment = _coffeeDBContext.UserComments
                .FirstOrDefault(x => x.Id == id);
            if (userComment == null)
            {
                return false;
            }

            userComment.Name = name;
            userComment.Image = img ;
            userComment.Comment = comment;
            _coffeeDBContext.SaveChanges();
            
            return true;
        }

    }
}
