using System.Diagnostics.Eventing.Reader;
using WebProject.DBStuff.Models.CoffeShop;
using WebProject.DBStuff.Repositories.Interface;
using WebProject.Enum;
using WebProject.Models.Home;

namespace WebProject.Service
{
    public class AuthService
    {
        private IHttpContextAccessor _contextAccessor;
        private IUserRepository _userRepository;
        public AuthService(IHttpContextAccessor contextAccessor, IUserRepository userRepository)
        {
            _contextAccessor = contextAccessor;
            _userRepository = userRepository;
        }

        public int GetId()
        {
           var httpContext = _contextAccessor.HttpContext;
            return int.Parse(httpContext
                .User
                .Claims
                .First(x => x.Type == "Id")
                .Value
                );
        }

        public UserDB GetUser()
        {
            return _userRepository.GetFirstById(GetId());

        }

        public bool IsAuthenticated()
        {
            return _contextAccessor.HttpContext!.User?.Identity?.IsAuthenticated ?? false;
        }

        internal Role GetRole()
        {
            var httpContext = _contextAccessor.HttpContext;
            return (Role)int.Parse(httpContext
                .User
                .Claims
                .First(x => x.Type == "Role")
                .Value
                );
        }

        public string GetUserName()
        {
            if (!IsAuthenticated())
            { 
                    return "";
            }    
            var claim = _contextAccessor.HttpContext.User.Claims
                .FirstOrDefault(x => x.Type == "UserName");

            return claim?.Value ?? "";
        }

        public Language GetLanguage()
        {
            return (Language)int.Parse(_contextAccessor.HttpContext
                .User
                .Claims
                .First(x => x.Type == "Language")
                .Value
                );
        }
    }
}
