using WebProject.DBStuff.Models.CoffeShop;
using WebProject.Enum;

namespace WebProject.Service.Permissions
{
    public class CoffeShopPermision : ICoffeShopPermision
    {
        private AuthService _authService;

        public CoffeShopPermision(AuthService authService)
        {
            _authService = authService;
        }

        public bool CanFindPage(CoffeeProductDB coffeeProduct)
        {
            if (!_authService.IsAuthenticated())
            {
                return false;
            }
            var user = _authService.GetUser();
            if (user.Role == Role.SuperAdmin)
            {
                return true;
            }
            var authorId = coffeeProduct.AuthorAdd?.Id ?? coffeeProduct.AuthorId;
            return authorId == user.Id;
        }





    }
}
