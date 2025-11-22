namespace WebProject.DBStuff.Models.CoffeShop
{
    public class CoffeeProductDB : BaseModel
    {
        public string Name { get; set; }
        public string Img { get; set; }
        public decimal Cell { get; set; }
        public int? AuthorId { get; set; }
        public virtual UserDB? AuthorAdd { get; set; }

    }
}
