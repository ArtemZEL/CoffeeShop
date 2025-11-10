using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebProject.DBStuff;
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
        private WebProjectContext _webProjectContext;


        public CoffeShopController(CoffeeRepository coffeeRepository, UserCommentsRepository userCommentsRepository, WebProjectContext webProjectContext)
        {
            _coffeeRepository = coffeeRepository;
            _userCommentsRepository = userCommentsRepository;
            _webProjectContext = webProjectContext;
        }

        public IActionResult Index()
        {
            var model = new CoffeShopViewModel
            {
                CoffeeProducts = _webProjectContext.CoffeeProducts.Select(x=>new CoffeeProductViewModel
                { 
                    Name = x.Name,
                    Img = x.Img,
                    Cell = x.Cell
                }).ToList(),
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
