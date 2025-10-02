using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class CoffeShopController : Controller
    {
        public IActionResult Index()
        {
            var model = new CoffeShopViewModel
            {
                CoffeeProducts = new List<string>
            {
                    "/image/p1.png",
                    "/image/p2.png",
                    "/image/p3.png",
                    "/image/p4.png",
                    "/image/p5.png",
                    "/image/p6.png",
            },

                UserComments = new List<string>
                {
                    "/image/rev1.jpg",
                    "/image/rev2.jpg",
                    "image/rev3.jpg"
                }
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult UserPage(int age, string name, string email)
        {
            var userModel = new HomeCoffeShopViewModel();
            userModel.UserName = name;
            userModel.UserEmail = email;
            userModel.Age = age;
            return View(userModel);
        }


    }
}
