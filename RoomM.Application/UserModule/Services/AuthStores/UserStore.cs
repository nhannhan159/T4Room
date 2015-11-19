using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Validation;
using Microsoft.AspNet.Identity;

using RoomM.Domain;
using RoomM.Domain.UserModule.Aggregates;

namespace RoomM.Application.UserModule.Services.AuthStores
{
    public class UserStore : IUserStore<User, Int64>,
        IUserRoleStore<User, Int64>,
        IUserPasswordStore<User, Int64>,
        IUserEmailStore<User, Int64>,
        IUserLockoutStore<User, Int64>,
        IUserTwoFactorStore<User, Int64>
    {
        private IUnitOfWork context;

        public UserStore(IUnitOfWork context)
        {
            this.context = context;
        }

        #region Implement "IUserStore"

        public Task CreateAsync(User user)
        {
            try
            {
                this.context.UserRep.Add(user);
                this.context.Commit();
                return Task.FromResult<Object>(null);
            }
            catch (DbEntityValidationException ex)
            {
                var error = ex.EntityValidationErrors.First().ValidationErrors.First();
                throw new ApplicationException(error.ErrorMessage);
            } 
        }

        public Task DeleteAsync(User user)
        {
            // This method is currently unused.
            throw new NotSupportedException();
        }

        public Task<User> FindByIdAsync(Int64 userId)
        {
            User user = this.context.UserRep.GetById(userId);
            return Task.FromResult<User>(user);
        }

        public Task<User> FindByNameAsync(string userName)
        {
            User user = this.context.UserRep.GetByUsername(userName);
            return Task.FromResult<User>(user);
        }

        public Task UpdateAsync(User user)
        {
            try
            {
                this.context.UserRep.Edit(user);
                this.context.Commit();
                return Task.FromResult<Object>(null);
            }
            catch (DbEntityValidationException ex)
            {
                var error = ex.EntityValidationErrors.First().ValidationErrors.First();
                throw new ApplicationException(error.ErrorMessage);
            }
        }

        public void Dispose()
        {
            this.context.Dispose();
        }

        #endregion

        #region Implement "IUserRoleStore"

        public Task AddToRoleAsync(User user, string roleName)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            if (string.IsNullOrEmpty(roleName))
            {
                throw new ArgumentException("Argument cannot be null or empty: roleName.");
            }

            Role role = this.context.RoleRep.GetByName(roleName);
            if (role != null)
            {
                user.Roles.Add(role);
                this.context.UserRep.Edit(user);
            }

            return Task.FromResult<object>(null);
        }

        public Task<IList<string>> GetRolesAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            List<string> roles = new List<string>();
            foreach (Role role in user.Roles)
            {
                roles.Add(role.Name);
            }

            if (roles.Count > 0)
            {
                return Task.FromResult<IList<string>>(roles);
            }

            return Task.FromResult<IList<string>>(null);
        }

        public Task<bool> IsInRoleAsync(User user, string roleName)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            if (string.IsNullOrEmpty(roleName))
            {
                throw new ArgumentNullException("roleName");
            }

            bool result = user.Roles.Count(p => p.Name.Equals(roleName)) > 0;
            return Task.FromResult<bool>(result);
        }

        public Task RemoveFromRoleAsync(User user, string roleName)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Implement "IUserPasswordStore"

        public Task<string> GetPasswordHashAsync(User user)
        {
            string passwordHash = user.PasswordHash;
            return Task.FromResult<string>(passwordHash);
        }

        public Task<bool> HasPasswordAsync(User user)
        {
            bool hasPassword = !string.IsNullOrEmpty(user.PasswordHash);
            return Task.FromResult<bool>(hasPassword);
        }

        public Task SetPasswordHashAsync(User user, string passwordHash)
        {
            user.PasswordHash = passwordHash;
            return Task.FromResult<Object>(null);
        }

        #endregion

        #region Implement "IUserEmailStore"

        public Task<User> FindByEmailAsync(string email)
        {
            if (String.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException("email");
            }

            User user = this.context.UserRep.GetByUsername(email);
            return Task.FromResult<User>(user);
        }

        public Task<string> GetEmailAsync(User user)
        {
            return Task.FromResult(user.UserName);
        }

        public Task<bool> GetEmailConfirmedAsync(User user)
        {
            return Task.FromResult(true);
        }

        public Task SetEmailAsync(User user, string email)
        {
            user.UserName = email;
            user.FullName = email;
            this.context.UserRep.Edit(user);
            return Task.FromResult(0);
        }

        public Task SetEmailConfirmedAsync(User user, bool confirmed)
        {
            return Task.FromResult(0);
        }

        #endregion

        #region Implement "IUserLockoutStore"

        public Task<int> GetAccessFailedCountAsync(User user)
        {
            return Task.FromResult(user.AccessFailedCount);
        }

        public Task<bool> GetLockoutEnabledAsync(User user)
        {
            return Task.FromResult(user.LockoutEnabled);
        }

        public Task<DateTimeOffset> GetLockoutEndDateAsync(User user)
        {
            return
                Task.FromResult(user.LockoutEndDateUtc.HasValue
                    ? new DateTimeOffset(DateTime.SpecifyKind(user.LockoutEndDateUtc.Value, DateTimeKind.Utc))
                    : new DateTimeOffset());
        }

        public Task<int> IncrementAccessFailedCountAsync(User user)
        {
            user.AccessFailedCount++;
            this.context.UserRep.Edit(user);
            return Task.FromResult(user.AccessFailedCount);
        }

        public Task ResetAccessFailedCountAsync(User user)
        {
            user.AccessFailedCount = 0;
            this.context.UserRep.Edit(user);
            return Task.FromResult(0);
        }

        public Task SetLockoutEnabledAsync(User user, bool enabled)
        {
            user.LockoutEnabled = enabled;
            this.context.UserRep.Edit(user);
            return Task.FromResult(0);
        }

        public Task SetLockoutEndDateAsync(User user, DateTimeOffset lockoutEnd)
        {
            user.LockoutEndDateUtc = lockoutEnd.UtcDateTime;
            this.context.UserRep.Edit(user);
            return Task.FromResult(0);
        }

        #endregion

        #region Implement "IUserTwoFactorStore"

        public Task<bool> GetTwoFactorEnabledAsync(User user)
        {
            return Task.FromResult(user.TwoFactorEnabled);
        }

        public Task SetTwoFactorEnabledAsync(User user, bool enabled)
        {
            user.TwoFactorEnabled = enabled;
            this.context.UserRep.Edit(user);
            return Task.FromResult(0);
        }

        #endregion
    }
}
