using RoomM.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using RoomM.Repositories;

namespace RoomM.WebService
{
    public abstract class ServiceBase<T> : IService<T> where T : EntityBase, new() 
    {
        protected IRepository<T> repo;
        protected UnitOfWork uow;

        public ServiceBase(EFDataContext context)
        {
            context.Configuration.ProxyCreationEnabled = false;
            // context.Configuration.LazyLoadingEnabled = false;
            this.uow = new UnitOfWork(context);
        }

        public IList<T> GetAll()
        {
            return this.repo.GetAll();
        }

        public T GetSingle(Int64 id)
        {
            return this.repo.GetSingle(id);
        }

        public void Add(T entity)
        {
            this.repo.Add(entity);
            this.uow.Commit();
        }

        public void Delete(T entity)
        {
            this.repo.Delete(entity);
            this.uow.Commit();
        }

        public void Delete(Int64 id)
        {
            this.repo.Delete(id);
            this.uow.Commit();
        }

        public void Edit(T entity)
        {
            this.repo.Edit(entity);
            this.uow.Commit();
        }
    }
}
