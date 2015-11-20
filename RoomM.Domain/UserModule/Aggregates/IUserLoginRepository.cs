using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace RoomM.Domain.UserModule.Aggregates
{
    public interface IUserLoginRepository : IRepository<UserLogin>
    {
        IList<UserLogin> GetByUserId(Int64 userId);
        Int64 GetUserId(string loginProvider, string providerKey);
        void Delete(Int64 userId, string loginProvider, string providerKey);
    }
}
