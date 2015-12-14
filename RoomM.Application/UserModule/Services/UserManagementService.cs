using RoomM.Application.RoomM.Domain.UserModule.Aggregates;
using RoomM.Application.Default;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace RoomM.Application.UserModule.Services
{
    public class UserManagementService : IUserManagementService
    {
        private Container container;

        public UserManagementService(Container container)
        {
            this.container = container;
        }

        #region Basic CRUD

        public User GetUser(string userId)
        {
            return this.container.Users.SingleOrDefault(p => userId.Equals(p.Id));
        }

        public User GetUserByUsername(string username)
        {
            return this.container.Users.SingleOrDefault(p => username.Equals(p.UserName));
        }

        public IList<User> GetUserList()
        {
            return this.container.Users.ToList();
        }

        public void AddUser(User user)
        {
            this.container.AddToUsers(user);
            this.container.SaveChanges();
        }

        public void EditUser(User user)
        {
            this.container.UpdateObject(user);
            this.container.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            user.IsWorking = false;
            this.container.UpdateObject(user);
            this.container.SaveChanges();
        }

        #endregion Basic CRUD

        #region Addition Lists

        public IList<Role> GetRoleList()
        {
            return this.container.Roles.ToList();
        }

        public IList<KeyValuePair<User, int>> GetUserLimitByRegister(int limit, DateTime from, DateTime to)
        {
            return new List<KeyValuePair<User, int>>();
        }

        #endregion Addition Lists

        #region Addition Services
        /*
        public Role GetRoleById(string roleId)
        {
            return this.context.RoleRep.GetSingle(roleId);
        }

        public Role GetRoleByName(string roleName)
        {
            return this.context.RoleRep.GetSingleByName(roleName);
        }

        public void AddRole(Role role)
        {
            try
            {
                this.context.RoleRep.Add(role);
                this.context.Commit();
            }
            catch (DbEntityValidationException ex)
            {
                var error = ex.EntityValidationErrors.First().ValidationErrors.First();
                throw new ApplicationException(error.ErrorMessage);
            }
        }

        public void EditRole(Role role)
        {
            try
            {
                this.context.RoleRep.Add(role);
                this.context.Commit();
            }
            catch (DbEntityValidationException ex)
            {
                var error = ex.EntityValidationErrors.First().ValidationErrors.First();
                throw new ApplicationException(error.ErrorMessage);
            }
        }

        public void DeleteRole(string roleId)
        {
            this.context.RoleRep.Delete(roleId);
            this.context.Commit();
        }

        public IList<UserClaim> GetUserClaimList(string userId)
        {
            return this.context.UserClaimRep.GetByUserId(userId);
        }

        public void AddUserClaim(string userId, string claimType, string claimValue)
        {
            UserClaim userClaim = new UserClaim()
            {
                UserId = userId,
                ClaimType = claimType,
                ClaimValue = claimValue
            };
            this.context.UserClaimRep.Add(userClaim);
            this.context.Commit();
        }

        public void DeleteUserClaim(string userId, string claimType, string claimValue)
        {
            this.context.UserClaimRep.Delete(userId, claimType, claimValue);
            this.context.Commit();
        }

        public IList<UserLogin> GetUserLoginList(string userId)
        {
            return this.context.UserLoginRep.GetByUserId(userId);
        }

        public User FindUserByLogin(string loginProvider, string providerKey)
        {
            Int64 userId = this.context.UserLoginRep.GetUserId(loginProvider, providerKey);
            if (userId != 0)
            {
                return this.context.UserRep.GetSingle(userId);
            }
            return null;
        }

        public void AddUserLogin(string userId, string loginProvider, string providerKey)
        {
            UserLogin userLogin = new UserLogin()
            {
                UserId = userId,
                LoginProvider = loginProvider,
                ProviderKey = providerKey
            };
            this.context.UserLoginRep.Add(userLogin);
            this.context.Commit();
        }

        public void DeleteUserLogin(string userId, string loginProvider, string providerKey)
        {
            this.context.UserLoginRep.Delete(userId, loginProvider, providerKey);
            this.context.Commit();
        }
        */
        #endregion Addition Services
    }
}