namespace WebProject.DBStuff.Models.CoffeShop
{
    public class CategoryDB : BaseModel
    {
        public string Name { get; set; }

        public virtual List<CoffeeProductDB> CoffeeProducts { get; set; } = new List<CoffeeProductDB>();

    }
}
