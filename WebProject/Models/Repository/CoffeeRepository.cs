using System.Collections.Generic;

namespace WebProject.Models
{
    public class CoffeeRepository
    {
        private readonly List<CoffeeProduct> _coffeeProducts;

        public CoffeeRepository() 
        { 
            _coffeeProducts = new List<CoffeeProduct>();

            string[] namesCoffee = { "Espresso", "Latte", "Arabic coffee", "Cappuccino", "Mocha", "Flat White" };
            decimal[] priceCoffee = { 35, 44, 55, 25, 60, 15 };
            for (int i = 0; i < namesCoffee.Length; i++)
            {
                _coffeeProducts.Add(new CoffeeProduct
                {
                    Name = namesCoffee[i],
                    Img = $"/image/p{i+1}.png",
                    Cell = priceCoffee[i]
                });

            }
        }
        public List<CoffeeProduct> GetAll() => _coffeeProducts;

        public void AddCoffee(string name, string img, decimal cell)
        {
            _coffeeProducts.Add(new CoffeeProduct
            {
                Name=name,
                Img = img,
                Cell = cell
            });

        }
    }
}
