using System.Diagnostics.Eventing.Reader;
using WebProject.DBStuff.Models.CoffeShop;
using WebProject.DBStuff.Repositories.Interface;
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
            var id = int.Parse(httpContext
                .User
                .Claims
                .First(x => x.Type == "Id")
                .Value
                );

            return id;
        }

        public UserDB GetUser()
        {
            return _userRepository.GetFirstById(GetId());

        }

        public bool IsAuthenticated()
        {
            return _contextAccessor.HttpContext!.User?.Identity?.IsAuthenticated ?? false;
        }

    }
}
