using Microsoft.AspNetCore.Mvc;

namespace WebProject.Controllers
{
    public class NotificationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
