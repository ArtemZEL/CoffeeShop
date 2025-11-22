using Microsoft.AspNetCore.Mvc;
using WebProject.DBStuff.Models.CoffeShop;
using WebProject.DBStuff;
using WebProject.Models;
using WebProject.DBStuff.Repositories;
using WebProject.DBStuff.Repositories.Interface;

namespace WebProject.Controllers
{
    public class AdminPageController : Controller
    {
        private readonly ICoffeeRepository _repository;
        private WebProjectContext _webProjectDBContext;

        public AdminPageController(ICoffeeRepository repository, WebProjectContext webProjectDBContext)
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
                CoffeeProducts = _repository.GetAllWithAuthors()
                .Select(db => new CoffeeProductViewModel
                {
                    Id = db.Id,
                    Name = db.Name,
                    Img = db.Img,
                    Cell = db.Cell,
                    AuthorName = db.AuthorAdd != null ? db.AuthorAdd.UserName : "Unknown"
                }).ToList(),

            };
            return View(modelAddingCoffee);
        }


        //Remove Coffee
        public IActionResult RemoveCoffee(int id)
        {
            _repository.Remove(id);
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
            _repository.Add(newCoffee);
            return RedirectToAction("Index","CoffeShop");
        }
    }
}
