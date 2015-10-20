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

using RoomM.Repositories.RepositoryFramework;

namespace RoomM.WebService
{
    public abstract class ServiceBase<T> : IService<T> where T : Detachable<T>, new() 
    {
        protected IRepository<T> repo;

        public IList<T> GetAll()
        {
            IList<T> items = this.repo.GetAll();
            IList<T> detachedItems = new List<T>();
            foreach (T item in items)
            {
                detachedItems.Add(item.GetDetached());
            }
            return detachedItems;
        }

        public void Add(T entity)
        {
            this.repo.Add(entity);
        }

        public void Delete(T entity)
        {
            this.repo.Delete(entity);
        }

        public void Delete(object id)
        {
            this.repo.Delete(id);
        }

        public void Edit(T entity)
        {
            this.repo.Edit(entity);
        }

        public void Save()
        {
            this.repo.Save();
        }
    }
}