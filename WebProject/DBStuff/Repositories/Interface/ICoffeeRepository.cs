using WebProject.DBStuff.Models.CoffeShop;

namespace WebProject.DBStuff.Repositories.Interface
{
    public interface ICoffeeRepository:IBaseRepository<CoffeeProductDB>
    {

        IEnumerable<CoffeeProductDB> GetAllWithAuthors();
    }
}