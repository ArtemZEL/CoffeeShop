using WebProject.DBStuff.Models.CoffeShop;
using WebProject.DBStuff.Repositories.Interface;

namespace WebProject.DBStuff.Repositories
{
    public class CategoryRepository : BaseRepository<CategoryDB>, ICategoryRepository
    {
        public CategoryRepository(WebProjectContext portalContext) : base(portalContext)
        {
        }

    }
}
