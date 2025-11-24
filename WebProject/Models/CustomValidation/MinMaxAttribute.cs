using System.ComponentModel.DataAnnotations;

namespace WebProject.Models.CustomValidation
{
    public class MinMaxAttribute:ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            return base.IsValid(value);
        }

    }
}
