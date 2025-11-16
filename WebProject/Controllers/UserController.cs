using Microsoft.AspNetCore.Mvc;

namespace WebProject.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
