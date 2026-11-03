namespace WebProject.DBStuff.Models.CoffeShop
{
    public class CoffeeProductVariantDB : BaseModel
    {
        public int CoffeeProductId { get; set; }
        public virtual CoffeeProductDB CoffeeProduct { get; set; }
        public int Weight { get; set; }
        public int GrindId { get; set; }
        public virtual CoffeeGrindDB Grind { get; set; }
        public decimal Price { get; set; }
    }
}