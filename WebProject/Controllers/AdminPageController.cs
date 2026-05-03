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
using WebProject.Models.CoffeeShop;
using WebProject.Models.Users;
using WebProject.Service;
using WebProject.Service.Flie;
using WebProject.Service.Permissions;

namespace WebProject.Controllers
{
    [Authorize]
    [Role(Role.User)]
    public class AdminPageController : Controller
    {
        private readonly ICoffeeRepository _repositoryCoffee;
        private readonly ICategoryRepository _categoryRepository;
        private WebProjectContext _webProjectDBContext;
        private IAuthService _authService;
        private ICoffeShopPermision _coffeShopPermision;
        private IProfileFileService _profileFileService;
        private IUserRepository _userRepository;
        private ISliderFileServices _sliderFileServices;

        public AdminPageController(ICoffeeRepository repository, 
            WebProjectContext webProjectDBContext, 
            ICategoryRepository categoryRepository, 
            IAuthService authService, 
            ICoffeShopPermision coffeShopPermision, 
            IProfileFileService profileFileService, 
            IUserRepository userRepository, 
            ISliderFileServices sliderFileServices)
        {
            _repositoryCoffee = repository;
            _webProjectDBContext = webProjectDBContext;
            _categoryRepository = categoryRepository;
            _authService = authService;
            _coffeShopPermision = coffeShopPermision;
            _profileFileService = profileFileService;
            _userRepository = userRepository;
            _sliderFileServices = sliderFileServices;
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
                    CanFindPage = _coffeShopPermision.CanFindPage(db),
                    CategoryId = db.CategoryId,
                    CategoryName = db.Category != null ? db.Category.Name : "No category"
                }).ToList(),

            };
            return View(modelAddingCoffee);
        }


        //Remove Coffee
        public IActionResult RemoveCoffee(int id)
        {
            var coffee = _repositoryCoffee.GetFirstById(id);
            if (!_coffeShopPermision.CanFindPage(coffee))
            {
                return Forbid();
            }

            _repositoryCoffee.Remove(coffee);
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

        //Edit Coffee
        [HttpGet]
        public IActionResult EditCoffee(int id)
        {
            var coffee = _repositoryCoffee.GetFirstById(id);
            if (coffee == null)
            {
                return NotFound();
            }
            if (!_coffeShopPermision.CanFindPage(coffee))
            {
                return Forbid();
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
            if (!_coffeShopPermision.CanFindPage(existingCoffee))
            {
                return Forbid();
            }

            existingCoffee.Name = productViewModel.Name;
            existingCoffee.Img = productViewModel.Img;
            existingCoffee.Cell = productViewModel.Cell;
            existingCoffee.CategoryId = productViewModel.CategoryId;

            _repositoryCoffee.Update(existingCoffee);
            return RedirectToAction("AddingCoffee");
        }

        [HttpGet]
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

        public IActionResult DeleteAvatarsUser(int userId)
        {
            _profileFileService.ReplaceToAvatarToDefault(userId);
            return RedirectToAction("AllAvatarsUser");
        }
        
        public IActionResult UpdateImagePage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdateImagePage(IFormFile pageimage)
        {
            _sliderFileServices.UploudFonCoffeShop(pageimage);
            return RedirectToAction("Index");
        }
        public IActionResult ManageGallery()
        {
            var model = new CoffeeProductViewModel
            {
                GalleryImages = _sliderFileServices.GetFonGallery()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult RemoveImage(string fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                _sliderFileServices.RemoveImageSlider(fileName);
            }
            return RedirectToAction("ManageGallery");
        }


        //[Role(Role.Admin)]
        public IActionResult CoffeeStatistics()
        {
            var coffeeDetails = _repositoryCoffee.GetCoffeeDetail();
            var coffeeSummary = _repositoryCoffee.GetCoffeeSummary();

            var model = new CoffeeStatisticsViewModel
            {
                CoffeDetails = coffeeDetails,
                CoffeeSummary = coffeeSummary
            };

            return View(model);
        }

        //Test AJAX method the next update deleting 
        [HttpPost]
        public IActionResult EdditCoffeeName(int id, string name)
        {
            var coffeProduct = _repositoryCoffee.GetFirstById(id);
            if (coffeProduct == null)
            {
                return Json(new { success = false, message = "Продукт не найден" });
            }

            var user = _authService.GetUser();
            if (coffeProduct.AuthorAdd != user)
            {
                return Json(false);
            }

            coffeProduct.Name = name;
            _repositoryCoffee.Update(coffeProduct);

            return Json(true);
        }

        [HttpPost]
        public IActionResult RemoveCoffeJs(int id)
        {
            _repositoryCoffee.Remove(id);
            return Json(new { success = true });
        }

    }
}
