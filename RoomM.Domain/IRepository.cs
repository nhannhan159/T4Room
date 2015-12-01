using System;
using System.Collections.Generic;

namespace RoomM.Domain
{
    public interface IRepository<T> where T : EntityBase
    {
        T GetSingle(Int64 id);

        IList<T> GetAll();

        void Add(T entity);

        void Delete(T entity);

        void Delete(Int64 id);

        void Edit(T entity);
    }
}