using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WebProject.Models.CustomValidation
{
     
    public class TestAtrribute:ValidationAttribute
    {
        public TestAtrribute()
        {
            ErrorMessage = "Название не должно содержать цифры.";
        }

        public override bool IsValid(object? value)
        {
            if (value == null)
            {
                return true;
            }

            string str = value.ToString();

            // Проверяем наличие цифр
            return !Regex.IsMatch(str, @"\d");
        }


    }
}
