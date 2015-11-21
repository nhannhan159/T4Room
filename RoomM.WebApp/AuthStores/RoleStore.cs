using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

using RoomM.Domain.UserModule.Aggregates;
using RoomM.Application.UserModule.Services;

namespace RoomM.WebApp.AuthStores
{
    public class RoleStore<TRole> : IRoleStore<TRole, Int64> where TRole : Role
    {
        private IUserManagementService service;

        public RoleStore(IUserManagementService service)
        {
            this.service = service;
        }

        #region Implement "IRoleStore"

        public Task CreateAsync(TRole role)
        {
            if (role == null)
            {
                throw new ArgumentNullException("role");
            }

            this.service.AddRole(role);
            return Task.FromResult<object>(null);
        }

        public Task DeleteAsync(TRole role)
        {
            if (role == null)
            {
                throw new ArgumentNullException("user");
            }

            this.service.DeleteRole(role.Id);
            return Task.FromResult<Object>(null);
        }

        public Task<TRole> FindByIdAsync(Int64 roleId)
        {
            TRole result = this.service.GetRoleById(roleId) as TRole;
            return Task.FromResult<TRole>(result);
        }

        public Task<TRole> FindByNameAsync(string roleName)
        {
            TRole result = this.service.GetRoleByName(roleName) as TRole;
            return Task.FromResult<TRole>(result);
        }

        public Task UpdateAsync(TRole role)
        {
            if (role == null)
            {
                throw new ArgumentNullException("user");
            }

            this.service.EditRole(role);
            return Task.FromResult<Object>(null);
        }

        public void Dispose() { }

        #endregion
    }
}
