using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CourseWork.Data
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private AppContext _context;
        private DbSet<TEntity> _dbSet;

        public GenericRepository(AppContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public void Add(TEntity obj)
        {
            _dbSet.Add(obj);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public TEntity Get(object id)
        {
            return _dbSet.Find(id);
        }

        public void Delete(TEntity e)
        {
            var item = _dbSet.Find(e);
            if (_context.Entry(e).State == EntityState.Detached)
                _dbSet.Attach(e);

            _dbSet.Remove(e);
        }


        public void Save()
        {
            _context.SaveChanges();
        }
    }
}