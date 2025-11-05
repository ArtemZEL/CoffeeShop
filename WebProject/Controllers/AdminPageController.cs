using Microsoft.AspNetCore.Mvc;

namespace WebProject.Controllers
{
    public class AdminPageController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult AddPageCoffee()
        {
            return View();
        }
    }
}
