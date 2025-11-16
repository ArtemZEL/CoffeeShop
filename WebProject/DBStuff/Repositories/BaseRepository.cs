using Microsoft.EntityFrameworkCore;
using WebProject.DBStuff.Models;
using WebProject.DBStuff.Repositories.Interface;

namespace WebProject.DBStuff.Repositories
{
    public abstract class BaseRepository<DbModel> : IBaseRepository<DbModel> where DbModel : BaseModel
    {
        protected WebProjectContext _portalContext;
        protected DbSet<DbModel> _dbSet;

        public BaseRepository(WebProjectContext portalContext)
        {
            _portalContext = portalContext;
            _dbSet = portalContext.Set<DbModel>();
        }

        public List<DbModel> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Remove(int id)
        {
            var user = _dbSet.First(x => x.Id == id);
            Remove(user);
        }

        public void Remove(DbModel model)
        {
            _dbSet.Remove(model);
            _portalContext.SaveChanges();
        }

        public DbModel Add(DbModel model)
        {
            _dbSet.Add(model);
            _portalContext.SaveChanges();
            return model;
        }

        //public List<DbModel> AddRange(List<DbModel> models)
        //{
        //    _dbSet.AddRange(models);
        //    _portalContext.SaveChanges();
        //    return models;
        //}

        //public DbModel GetFirstById(int id)
        //{
        //    return _dbSet.First(c => c.Id == id);
        //}



    }





}




