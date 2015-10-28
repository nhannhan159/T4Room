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
    public abstract class  RepositoryBase<T> : 
        IRepository<T> where T : EntityBase, new() 
    {

        private EFDataContext _entities;

        public RepositoryBase(EFDataContext _entities)
        {
            this._entities = _entities;
        }

        public virtual IEnumerable<T> GetWithRawSql(string query, params object[] parameters)
        {
            return _entities.Set<T>().SqlQuery(query, parameters).ToList();
        }

        public virtual IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {

            var context = ((IObjectContextAdapter)_entities).ObjectContext;
            var refreshableObjects = (from entry in context.ObjectStateManager.GetObjectStateEntries(
                                                        EntityState.Added
                                                       | EntityState.Deleted
                                                       | EntityState.Modified
                                                       | EntityState.Unchanged)
                                      where entry.EntityKey != null
                                      select entry.Entity).ToList();

            context.Refresh(RefreshMode.StoreWins, refreshableObjects);

            IQueryable<T> query = _entities.Set<T>();

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

        public virtual IQueryable<T> GetAllWithQuery()
        {
            IQueryable<T> query = _entities.Set<T>();
            return query;
        }

        public void Add(T entity)
        {
            _entities.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _entities.Set<T>().Remove(entity);
        }

        public void Delete(object id)
        {
            T entityToDelete = _entities.Set<T>().Find(id);
            Delete(entityToDelete);
        }

        public void Edit(T entity)
        {
            // _entities.Entry(entity).State = EntityState.Modified;
            if (entity == null)
            {
                throw new ArgumentException("Cannot add a null entity.");
            }
            
            var entry = _entities.Entry<T>(entity);

            if (entry.State == EntityState.Detached)
            {
                var set = _entities.Set<T>();
                T attachedEntity = set.Local.SingleOrDefault(e => e.ID == entity.ID);  // You need to have access to key

                if (attachedEntity != null)
                {
                    // Console.WriteLine("heheeeeeeeeeeeeee");
                    var attachedEntry = _entities.Entry(attachedEntity);
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

        public void Save()
        {
            _entities.SaveChanges();
        }
    }
}
