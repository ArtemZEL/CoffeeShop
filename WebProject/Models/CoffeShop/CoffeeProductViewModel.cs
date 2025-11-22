using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebProject.Models
{
    public class CoffeeProductViewModel
    {
        //Adding Coffe
        public int Id { get; set; }
        public string Img { get; set; }
        public string Name { get; set; }
        public decimal Cell { get; set; }

        public int AuthorId { get; set; }
        public string AuthorName { get; set; }

        //In next update created on other category
        //public List<SelectListItem> Category { get; set; } = new List<SelectListItem>();
    }
}
