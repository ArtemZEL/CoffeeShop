using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebProject.DBStuff.Models.CoffeShop;
using WebProject.DBStuff.Repositories.Interface;
using WebProject.Models;
using WebProject.Models.CoffeeShop;

namespace WebProject.DBStuff.Repositories
{
    public class CoffeeRepository : BaseRepository<CoffeeProductDB>, ICoffeeRepository
    {
        public CoffeeRepository(WebProjectContext portalContext) : base(portalContext)
        {
            _portalContext = portalContext;
        }
        public IEnumerable<CoffeeProductDB> GetAllWithAuthors()
        {
            return _dbSet
                .Include(x => x.AuthorAdd)
                .Include(x => x.Category)// This will download the linked user
                .ToList();
        }

        public List<CoffeDetailsViewModel> GetCoffeeDetail()
        {
            var coffeeDetail = @"
                SELECT U.""UserName"" AS AuthorName,
                CF.""Name"" AS CoffeeName,
                CF.""Cell"" AS Price
                FROM ""CoffeeProducts"" CF
                LEFT JOIN ""Users"" U ON U.""Id"" = CF.""AuthorId""
                ORDER BY U.""UserName"", CF.""Name"";";

            return _portalContext
                .Database
                .SqlQueryRaw<CoffeDetailsViewModel>(coffeeDetail)
                .ToList();
        }
        public List<CoffeeSummaryViewModel> GetCoffeeSummary()
        {
            var coffeeDetaila = @"
            SELECT 
                U.""UserName"" AS AuthorName,
                COUNT(*) AS TotalCoffees
            FROM ""CoffeeProducts"" CF
                LEFT JOIN ""Users"" U ON U.""Id"" = CF.""AuthorId""
                GROUP BY U.""UserName""
            ORDER BY U.""UserName"";";

            return _portalContext
                .Database
                .SqlQueryRaw<CoffeeSummaryViewModel>(coffeeDetaila)
                .ToList();

        }
    }
}
