using Microsoft.AspNetCore.Http.Features;
using System.Globalization;
using System.Text.RegularExpressions;
using WebProject.Service;

namespace WebProject.CustomMidleware
{
    public class CustomLocalizazationMidleware
    {
        private readonly RequestDelegate _next;

        public CustomLocalizazationMidleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var authService = context.RequestServices.GetService<AuthService>();
            if (authService.IsAuthenticated())
            {
                var language = authService.GetLanguage();
                CultureInfo culture;
                switch (language)
                {
                    case Enum.Language.English:
                        culture = new CultureInfo("En");
                        break;
                    case Enum.Language.Russian:
                        culture = new CultureInfo("Ru");
                        break;
                    default:
                        throw new ArgumentException($"Unknow languaage {language}");
                }
                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = culture;
            }

            await _next.Invoke(context);
        }
    }
}
