using WebProject.DBStuff.Models.CoffeShop;

namespace WebProject.DBStuff.Repositories.Interface
{
    public interface ICoffeeProductVariantRepository : IBaseRepository<CoffeeProductVariantDB>
    {
        List<CoffeeProductVariantDB> GetCoffeeProductsId(int coffeeProductId);
    }
}