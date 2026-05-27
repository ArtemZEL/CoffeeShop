using CooffeeApi.DbStuff;
using CooffeeApi.DbStuff.Model;

namespace CooffeeApi
{
    public class CoffeeService
    {
        private CoffeeDBContext _coffeeContext;

        public CoffeeService(CoffeeDBContext coffeeContext)
        {
            _coffeeContext = coffeeContext;
        }


        public List<string> GetAllCoffee()
        {
            return _coffeeContext.Coffees.Select(x => x.Name).ToList();
        }

        public int CreateCoffee(string name, string url, string category)
        {
            var coffee = new CoffeeProduct
            {
                Name = name,
                Url = url,
                Category = category
            };

            _coffeeContext.Coffees.Add(coffee);
            _coffeeContext.SaveChanges();

            return coffee.Id;
        }

    }
}
