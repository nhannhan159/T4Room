using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace RoomM.Domain.UserModule.Aggregates
{
    public interface IUserRepository : IRepository<User>
    {
        Boolean CheckUserExists(string username);
        IList<KeyValuePair<User, int>> GetUserLimitByRegister(int limit, DateTime from, DateTime to);
        bool IsExists(string username);
        Int64 GetUserId(string username);
        bool UserNameIsWorking(string username);
        User GetSingleByUsername(string username);
    }
}
