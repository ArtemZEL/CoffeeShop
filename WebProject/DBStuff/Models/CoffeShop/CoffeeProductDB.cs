namespace WebProject.DBStuff.Models.CoffeShop
{
    public class CoffeeProductDB : BaseModel
    {
        public string Name { get; set; }
        public string Img { get; set; }
        //public decimal Cell { get; set; }
        public string Description { get; set; }
        public int? AuthorId { get; set; }
        public virtual UserDB? AuthorAdd { get; set; }
        public int? CategoryId { get; set; }
        public virtual CategoryDB? Category { get; set; }
        public virtual ICollection<CoffeeProductVariantDB> Variants { get; set; } = new List<CoffeeProductVariantDB>(); 
    }
}
