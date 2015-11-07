using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Data
{
    interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity e);

        TEntity Get(object id);

        IEnumerable<TEntity> GetAll();

        void Delete(TEntity e);

        void Save();
    }
}
