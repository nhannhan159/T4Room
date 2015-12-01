using RoomM.Domain.UserModule.Aggregates;
using System;
using System.Collections.Generic;

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

        Role GetRoleById(Int64 roleId);

        Role GetRoleByName(string roleName);

        void AddRole(Role role);

        void EditRole(Role role);

        void DeleteRole(Int64 roleId);

        IList<UserClaim> GetUserClaimList(Int64 userId);

        void AddUserClaim(Int64 userId, string claimType, string claimValue);

        void DeleteUserClaim(Int64 userId, string claimType, string claimValue);

        IList<UserLogin> GetUserLoginList(Int64 userId);

        User FindUserByLogin(string loginProvider, string providerKey);

        void AddUserLogin(Int64 userId, string loginProvider, string providerKey);

        void DeleteUserLogin(Int64 userId, string loginProvider, string providerKey);
    }
}