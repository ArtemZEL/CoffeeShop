using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using WebProject.Models.CustomValidation;

namespace WebProject.Models.CoffeeShop
{
    public class CoffeeProductVariantViewModel
    {
        public int Id { get; set; }
        public int CoffeeProductId { get; set; }
        [Required]
        [Range(1, 10000)]
        public int Weigths { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Выберите помол.")]
        public int GrindId { get; set; }
        [Required]
        [Range(0.01, 100000)]
        [ModelBinder(BinderType = typeof(FlexibleDecimalModelBinder))]
        public decimal Price { get; set; }
        public string? GrindName { get; set; }
        [ValidateNever]
        public List<SelectListItem> GrindList { get; set; }
            = new List<SelectListItem>();

    }
}
