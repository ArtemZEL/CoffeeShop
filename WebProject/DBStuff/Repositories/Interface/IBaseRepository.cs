using WebProject.DBStuff.Models;

namespace WebProject.DBStuff.Repositories.Interface
{
    public interface IBaseRepository<DbModel> where DbModel : BaseModel
    {
        DbModel Add(DbModel model);
        List<DbModel> GetAll();
        void Remove(DbModel model);
        void Remove(int id);

        DbModel GetFirstById(int id);
    }
}