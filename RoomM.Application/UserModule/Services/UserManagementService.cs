using RoomM.Domain.UserModule.Aggregates;
using RoomM.Infrastructure.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace RoomM.Application.UserModule.Services
{
    public class UserManagementService : IUserManagementService
    {
        private IUnitOfWork context;

        public UserManagementService(IUnitOfWork context)
        {
            this.context = context;
        }

        public void EnableWSMode()
        {
            this.context.EnableWSMode();
        }

        #region Basic CRUD

        public User GetSingle(Int64 userId)
        {
            return this.context.UserRep.GetSingle(userId);
        }

        public User GetSingleByUsername(string username)
        {
            return this.context.UserRep.GetSingleByUsername(username);
        }

        public IList<User> GetUserList()
        {
            return this.context.UserRep.GetAll();
        }

        public void AddUser(User user)
        {
            try
            {
                this.context.UserRep.Add(user);
                this.context.Commit();
            }
            catch (DbEntityValidationException ex)
            {
                var error = ex.EntityValidationErrors.First().ValidationErrors.First();
                throw new ApplicationException(error.ErrorMessage);
            }
        }

        public void EditUser(User user)
        {
            try
            {
                this.context.UserRep.Edit(user);
                this.context.Commit();
            }
            catch (DbEntityValidationException ex)
            {
                var error = ex.EntityValidationErrors.First().ValidationErrors.First();
                throw new ApplicationException(error.ErrorMessage);
            }
        }

        public void DeleteUser(User user)
        {
            try
            {
                user.IsWorking = false;
                this.context.UserRep.Edit(user);
                this.context.Commit();
            }
            catch (DbEntityValidationException ex)
            {
                var error = ex.EntityValidationErrors.First().ValidationErrors.First();
                throw new ApplicationException(error.ErrorMessage);
            }
        }

        #endregion Basic CRUD

        #region Addition Lists

        public IList<Role> GetRoleList()
        {
            return this.context.RoleRep.GetAll();
        }

        public IList<KeyValuePair<User, int>> GetUserLimitByRegister(int limit, DateTime from, DateTime to)
        {
            return this.context.UserRep.GetUserLimitByRegister(limit, from, to);
        }

        #endregion Addition Lists

        #region Addition Services

        public Role GetRoleById(Int64 roleId)
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

        public void DeleteRole(Int64 roleId)
        {
            this.context.RoleRep.Delete(roleId);
            this.context.Commit();
        }

        public IList<UserClaim> GetUserClaimList(Int64 userId)
        {
            return this.context.UserClaimRep.GetByUserId(userId);
        }

        public void AddUserClaim(Int64 userId, string claimType, string claimValue)
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

        public void DeleteUserClaim(Int64 userId, string claimType, string claimValue)
        {
            this.context.UserClaimRep.Delete(userId, claimType, claimValue);
            this.context.Commit();
        }

        public IList<UserLogin> GetUserLoginList(Int64 userId)
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

        public void AddUserLogin(Int64 userId, string loginProvider, string providerKey)
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

        public void DeleteUserLogin(Int64 userId, string loginProvider, string providerKey)
        {
            this.context.UserLoginRep.Delete(userId, loginProvider, providerKey);
            this.context.Commit();
        }

        #endregion Addition Services
    }
}