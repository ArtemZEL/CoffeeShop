using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebProject.DBStuff;
using WebProject.DBStuff.Models.CoffeShop;
using WebProject.DBStuff.Repositories.Interface;
using WebProject.Models.Users;

namespace WebProject.Controllers
{
    [Authorize]
    public class UserPageController : Controller
    {
        private readonly IUserCommentsRepository _userCommentsRepository;
        private readonly WebProjectContext _dbContext;
        public UserPageController(IUserCommentsRepository userCommentsRepository, WebProjectContext dbContext)
        {
            _userCommentsRepository = userCommentsRepository;
            _dbContext = dbContext;
        }

        private UserDB? GetCurrentUser()
        {
            var userName = User.Identity?.Name;

            if (string.IsNullOrEmpty(userName))
                return null;

            return _dbContext.Users
                .FirstOrDefault(x => x.UserName == userName);
        }

        [HttpGet]
        public IActionResult Index()
        {
            var user = GetCurrentUser();

            if (user == null)
                return NotFound();

            var model = new UserPageViewModel
            {
                Name = user.UserName,

                Img = string.IsNullOrEmpty(user.AvatarUrl)
                    ? "/image/default.jpg"
                    : user.AvatarUrl,

                UserComments = _userCommentsRepository
                    .GetAll()
                    .Where(x => x.UserId == user.Id)
                    .Select(x => new UserCommentViewModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Img = x.Img,
                        Comments = x.Comments
                    })
                    .ToList()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(UserCommentViewModel model)
        {
            var user = GetCurrentUser();

            if (user == null)
                return NotFound();

            if (string.IsNullOrWhiteSpace(model.Comments))
            {
                return RedirectToAction(nameof(Index));
            }

            var newComment = new UserCommentsDB
            {
                UserId = user.Id,
                Name = user.UserName,
                Img = string.IsNullOrEmpty(user.AvatarUrl)
                    ? "/image/default.jpg"
                    : user.AvatarUrl,
                Comments = model.Comments
            };

            _userCommentsRepository.Add(newComment);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var user = GetCurrentUser();

            if (user == null)
                return NotFound();

            var comment = _userCommentsRepository
                .GetAll()
                .FirstOrDefault(x => x.Id == id);

            if (comment == null)
                return NotFound();

            if (comment.UserId != user.Id)
                return Forbid();

            _userCommentsRepository.Remove(comment);

            return RedirectToAction(nameof(Index));
        }

    }
}
