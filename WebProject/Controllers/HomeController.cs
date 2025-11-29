using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Xml.Linq;
using WebProject.Models;
using WebProject.Models.Home;
using WebProject.Service;

namespace WebProject.Controllers
{
    public class HomeController : Controller
    {


        private AuthService _authService;

        public HomeController(AuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Index()
        {

            var viewModel = new IndexViewModel();
            if (_authService.IsAuthenticated())
            {
                var id = _authService.GetId();
                var name = _authService.GetUser().UserName;

                viewModel.Id = id;
                viewModel.Name = name;
            }
            else
            {
                viewModel.Id = 0;
                viewModel.Name = "Guess";
            }
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
