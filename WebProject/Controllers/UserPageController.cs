using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebProject.DBStuff.Models.CoffeShop;
using WebProject.DBStuff.Repositories.Interface;
using WebProject.Models;

namespace WebProject.Controllers
{
    [Authorize]
    public class UserPageController : Controller
    {
        private readonly IUserCommentsRepository _userCommentsRepository;
        public UserPageController(IUserCommentsRepository userCommentsRepository)
        {
            _userCommentsRepository = userCommentsRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(UserCommentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }
            _userCommentsRepository.Add(new UserCommentsDB
            {
                Name = User.Identity?.Name ?? "Guest",
                Img = "/image/default.jpg",
                Comments=model.Comments
            });
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id) 
        {
            _userCommentsRepository.Remove(id);
            return RedirectToAction("Index");
        }

    }
}
