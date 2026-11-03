using System.Globalization;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebProject.Models.CustomValidation
{
    public class FlexibleDecimalModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider
                .GetValue(bindingContext.ModelName)
                .FirstValue;

            if (string.IsNullOrWhiteSpace(value))
            {
                return Task.CompletedTask;
            }

            var normalized = value.Replace(',', '.');
            if (decimal.TryParse(
                    normalized,
                    NumberStyles.Number,
                    CultureInfo.InvariantCulture,
                    out var result))
            {
                bindingContext.Result = ModelBindingResult.Success(result);
            }
            else
            {
                bindingContext.ModelState.TryAddModelError(
                    bindingContext.ModelName,
                    "Некорректная цена.");
            }

            return Task.CompletedTask;
        }
    }
}
