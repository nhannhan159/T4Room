using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Validation;
using System.Security.Claims;
using Microsoft.AspNet.Identity;

using RoomM.WebApp.Models;
using RoomM.Domain;
using RoomM.Domain.UserModule.Aggregates;
using RoomM.Application.UserModule.Services;

namespace RoomM.WebApp.AuthStores
{
    public class UserStore<TUser> : 
        IUserStore<TUser, Int64>,
        IUserRoleStore<TUser, Int64>,
        IUserPasswordStore<TUser, Int64>,
        IUserEmailStore<TUser, Int64>,
        IUserLockoutStore<TUser, Int64>,
        IUserTwoFactorStore<TUser, Int64>,
        IUserClaimStore<TUser, Int64>,
        IUserSecurityStampStore<TUser, Int64>,
        IUserLoginStore<TUser, Int64>
        where TUser : User
    {
        private IUserManagementService service;

        public UserStore(IUserManagementService service)
        {
            this.service = service;
        }

        #region Implement "IUserStore"

        public Task CreateAsync(TUser user)
        {
            this.service.AddUser(user);
            return Task.FromResult<Object>(null);
        }

        public Task DeleteAsync(TUser user)
        {
            // This method is currently unused.
            throw new NotSupportedException();
        }

        public Task<TUser> FindByIdAsync(Int64 userId)
        {
            var user = this.service.GetSingle(userId);
            if (user != null && !user.IsWorking)
                user = null;
            return Task.FromResult<TUser>(user as TUser);
        }

        public Task<TUser> FindByNameAsync(string userName)
        {
            var user = this.service.GetSingleByUsername(userName);
            if (user != null && !user.IsWorking)
                user = null;
            return Task.FromResult<TUser>(user as TUser);
        }

        public Task UpdateAsync(TUser user)
        {
            this.service.EditUser(user);
            return Task.FromResult<Object>(null);
        }

        public void Dispose() { }

        #endregion

        #region Implement "IUserPasswordStore"

        public Task<string> GetPasswordHashAsync(TUser user)
        {
            string passwordHash = user.PasswordHash;
            return Task.FromResult<string>(passwordHash);
        }

        public Task<bool> HasPasswordAsync(TUser user)
        {
            bool hasPassword = !string.IsNullOrEmpty(user.PasswordHash);
            return Task.FromResult<bool>(hasPassword);
        }

        public Task SetPasswordHashAsync(TUser user, string passwordHash)
        {
            user.PasswordHash = passwordHash;
            return Task.FromResult<Object>(null);
        }

        #endregion

        #region Implement "IUserEmailStore"

        public Task<TUser> FindByEmailAsync(string email)
        {
            if (String.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException("email");
            }

            var user = this.service.GetSingleByUsername(email);
            return Task.FromResult<TUser>(user as TUser);
        }

        public Task<string> GetEmailAsync(TUser user)
        {
            return Task.FromResult(user.UserName);
        }

        public Task<bool> GetEmailConfirmedAsync(TUser user)
        {
            return Task.FromResult(true);
        }

        public Task SetEmailAsync(TUser user, string email)
        {
            user.UserName = email;
            user.FullName = email;
            //this.service.EditUser(user);
            return Task.FromResult(0);
        }

        public Task SetEmailConfirmedAsync(TUser user, bool confirmed)
        {
            return Task.FromResult(0);
        }

        #endregion

        #region Implement "IUserLockoutStore"

        public Task<int> GetAccessFailedCountAsync(TUser user)
        {
            return Task.FromResult(user.AccessFailedCount);
        }

        public Task<bool> GetLockoutEnabledAsync(TUser user)
        {
            return Task.FromResult(user.LockoutEnabled);
        }

        public Task<DateTimeOffset> GetLockoutEndDateAsync(TUser user)
        {
            return
                Task.FromResult(user.LockoutEndDateUtc.HasValue
                    ? new DateTimeOffset(DateTime.SpecifyKind(user.LockoutEndDateUtc.Value, DateTimeKind.Utc))
                    : new DateTimeOffset());
        }

        public Task<int> IncrementAccessFailedCountAsync(TUser user)
        {
            user.AccessFailedCount++;
            //this.service.EditUser(user);
            return Task.FromResult(user.AccessFailedCount);
        }

        public Task ResetAccessFailedCountAsync(TUser user)
        {
            user.AccessFailedCount = 0;
            //this.service.EditUser(user);
            return Task.FromResult(0);
        }

        public Task SetLockoutEnabledAsync(TUser user, bool enabled)
        {
            user.LockoutEnabled = enabled;
            //this.service.EditUser(user);
            return Task.FromResult(0);
        }

        public Task SetLockoutEndDateAsync(TUser user, DateTimeOffset lockoutEnd)
        {
            user.LockoutEndDateUtc = lockoutEnd.UtcDateTime;
            //this.service.EditUser(user);
            return Task.FromResult(0);
        }

        #endregion

        #region Implement "IUserTwoFactorStore"

        public Task<bool> GetTwoFactorEnabledAsync(TUser user)
        {
            return Task.FromResult(user.TwoFactorEnabled);
        }

        public Task SetTwoFactorEnabledAsync(TUser user, bool enabled)
        {
            user.TwoFactorEnabled = enabled;
            //this.service.EditUser(user);
            return Task.FromResult(0);
        }

        #endregion 

        #region Implement "IUserSecurityStampStore"

        public Task<string> GetSecurityStampAsync(TUser user)
        {
            return Task.FromResult(user.SecurityStamp);
        }

        public Task SetSecurityStampAsync(TUser user, string stamp)
        {
            user.SecurityStamp = stamp;
            //this.service.EditUser(user);
            return Task.FromResult(0);
        }

        #endregion

        #region Implement "IUserClaimStore"

        public Task AddClaimAsync(TUser user, Claim claim)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            if (claim == null)
            {
                throw new ArgumentNullException("claim");
            }

            this.service.AddUserClaim(user.Id, claim.Type, claim.Value);
            return Task.FromResult<object>(null);
        }

