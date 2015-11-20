using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RoomM.Domain.RoomModule.Aggregates;
using RoomM.Domain.UserModule.Aggregates;

namespace RoomM.Application.UserModule.Services
{
    public interface IUserManagementService
    {
        User GetSingle(Int64 userId);
        User GetSingleByUsername(string username);
        IList<User> GetUserList();
        IList<Role> GetRoleList();
        IList<KeyValuePair<User, int>> GetUserLimitByRegister(int limit, DateTime from, DateTime to);
        void AddUser(User user);
        void EditUser(User user);
        void DeleteUser(User user);
        IList<string> GetUserRoles(Int64 userId);
        bool IsUserInRole(Int64 userId, string roleName);
        void AddUserToRole(Int64 userId, string roleName);
        IList<UserClaim> GetUserClaimList(Int64 userId);
        void AddUserClaim(Int64 userId, string claimType, string claimValue);
        void DeleteUserClaim(Int64 userId, string claimType, string claimValue);
        IList<UserLogin> GetUserLoginList(Int64 userId);
        User FindUserByLogin(string loginProvider, string providerKey);
        void AddUserLogin(Int64 userId, string loginProvider, string providerKey);
        void DeleteUserLogin(Int64 userId, string loginProvider, string providerKey);
    }
}
