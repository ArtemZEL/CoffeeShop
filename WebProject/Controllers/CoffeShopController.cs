using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class CoffeShopController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        public IActionResult Index()
        {
            var model = new CoffeShopViewModel
            {
                CoffeeProducts = CoffeeRepository.CoffeeProducts,
                UserComments = new List<string>
                {
                    "/image/rev1.jpg",
                    "/image/rev2.jpg",
                    "image/rev3.jpg"
                }
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
