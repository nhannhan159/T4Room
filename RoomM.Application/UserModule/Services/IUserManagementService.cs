using RoomM.Application.RoomM.Domain.UserModule.Aggregates;
using System;
using System.Collections.Generic;

namespace RoomM.Application.UserModule.Services
{
    public interface IUserManagementService
    {
        User GetUser(string userId);

        User GetUserByUsername(string username);

        IList<User> GetUserList();

        IList<Role> GetRoleList();

        IList<KeyValuePair<User, int>> GetUserLimitByRegister(int limit, DateTime from, DateTime to);

        void AddUser(User user);

        void EditUser(User user);

        void DeleteUser(User user);

        /*
        Role GetRoleById(string roleId);

        Role GetRoleByName(string roleName);

        void AddRole(Role role);

        void EditRole(Role role);

        void DeleteRole(string roleId);

        IList<UserClaim> GetUserClaimList(string userId);

        void AddUserClaim(string userId, string claimType, string claimValue);

        void DeleteUserClaim(string userId, string claimType, string claimValue);

        IList<UserLogin> GetUserLoginList(string userId);

        User FindUserByLogin(string loginProvider, string providerKey);

        void AddUserLogin(string userId, string loginProvider, string providerKey);

        void DeleteUserLogin(string userId, string loginProvider, string providerKey);
        */
    }
}