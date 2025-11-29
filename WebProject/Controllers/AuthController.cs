using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebProject.DBStuff.Repositories;
using WebProject.DBStuff.Repositories.Interface;
using WebProject.Models.Auth;

namespace WebProject.Controllers
{
    public class AuthController : Controller
    {

        public const string AUTH_KEY = "Smile";
        private IUserRepository _userRepository;

        public AuthController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

       
        [HttpGet]
        public IActionResult Login(string? ReturnUrl)
        {
            var viewModel = new AuthViewModel();
            viewModel.ReturnUrl = ReturnUrl;


            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Login(AuthViewModel authViewModel)
        {
            var user = _userRepository.Login(
                authViewModel.UserName,
                authViewModel.Password);

            if (user == null)
            {
                ModelState.AddModelError(nameof(AuthViewModel.UserName), "WRONG Name or Password");
                return View(authViewModel);
            }

            var claims = new List<Claim>
            {
                new Claim("Id",user.Id.ToString()),
                new Claim("UserName",user.UserName),
                new Claim("AvatarUrl",user.AvatarUrl),
                new Claim(ClaimTypes.AuthenticationMethod,AUTH_KEY)
            };

            var identity = new ClaimsIdentity(claims,AUTH_KEY);
            var principal = new ClaimsPrincipal(identity);

            HttpContext.SignInAsync(principal)
                .Wait();

            return 
                !string.IsNullOrEmpty(authViewModel.ReturnUrl)
                ?Redirect(authViewModel.ReturnUrl)
                :RedirectToAction("Index","Home");
        }


        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(AuthViewModel authViewModel)
        {
            _userRepository.Registration(
                authViewModel.UserName,
                authViewModel.Password,
                authViewModel.Email);

            return Login(authViewModel);
               
        }
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync().Wait();
            return RedirectToAction("Index", "Home");


        }



    }
}
