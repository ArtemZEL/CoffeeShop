namespace WebProject.Models.Users
{
    public class UserPageViewModel
    {
        public string Name { get; set; } = "Guest";

        public string Img { get; set; } = "/image/default.jpg";

        public List<UserCommentViewModel> UserComments { get; set; } = new();
    }
}
