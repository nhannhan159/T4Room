using RoomM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace RoomM.WebService
{
    [ServiceContract]
    public interface IService<T> where T : EntityBase
    {
        [OperationContract]
        [ApplyDataContractResolver]
        T GetSingle(Int64 id);

        [OperationContract]
        IList<T> GetAll();

        [OperationContract]
        void Add(T entity);

        [OperationContract(Name = "DeleteByT")]
        void Delete(T entity);

        [OperationContract(Name = "DeleteByObject")]
        void Delete(Int64 id);

        [OperationContract]
        void Edit(T entity);
    }
}
