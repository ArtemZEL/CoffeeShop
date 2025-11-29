
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebProject.Enum;
using WebProject.Service;

namespace WebProject.Controllers.CustomAuthorizeAttributtes
{
    public class RoleAttribute : ActionFilterAttribute
    {
        private List<Role> _avaliablesRole;

        public RoleAttribute(params Role[] role)
        {
            _avaliablesRole = role.ToList();
        }

        public RoleAttribute(Role role)
        {
            _avaliablesRole = new List<Role> { role };
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var authService = context.HttpContext.RequestServices.GetRequiredService<AuthService>();

            if (!authService.IsAuthenticated())
            {
                context.Result = ((Controller)context.Controller)
                    .RedirectToAction("Login", "Auth");
                return;
            }

            var userRole = authService.GetRole();
            if (_avaliablesRole.Contains(userRole))
            {
                {
                    context.Result = ((Controller)context.Controller)
                        .RedirectToAction("Forbid", "Auth");
                    return;
                }
            }
            base.OnActionExecuting(context);
        }
    }
}
