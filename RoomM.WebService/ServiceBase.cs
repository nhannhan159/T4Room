﻿using RoomM.Models;
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
    public abstract class ServiceBase<T> : IService<T> where T : Detachable<T>, new() 
    {
        protected IRepository<T> repo;
        protected UnitOfWork uow;

        public ServiceBase(EFDataContext context)
        {
            this.uow = new UnitOfWork(context);
        }

        public IList<T> GetAll()
        {
            return this.GetDetachedList(this.repo.GetAll());
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

        public void Delete(object id)
        {
            this.repo.Delete(id);
            this.uow.Commit();
        }

        public void Edit(T entity)
        {
            this.repo.Edit(entity);
            this.uow.Commit();
        }

        protected IList<T> GetDetachedList(IList<T> rawlist)
        {
            IList<T> detachedlist = new List<T>();
            foreach (T rawitem in rawlist)
            {
                detachedlist.Add(rawitem.GetDetached());
            }
            return detachedlist;
        }
    }
}
