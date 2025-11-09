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
        private readonly UserCommentsRepository _userCommentsRepository;

        public CoffeShopController(CoffeeRepository coffeeRepository, UserCommentsRepository userCommentsRepository)
        {
            _coffeeRepository = coffeeRepository;
            _userCommentsRepository = userCommentsRepository;
        }

        public IActionResult Index()
        {
            var model = new CoffeShopViewModel
            {
                CoffeeProducts = _coffeeRepository.GetAll(),
                UserComments = _userCommentsRepository.GetAll()
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
