using WebProject.DBStuff.Models.CoffeShop;
using WebProject.Models.CoffeeShop;

namespace WebProject.DBStuff.Repositories.Interface
{
    public interface ICoffeeRepository:IBaseRepository<CoffeeProductDB>
    {
        IEnumerable<CoffeeProductDB> GetAllWithAuthors();
        List<CoffeDetailsViewModel> GetCoffeeDetail();
        List<CoffeeSummaryViewModel> GetCoffeeSummary();
    }
}