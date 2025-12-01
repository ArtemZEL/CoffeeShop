using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebProject.DBStuff.Models.CoffeShop;
using WebProject.DBStuff.Repositories;
using WebProject.DBStuff.Repositories.Interface;
using WebProject.Enum;
using WebProject.Models.Users;
using WebProject.Service;
using WebProject.Service.Flie;

namespace WebProject.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository _userRepository;
        private readonly AuthService _authService;
        private IWebHostEnvironment _webHostEnvironment;
        private IProfileFileService _profileFileService;

        public UserController(IUserRepository userRepository, AuthService authService, IWebHostEnvironment webHostEnvironment, IProfileFileService profileFileService)
        {
            _userRepository = userRepository;
            _authService = authService;
            _webHostEnvironment = webHostEnvironment;
            _profileFileService = profileFileService;
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
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            _userRepository.Registration(user.UserName,user.Password,user.Email);
            return RedirectToAction("Index");

        }

        
        [Authorize]
        public IActionResult Profile()
        {
            var viewModel = new ProfileViewModel();

            viewModel.UserName = _authService.GetUserName();
            viewModel.Languages = System
                .Enum
                .GetValues<Language>()
                .ToList();
            viewModel.Language = _authService.GetLanguage();
            var userIdAvatar = _authService.GetId();
            viewModel.AvatarUrl = $"/image/avatar/{userIdAvatar}.jpg";
            return View(viewModel);
        }

        [Authorize]
        public IActionResult ChangeLanguage(Language language)
        {
            var user = _authService.GetUser();
            user.Language = language;
            _userRepository.Update(user);
            return RedirectToAction("Index", "CoffeShop");
        }

        [HttpPost]
        [Authorize]
        public IActionResult UpdateAvatar(IFormFile avatar)
        {
            _profileFileService.UploadAvatar(avatar);   
            return RedirectToAction("Profile");
        }



    }
}
