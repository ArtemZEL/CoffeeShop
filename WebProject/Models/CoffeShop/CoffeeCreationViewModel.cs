using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace WebProject.Models
{
    public class CoffeeCreationViewModel
    {
        [Required]
        public string Img { get; set; }
        [Required]
        [MaxLength(50)]
        //[TestAtrribute]
        public string Name { get; set; }
        public decimal Cell { get; set; }
        public int AuthorId { get; set; }
        public int? CategoryId { get; set; }
        public List<SelectListItem> CategoryNameList { get; set; } = new List<SelectListItem>();
    }
}
