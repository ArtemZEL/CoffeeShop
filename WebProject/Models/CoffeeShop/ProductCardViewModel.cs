namespace WebProject.Models.CoffeeShop
{
    public class ProductCardViewModel
    {
        public string RootCategory { get; set; } = "Coffee";
        public string Category { get; set; } = "Brazilian";
        public string Name { get; set; } = "Name";
        public string Title { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int PackWeight { get; set; }
        public decimal Price { get; set; }
        public List<string> Description { get; set; } = new();
        public List<string> OrderTerms { get; set; } = new();
        public List<string> Weights { get; set; } = new();
        public List<string> Grinds { get; set; } = new();
        public int Quantity { get; set; } = 1;
    }
}
