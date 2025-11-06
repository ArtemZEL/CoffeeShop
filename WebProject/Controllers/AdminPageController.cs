using Microsoft.AspNetCore.Mvc;
using WebProject.Models;

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

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Add(string name, string img, int cell )
        {
            var newCoffee = new CoffeeProduct
            {
                Name = name,
                Img = img,
                Cell = cell
            };
            CoffeeRepository.CoffeeProducts.Add(newCoffee);
            return View("Index","CoffeShop");
        }



    }
}
