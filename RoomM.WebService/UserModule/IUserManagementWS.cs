using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using RoomM.Domain.RoomModule.Aggregates;
using RoomM.Domain.UserModule.Aggregates;

namespace RoomM.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IStaffService" in both code and config file together.
    [ServiceContract]
    public interface IUserManagementWS
    {
        [OperationContract]
        User GetSingle(Int64 userId);

        [OperationContract]
        User GetSingleByUsername(string username);

        [OperationContract]
        IList<User> GetUserList();

        [OperationContract]
        IList<Role> GetRoleList();

        [OperationContract]
        IList<KeyValuePair<User, int>> GetUserLimitByRegister(int limit, DateTime from, DateTime to);

        [OperationContract]
        void AddUser(User user);

        [OperationContract]
        void EditUser(User user);

        [OperationContract]
        void DeleteUser(User user);

        [OperationContract]
        Role GetRoleById(Int64 roleId);

        [OperationContract]
        Role GetRoleByName(string roleName);

        [OperationContract]
        void AddRole(Role role);

        [OperationContract]
        void EditRole(Role role);

        [OperationContract]
        void DeleteRole(Int64 roleId);

        [OperationContract]
        IList<string> GetUserRoles(Int64 userId);

        [OperationContract]
        bool IsUserInRole(Int64 userId, string roleName);

        [OperationContract]
        void AddUserToRole(Int64 userId, string roleName);

        [OperationContract]
        IList<UserClaim> GetUserClaimList(Int64 userId);

        [OperationContract]
        void AddUserClaim(Int64 userId, string claimType, string claimValue);

        [OperationContract]
        void DeleteUserClaim(Int64 userId, string claimType, string claimValue);

        [OperationContract]
        IList<UserLogin> GetUserLoginList(Int64 userId);

        [OperationContract]
        User FindUserByLogin(string loginProvider, string providerKey);

        [OperationContract]
        void AddUserLogin(Int64 userId, string loginProvider, string providerKey);

        [OperationContract]
        void DeleteUserLogin(Int64 userId, string loginProvider, string providerKey);
    }
}
