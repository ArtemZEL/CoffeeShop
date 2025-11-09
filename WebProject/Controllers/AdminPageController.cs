using Microsoft.AspNetCore.Mvc;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class AdminPageController : Controller
    {
        private readonly CoffeeRepository _repository;

        public AdminPageController(CoffeeRepository repository)
        {
            _repository = repository;
        }

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
            _repository.AddCoffee(name, img, cell);
            return RedirectToAction("Index","CoffeShop");
        }
    }
}
