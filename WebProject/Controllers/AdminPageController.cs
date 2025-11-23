using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebProject.DBStuff;
using WebProject.DBStuff.Models.CoffeShop;
using WebProject.DBStuff.Repositories;
using WebProject.DBStuff.Repositories.Interface;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class AdminPageController : Controller
    {
        private readonly ICoffeeRepository _repositoryCoffee;
        private readonly ICategoryRepository _categoryRepository;
        private WebProjectContext _webProjectDBContext;

        public AdminPageController(ICoffeeRepository repository, WebProjectContext webProjectDBContext, ICategoryRepository categoryRepository)
        {
            _repositoryCoffee = repository;
            _webProjectDBContext = webProjectDBContext;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public IActionResult AddPageCoffee()
        {
            var categories = _categoryRepository.GetAll();
            var viewModel = new CoffeeProductViewModel
            {
                CategoryNameList = categories.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList()
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult AddingCoffee()
        {
            var modelAddingCoffee = new CoffeShopViewModel
            {
                CoffeeProducts = _repositoryCoffee.GetAllWithAuthors()
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
            _repositoryCoffee.Remove(id);
            return RedirectToAction("AddingCoffee");
        }

        //Add Coffee
        

        [HttpPost]
        public IActionResult AddPageCoffee(CoffeeProductViewModel productViewModel)
        {
            var newCoffee = new CoffeeProductDB
            {
                Name = productViewModel.Name,
                Img = productViewModel.Img,
                Cell = productViewModel.Cell,
                CategoryId = productViewModel.CategoryId
            };
            _repositoryCoffee.Add(newCoffee);

            return RedirectToAction("Index","CoffeShop");
        }

        //Add Category
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(string name)
        {

            var newCategory = new CategoryDB
            {
                Name = name,
            };
            _categoryRepository.Add(newCategory);
            return RedirectToAction("Index");
        }

        }
}
