using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebProject.Controllers.CustomAuthorizeAttributtes;
using WebProject.DBStuff;
using WebProject.DBStuff.Models.CoffeShop;
using WebProject.DBStuff.Repositories;
using WebProject.DBStuff.Repositories.Interface;
using WebProject.Enum;
using WebProject.Models;
using WebProject.Models.Users;
using WebProject.Service;
using WebProject.Service.Flie;
using WebProject.Service.Permissions;

namespace WebProject.Controllers
{
    [Authorize]
    public class AdminPageController : Controller
    {
        private readonly ICoffeeRepository _repositoryCoffee;
        private readonly ICategoryRepository _categoryRepository;
        private WebProjectContext _webProjectDBContext;
        private AuthService _authService;
        private ICoffeShopPermision _coffeShopPermision;
        private IProfileFileService _profileFileService;
        private IUserRepository _userRepository;
        public AdminPageController(ICoffeeRepository repository, WebProjectContext webProjectDBContext, ICategoryRepository categoryRepository, AuthService authService, ICoffeShopPermision coffeShopPermision, IProfileFileService profileFileService, IUserRepository userRepository)
        {
            _repositoryCoffee = repository;
            _webProjectDBContext = webProjectDBContext;
            _categoryRepository = categoryRepository;
            _authService = authService;
            _coffeShopPermision = coffeShopPermision;
            _profileFileService = profileFileService;
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddingCoffee()
        {

            var currentuserId = _authService.IsAuthenticated()
                ? _authService.GetId()
                : -1;
            var modelAddingCoffee = new CoffeShopViewModel
            {
                CoffeeProducts = _repositoryCoffee.GetAllWithAuthors()
                .Select(db => new CoffeeProductViewModel
                {
                    Id = db.Id,
                    Name = db.Name,
                    Img = db.Img,
                    Cell = db.Cell,
                    AuthorName = db.AuthorAdd?.UserName ?? "No author",
                    CanDelete = _coffeShopPermision.CanFindPage(db),
                    CategoryId = db.CategoryId,
                    CategoryName = db.Category != null ? db.Category.Name : "No category"
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
        public IActionResult AddPageCoffee()
        {
            var categories = _categoryRepository.GetAll();
            var viewModel = new CoffeeCreationViewModel
            {
                CategoryNameList = categories.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList()
            };

            return View(viewModel);
        }



        [HttpPost]
        public IActionResult AddPageCoffee(CoffeeCreationViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
                var categories = _categoryRepository.GetAll();
                productViewModel.CategoryNameList = categories.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList();

                return View(productViewModel);
            }
            var currentUserId = _authService.GetId();
            var newCoffee = new CoffeeProductDB
            {
                Name = productViewModel.Name,
                Img = productViewModel.Img,
                Cell = productViewModel.Cell,
                CategoryId = productViewModel.CategoryId,
                AuthorId = currentUserId
            };

            _repositoryCoffee.Add(newCoffee);

            return RedirectToAction("AddingCoffee", "AdminPage");
        }

        //Add Category
        [HttpGet]
        [Role(Role.SuperAdmin, Role.Admin)]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        [Role(Role.SuperAdmin, Role.Admin)]
        public IActionResult AddCategory(string name)
        {

            var newCategory = new CategoryDB
            {
                Name = name,
            };
            _categoryRepository.Add(newCategory);
            return RedirectToAction("Index");
        }

        //Edit Coffee
        [HttpGet]
        [Role(Role.SuperAdmin, Role.Admin)]
        public IActionResult EditCoffee(int id)
        {
            var coffee = _repositoryCoffee.GetFirstById(id);
            if (coffee == null)
            {
                return NotFound();
            }
            var categories = _categoryRepository.GetAll();
            var viewModel = new CoffeeProductViewModel
            {
                Id = coffee.Id,
                Name = coffee.Name,
                Img = coffee.Img,
                Cell = coffee.Cell,
                CategoryId = coffee.CategoryId,
                CategoryNameList = categories.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString(),
                    Selected = x.Id == coffee.CategoryId
                }).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult EditCoffee(CoffeeProductViewModel productViewModel)
        {
            var existingCoffee = _repositoryCoffee.GetFirstById(productViewModel.Id);
            if (existingCoffee == null)
            {
                return NotFound();
            }

            existingCoffee.Name = productViewModel.Name;
            existingCoffee.Img = productViewModel.Img;
            existingCoffee.Cell = productViewModel.Cell;
            existingCoffee.CategoryId = productViewModel.CategoryId;

            _repositoryCoffee.Update(existingCoffee);
            return RedirectToAction("AddingCoffee");
        }

        [HttpGet]
        [Role(Role.SuperAdmin)]
        public IActionResult AllAvatarsUser()
        {
            var user = _userRepository
                .GetAll()
                .Select(x => new AllUsersAndProfileViewModel
                {
                    Id = x.Id,
                    Name = x.UserName
                }).ToList();

            return View(user);
        }

        [Role(Role.SuperAdmin)]
        public IActionResult DeleteAvatarsUser(int userId)
        {

            _profileFileService.ReplaceToAvatarToDefault(userId);

            return RedirectToAction("AllAvatarsUser");
        }



    }
}
