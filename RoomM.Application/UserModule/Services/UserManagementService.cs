using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Validation;

using RoomM.Domain;
using RoomM.Domain.RoomModule.Aggregates;
using RoomM.Domain.UserModule.Aggregates;

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

        public IList<User> GetUserList()
        {
            return this.context.UserRep.GetAll();
        }

        public void AddUser(User user)
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

        #endregion

        #region Addition Lists

        public IList<Role> GetRoleList()
        {
            return this.context.RoleRep.GetAll();
        }

        public IList<RoomType> GetRoomTypeList()
        {
            return this.context.RoomTypeRep.GetAll();
        }

        public IList<RoomReg> GetRoomRegList(Int64 userId)
        {
            return this.context.RoomRegRep.GetByUserId(userId);
        }

        #endregion
    }
}
