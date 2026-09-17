using WebProject.DBStuff.Models.CoffeShop;

namespace WebProject.DBStuff.Repositories.Interface
{
    public interface IUserCommentsRepository : IBaseRepository<UserCommentsDB>
    {
        void AddComments(string name, string comments, string? img = null);
        List<UserCommentsDB> GetAll();
    }
}