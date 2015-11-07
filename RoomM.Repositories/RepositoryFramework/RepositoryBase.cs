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
        private DbSet<T> dbSet;

        public RepositoryBase(EFDataContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        protected virtual string IncludeProperties() {
            return "";
        }

        private void RefreshContext()
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
        }

        protected IQueryable<T> GetWithRawSql(string query, params object[] parameters)
        {
            this.RefreshContext();
            return this.dbSet.SqlQuery(query, parameters).AsQueryable();
        }

        protected IQueryable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int limit = 0)
        {
            this.RefreshContext();

            IQueryable<T> query = this.dbSet;

            foreach (var includeProperty in this.IncludeProperties().Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (limit > 0)
            {
                query = query.Take(limit);
            }

            return query;
        }

        public T GetSingle(Int64 id)
        {
            return this.Get().SingleOrDefault(x => x.ID == id);
        }

        public IList<T> GetAll()
        {
            return this.Get().ToList();
        }

        public void Add(T entity)
        {
            this.dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            this.dbSet.Remove(entity);
        }

        public void Delete(Int64 id)
        {
            T entityToDelete = this.dbSet.Find(id);
            this.Delete(entityToDelete);
        }

        public void Edit(T entity)
        {
            var entry = context.Entry<T>(entity);
            if (entry.State == EntityState.Detached)
            {
                T attachedEntity = this.dbSet.Local.SingleOrDefault(e => e.ID == entity.ID);
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
