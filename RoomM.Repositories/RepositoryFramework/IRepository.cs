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
        IList<T> GetAll();
        IQueryable<T> GetAllWithQuery();
        // IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        // T GetByID(object id);

        void Add(T entity);
        void Delete(T entity);
        void Delete(object id);
        void Edit(T entity);
    }
}
