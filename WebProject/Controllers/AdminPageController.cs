using Microsoft.AspNetCore.Mvc;
using WebProject.DBStuff.Models.CoffeShop;
using WebProject.DBStuff;
using WebProject.Models;
using WebProject.DBStuff.Repositories;
using WebProject.DBStuff.Repositories.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebProject.Controllers
{
    public class AdminPageController : Controller
    {
        private readonly ICoffeeRepository _repositoryCoffee;
        private readonly ICategoryRepository _categoryRepository;
        private WebProjectContext _webProjectDBContext;

        public AdminPageController(ICategoryRepository categoryRepository, ICoffeeRepository repository, WebProjectContext webProjectDBContext)
        {
            _repositoryCoffee = repository;
            _webProjectDBContext = webProjectDBContext;
            _categoryRepository = categoryRepository;
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
        [HttpGet]
        public IActionResult Add()
        {
            var category = _categoryRepository.GetAll();
            var viewModel = new CoffeeProductViewModel();
            viewModel.AllCategory = category.Select(x=>new SelectListItem
            { 
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Add(CoffeeProductViewModel productViewModel)
        {

            var authorCoffeeId = productViewModel.AuthorId;
            var categoryCoffeeId = productViewModel.CategoryId;

            var category = _categoryRepository.GetFirstById(categoryCoffeeId);


            var newCoffee = new CoffeeProductDB()
            {
                Name = productViewModel.Name,
                Img = productViewModel.Img,
                Cell = productViewModel.Cell,
                CreatedCategory = new List<CategoryDB> { category }
            };
            _repositoryCoffee.Add(newCoffee);
            return RedirectToAction("Index","CoffeShop");
        }

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