        public Task<IList<Claim>> GetClaimsAsync(TUser user)
        {
            ClaimsIdentity identity = new ClaimsIdentity();
            IList<UserClaim> userClaims = this.service.GetUserClaimList(user.Id);
            foreach (UserClaim userClaim in userClaims)
            {
                Claim claim = new Claim(userClaim.ClaimType, userClaim.ClaimValue);
                identity.AddClaim(claim);
            }
            return Task.FromResult<IList<Claim>>(identity.Claims.ToList());
        }

        public Task RemoveClaimAsync(TUser user, Claim claim)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            if (claim == null)
            {
                throw new ArgumentNullException("claim");
            }

            this.service.DeleteUserClaim(user.Id, claim.Type, claim.Value);
            return Task.FromResult<object>(null);
        }

        #endregion

        #region Implement "IUserLoginStore"

        public Task AddLoginAsync(TUser user, UserLoginInfo login)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            if (login == null)
            {
                throw new ArgumentNullException("login");
            }

            this.service.AddUserLogin(user.Id, login.LoginProvider, login.ProviderKey);
            return Task.FromResult<object>(null);
        }

        public Task<TUser> FindAsync(UserLoginInfo login)
        {
            if (login == null)
            {
                throw new ArgumentNullException("login");
            }

            User user = this.service.FindUserByLogin(login.LoginProvider, login.ProviderKey);
            return Task.FromResult<TUser>(user as TUser);
        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(TUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            IList<UserLoginInfo> userLoginInfos = new List<UserLoginInfo>();
            IList<UserLogin> userLogins = this.service.GetUserLoginList(user.Id);
            foreach (UserLogin userLogin in userLogins)
            {
                UserLoginInfo userLoginInfo = new UserLoginInfo(userLogin.LoginProvider, userLogin.ProviderKey);
                userLoginInfos.Add(userLoginInfo);
            }
            return Task.FromResult<IList<UserLoginInfo>>(userLoginInfos);
        }

        public Task RemoveLoginAsync(TUser user, UserLoginInfo login)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            if (login == null)
            {
                throw new ArgumentNullException("login");
            }

            this.service.DeleteUserLogin(user.Id, login.LoginProvider, login.ProviderKey);
            return Task.FromResult<Object>(null);
        }

        #endregion

        #region Implement "IUserRoleStore"

        public Task AddToRoleAsync(TUser user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task<IList<string>> GetRolesAsync(TUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            IList<string> roles = new List<string>() { user.Role.Name };
            return Task.FromResult<IList<string>>(roles);
        }

        public Task<bool> IsInRoleAsync(TUser user, string roleName)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            if (string.IsNullOrEmpty(roleName))
            {
                throw new ArgumentNullException("roleName");
            }

            bool result = user.Role.Name.Equals(roleName);
            return Task.FromResult<bool>(result);
        }

        public Task RemoveFromRoleAsync(TUser user, string roleName)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
