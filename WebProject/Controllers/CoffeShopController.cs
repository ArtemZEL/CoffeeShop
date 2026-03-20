using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebProject.DBStuff;
using WebProject.DBStuff.Repositories;
using WebProject.DBStuff.Repositories.Interface;
using WebProject.Models;
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
        private readonly UserCommentsRepository _userCommentsRepository;
        private WebProjectContext _webProjectContext;
        private readonly ISliderFileServices _sliderFileServices;


        public CoffeShopController(
            ICoffeeRepository coffeeRepository,
            UserCommentsRepository userCommentsRepository,
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

                UserComments = _webProjectContext.UserComments
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

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
