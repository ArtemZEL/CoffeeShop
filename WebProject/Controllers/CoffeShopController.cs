using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebProject.DBStuff;
using WebProject.DBStuff.Repositories;
using WebProject.DBStuff.Repositories.Interface;
using WebProject.Models;
using WebProject.Models.CoffeeShop;
using WebProject.Models.Users;
using WebProject.Service.Flie;

namespace WebProject.Controllers
{
    public class CoffeShopController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private readonly ICoffeeRepository _coffeeRepository;
        private readonly IUserCommentsRepository _userCommentsRepository;
        private WebProjectContext _webProjectContext;
        private readonly ISliderFileServices _sliderFileServices;


        public CoffeShopController(
            ICoffeeRepository coffeeRepository,
            IUserCommentsRepository userCommentsRepository,
            WebProjectContext webProjectContext,
            ISliderFileServices sliderFileServices)
        {
            _coffeeRepository = coffeeRepository;
            _userCommentsRepository = userCommentsRepository;
            _webProjectContext = webProjectContext;
            _sliderFileServices = sliderFileServices;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            var model = new CoffeShopViewModel
            {
                CoffeeProducts = _coffeeRepository.GetAll().Select(x => new CoffeeProductViewModel
                {
                    Name = x.Name,
                    Img = x.Img,
                    Cell = x.Cell
                }).ToList(),

                UserComments = _userCommentsRepository.GetAll()
                .Select(u => new UserCommentViewModel
                {
                    Name = u.Name,
                    Img = u.Img,
                    Comments = u.Comments
                }).ToList(),

                LayoutModelUser = new HomeCoffeShopViewModel
                {
                    ImageFon = _sliderFileServices.GetFonGallery()
                }
            };

            return View(model);
        }
        
        //Update Next 
        [AllowAnonymous]
        public IActionResult Card(string category = "Brazilian", string name = "Name")
        {
            var model = new ProductCardViewModel
            {
                RootCategory = "Coffee",
                Category = string.IsNullOrWhiteSpace(category) ? "Brazilian" : category,
                Name = string.IsNullOrWhiteSpace(name) ? "Name" : name,
                Title = "Бразилия Terra do Sol «Понятный кофе» 1 кг",
                ImageUrl = "/image/products/brazil-terra-do-sol.png",
                PackWeight = 1000,
                Price = 81.2m,
                Description = new List<string>
                {
                    "Тот самый случай, когда название говорит само за себя. Просто понятный и очень хороший кофе. Без особых претензий на вкусовой эксклюзив, при этом кофе точно из категории «благородный». Арабика 100%.",
                    "Бразилия — плотный кофе с балансом кислотности и сладости, ноты шоколада, карамели и сухофруктов.",
                    "Сорт кофе происходит от названия кофейного региона, расположенного к северу от Сан-Пауло. Местность славится плодородными землями и благоприятным климатом.",
                    "Вкус: густой и насыщенный, с шоколадно-ореховой горчинкой, которая дополняется легкой и искрящейся апельсиновой кислинкой. В букете присутствуют нотки сухофруктов."
                },
                Weights = new List<string> { "1000 г", "500 г", "250 г" },
                Grinds = new List<string> { "В зёрнах", "Средний", "Тонкий" },
                Quantity = 1
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
