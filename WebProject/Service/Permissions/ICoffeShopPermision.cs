using WebProject.DBStuff.Models.CoffeShop;

namespace WebProject.Service.Permissions
{
    public interface ICoffeShopPermision
    {
        bool CanFindPage(CoffeeProductDB coffeeProduct);
    }
}