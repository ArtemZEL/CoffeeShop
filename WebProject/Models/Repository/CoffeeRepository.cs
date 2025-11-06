using System.Collections.Generic;

namespace WebProject.Models
{
    public static class CoffeeRepository
    {
        // Общее хранилище кофе (доступно всем контроллерам)
        public static List<CoffeeProduct> CoffeeProducts { get; } = new List<CoffeeProduct>
        {
            new CoffeeProduct { Img = "/image/p1.png", Name = "Espresso", Cell = 35 },
            new CoffeeProduct { Img = "/image/p2.png", Name = "Latte", Cell = 44 },
            new CoffeeProduct { Img = "/image/p3.png", Name = "Arabic coffee", Cell = 55 },
            new CoffeeProduct { Img = "/image/p4.png", Name = "Cappuccino", Cell = 25 },
            new CoffeeProduct { Img = "/image/p5.png", Name = "Mocha", Cell = 60 },
            new CoffeeProduct { Img = "/image/p6.png", Name = "Flat White", Cell = 15 },
        };
    }
}
