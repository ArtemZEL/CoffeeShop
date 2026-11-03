using Microsoft.EntityFrameworkCore;
using WebProject.DBStuff.Models.CoffeShop;
using WebProject.DBStuff.Repositories.Interface;

namespace WebProject.DBStuff.Repositories
{
    public class CoffeeProductVariantRepository : BaseRepository<CoffeeProductVariantDB>, ICoffeeProductVariantRepository
    {
        public CoffeeProductVariantRepository(WebProjectContext portalContext) : base(portalContext)
        {
        }

        public List<CoffeeProductVariantDB> GetCoffeeProductsId(int coffeeProductId)
        {
            return _dbSet.Include(x => x.Grind)
                .Where(x => x.CoffeeProductId == coffeeProductId)
                .ToList();
        }
    }
}
