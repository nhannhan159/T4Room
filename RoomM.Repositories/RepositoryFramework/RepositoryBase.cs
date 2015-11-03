using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using RoomM.Models;

namespace RoomM.Repositories
{
    public class RepositoryBase<T> : IRepository<T> where T : EntityBase, new()
    {
        private EFDataContext context;

        public RepositoryBase(EFDataContext context)
        {
            this.context = context;
        }

        public IEnumerable<T> GetWithRawSql(string query, params object[] parameters)
        {
            return context.Set<T>().SqlQuery(query, parameters).ToList();
        }

        public IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            var _context = ((IObjectContextAdapter)context).ObjectContext;
            var refreshableObjects = (from entry in _context.ObjectStateManager.GetObjectStateEntries(
                                          EntityState.Added
                                          | EntityState.Deleted
                                          | EntityState.Modified
                                          | EntityState.Unchanged)
                                      where entry.EntityKey != null
                                      select entry.Entity).ToList();

            _context.Refresh(RefreshMode.StoreWins, refreshableObjects);

            IQueryable<T> query = context.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public IList<T> GetAll()
        {
            return Get().ToList();
        }

        public IQueryable<T> GetAllWithQuery()
        {
            IQueryable<T> query = context.Set<T>();
            return query;
        }

        public T GetSingle(Int64 id)
        {
            var query = GetAllWithQuery().SingleOrDefault(x => x.ID == id);
            return query;
        }

        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public void Delete(Int64 id)
        {
            T entityToDelete = context.Set<T>().Find(id);
            Delete(entityToDelete);
        }

        public void Edit(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Cannot add a null entity.");
            }

            var entry = context.Entry<T>(entity);

            if (entry.State == EntityState.Detached)
            {
                var set = context.Set<T>();
                T attachedEntity = set.Local.SingleOrDefault(e => e.ID == entity.ID);

                if (attachedEntity != null)
                {
                    var attachedEntry = context.Entry(attachedEntity);
                    attachedEntry.CurrentValues.SetValues(entity);
                }
                else
                {
                    entry.State = EntityState.Modified;
                }
            }
            else
            {
                entry.State = EntityState.Modified;
            }
        }
    }
}
