using System.Collections.Generic;

namespace WebProject.Models
{
    public class UserCommentsRepository
    {
        private readonly List<UserComment> _userComments = new();

        public List<UserComment> GetAll()=> _userComments;

        public void Add(string name, string comments)
        {
            var newComments = new UserComment
            {
                Name = name,
                Img = "/image/default.jpg",
                Comments = comments
            };
            _userComments.Add(newComments);

        }
    }
}
