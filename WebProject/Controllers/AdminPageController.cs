using Microsoft.AspNetCore.Mvc;
using WebProject.DBStuff.Models.CoffeShop;
using WebProject.DBStuff;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class AdminPageController : Controller
    {
        private readonly CoffeeRepository _repository;
        private WebProjectContext _webProjectDBContext;

        public AdminPageController(CoffeeRepository repository, WebProjectContext webProjectDBContext)
        {
            _repository = repository;
            _webProjectDBContext = webProjectDBContext;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult AddPageCoffee()
        {
            return View(new CoffeeProductDB());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Add(string name, string img, decimal cell )
        {
            var newCoffee = new CoffeeProductDB
            {
                Name = name,
                Img = img,
                Cell = cell
            };

            _webProjectDBContext.CoffeeProducts.Add(newCoffee);
            _webProjectDBContext.SaveChanges();

            return RedirectToAction("Index","CoffeShop");
        }
    }
}
