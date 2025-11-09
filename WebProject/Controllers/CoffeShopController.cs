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
        private readonly CoffeeRepository _coffeeRepository;

        public CoffeShopController(CoffeeRepository coffeeRepository)
        {
            _coffeeRepository = coffeeRepository;
        }

        public IActionResult Index()
        {
            var model = new CoffeShopViewModel
            {
                CoffeeProducts = _coffeeRepository.GetAll(),
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
