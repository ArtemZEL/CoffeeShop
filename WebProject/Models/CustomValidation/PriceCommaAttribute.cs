using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WebProject.Models.CustomValidation
{
    public class PriceCommaAttribute  : ValidationAttribute
    {
        public PriceCommaAttribute()
        {
            ErrorMessage = "Цена должна быть указана через запятую. Например: 12,5";
        }

        public override bool IsValid(object? value)
        {
            if (value == null)
            {
                return true; 
            }

            string str = value.ToString();

            return Regex.IsMatch(str, @"^\d+,\d+$");
        }
    }
}
