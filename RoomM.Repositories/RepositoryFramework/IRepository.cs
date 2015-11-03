using RoomM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Repositories
{
    public interface IRepository<T> where T : EntityBase
    {
        T GetSingle(Int64 id);
        IList<T> GetAll();
        IQueryable<T> GetAllWithQuery();
        IEnumerable<T> GetWithRawSql(string query, params object[] parameters);
        IEnumerable<T> Get(
            Expression<Func<T, bool>> filter,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
            string includeProperties);
        
        void Add(T entity);
        void Delete(T entity);
        void Delete(Int64 id);
        void Edit(T entity);
    }
}
