namespace WebProject.DBStuff.Models.CoffeShop
{
    public class CoffeeGrindDB : BaseModel
    {
        public string Name { get; set; }

        public virtual ICollection<CoffeeProductVariantDB> ProductVariants { get; set; } = new List<CoffeeProductVariantDB>();

    }
}
