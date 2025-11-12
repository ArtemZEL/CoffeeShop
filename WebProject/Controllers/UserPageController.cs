using Microsoft.AspNetCore.Mvc;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class UserPageController : Controller
    {
        private readonly UserCommentsRepository _commentsRepository;

        public UserPageController(UserCommentsRepository commentsRepository)
        {
            _commentsRepository = commentsRepository;
        }


        public IActionResult AddComments()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new UserComment
            {
                Name = "Guest",
                Img = "/image/default.jpg"
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(string comments)
        {
            _commentsRepository.Add("Guest",comments);
            return RedirectToAction("Index", "CoffeShop");
        }



        public IActionResult Index()
        {
            return View();
        }
    }
}
