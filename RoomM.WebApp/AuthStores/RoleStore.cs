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

        #region Implement "IUserStore"

        public Task CreateAsync(TRole role)
        {

        }

        public Task DeleteAsync(TRole role)
        {

        }

        public Task<TRole> FindByIdAsync(Int64 roleId)
        {

        }

        public Task<TRole> FindByNameAsync(string roleName)
        {

        }

        public Task UpdateAsync(TRole role)
        {

        }

        #endregion
    }
}
