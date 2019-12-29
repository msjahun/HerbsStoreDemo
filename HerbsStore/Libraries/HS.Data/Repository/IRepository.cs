using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HerbsStore.Libraries.HS.Core;

namespace HerbsStore.Libraries.HS.Data.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Delete(T entity);
        T GetById(long id);
        long Insert(T entity);
        IEnumerable<T> List();
        IEnumerable<T> List(Expression<Func<T, bool>> predicate);
        void Update(T entity);
        IEnumerable<T> Include(string path);
    }
}
