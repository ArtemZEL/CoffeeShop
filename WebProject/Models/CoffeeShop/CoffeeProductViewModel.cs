using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel.DataAnnotations;
using WebProject.Models.CustomValidation;

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
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        //if This user add product here deleting  
        public bool CanDelete { get; set; }
        public List<SelectListItem> CategoryNameList { get; set; } = new List<SelectListItem>();
    }
}
