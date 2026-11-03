using WebProject.DBStuff.Models.CoffeShop;
using WebProject.DBStuff.Repositories.Interface;

namespace WebProject.DBStuff.Repositories
{
    public class CoffeeGrindRepository : BaseRepository<CoffeeGrindDB>,ICoffeeGrindRepository
    {
        public CoffeeGrindRepository(WebProjectContext portalContext) : base(portalContext)
        {
        }
    }
}
