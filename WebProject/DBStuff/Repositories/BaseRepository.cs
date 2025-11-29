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

        public virtual List<DbModel> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual void Remove(int id)
        {
            var user = _dbSet.First(x => x.Id == id);
            Remove(user);
        }

        public virtual void Remove(DbModel model)
        {
            _dbSet.Remove(model);
            _portalContext.SaveChanges();
        }

        public virtual DbModel Add(DbModel model)
        {
            _dbSet.Add(model);
            _portalContext.SaveChanges();
            return model;
        }
        public virtual List<DbModel> AddRange(List<DbModel> models)
        {
            _dbSet.AddRange(models);
            _portalContext.SaveChanges();
            return models;
        }

        public DbModel Update(DbModel model)
        {
            _dbSet.Update(model);
            _portalContext.SaveChanges();
            return model;
        }

        //public List<DbModel> AddRange(List<DbModel> models)
        //{
        //    _dbSet.AddRange(models);
        //    _portalContext.SaveChanges();
        //    return models;
        //}

        public DbModel GetFirstById(int id)
        {
            return _dbSet.First(c => c.Id == id);
        }
    }
}
