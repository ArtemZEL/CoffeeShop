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
            return View();
        }


        [HttpGet]
        public IActionResult AddingCoffee()
        {
            var modelAddingCoffee = new CoffeShopViewModel
            {

                CoffeeProducts = _webProjectDBContext.CoffeeProducts
                .Select(db => new CoffeeProductViewModel
                {
                    Id = db.Id,
                    Name = db.Name,
                    Img = db.Img,
                    Cell = db.Cell,
                }).ToList(),

            };
            return View(modelAddingCoffee);
        }


        //Remove Coffee
        public IActionResult RemoveCoffee(int id)
        {
            var coffee = _webProjectDBContext.CoffeeProducts.First(p => p.Id == id);
            _webProjectDBContext.CoffeeProducts.Remove(coffee);
            _webProjectDBContext.SaveChanges();
            return RedirectToAction("AddingCoffee");
        }

        //Add Coffee
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
