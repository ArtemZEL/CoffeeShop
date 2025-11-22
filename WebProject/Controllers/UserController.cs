using Microsoft.AspNetCore.Mvc;
using WebProject.DBStuff.Models.CoffeShop;
using WebProject.DBStuff.Repositories.Interface;
using WebProject.Models.Users;

namespace WebProject.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            var userViewModels = _userRepository.GetAll()
                .Select(x => new UserViewModel
                {
                    UserName = x.UserName,
                })
                .ToList();
            return View(userViewModels);
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(UserViewModel user)
        {
            var userDb = new UserDB
            {
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password,
                AvatarUrl = user.AvatarUrl,
            };
            _userRepository.Add(userDb);
            return RedirectToAction("Index");

        }
    }
}
