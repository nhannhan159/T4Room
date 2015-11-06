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

        public IQueryable<T> GetWithRawSql(string query, params object[] parameters)
        {
            this.RefreshContext();
            return this.dbSet.SqlQuery(query, parameters).AsQueryable();
        }

        public IQueryable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            this.RefreshContext();

            IQueryable<T> query = this.dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in this.IncludeProperties().Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }
            else
            {
                return query;
            }
        }

        public IList<T> GetAll()
        {
            return this.Get().ToList();
        }

        public T GetSingle(Int64 id)
        {
            return this.Get().SingleOrDefault(x => x.ID == id);
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
            this.dbSet.Attach(entity);
            this.context.Entry(entity).State = EntityState.Modified;
            /*
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
            */
        }
    }
}
