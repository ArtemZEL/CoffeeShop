using CooffeeApi.DbStuff;
using CooffeeApi.DbStuff.Model;

namespace CoffeeApi.Service
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

        public bool UpdateCoffee(int id, string name, string url, string category)
        {
            var addingCoffee = _coffeeContext.Coffees
                .FirstOrDefault(x => x.Id == id);
            if (addingCoffee == null)
            {
                return false;
            }

            addingCoffee.Name = name;
            addingCoffee.Url = url;
            addingCoffee.Category = category;
            _coffeeContext.SaveChanges();


            return true;
        }


    }
}
