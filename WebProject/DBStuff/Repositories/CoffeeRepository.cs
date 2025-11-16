using System.Collections.Generic;
using WebProject.DBStuff.Models.CoffeShop;
using WebProject.DBStuff.Repositories.Interface;
using WebProject.Models;

namespace WebProject.DBStuff.Repositories
{
    public class CoffeeRepository : BaseRepository<CoffeeProductDB>, ICoffeeRepository
    {
        public CoffeeRepository(WebProjectContext portalContext) : base(portalContext)
        {

        }

        
    }
}
