using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using RoomM.Domain.RoomModule.Aggregates;
using RoomM.Domain.UserModule.Aggregates;
using RoomM.Application.UserModule.Services;

namespace RoomM.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "StaffService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select StaffService.svc or StaffService.svc.cs at the Solution Explorer and start debugging.
    public class UserManagementWS : IUserManagementWS
    {
        private IUserManagementService service;

        public UserManagementWS(IUserManagementService service)
        {
            this.service = service;
            this.service.EnableWSMode();
        }

        #region Basic CRUD

        public IList<User> GetUserList()
        {
            return this.service.GetUserList();
        }

        public void AddUser(User user)
        {
            this.service.AddUser(user);
        }

        public void EditUser(User user)
        {
            this.service.EditUser(user);
        }

        public void DeleteUser(User user)
        {
            this.service.DeleteUser(user);
        }

        #endregion

        #region Addition Lists

        public IList<UserRole> GetUserRoleList()
        {
            return this.service.GetUserRoleList();
        }

        public IList<RoomType> GetRoomTypeList()
        {
            return this.service.GetRoomTypeList();
        }

        public IList<RoomRegType> GetRoomRegTypeList()
        {
            return this.service.GetRoomRegTypeList();
        }

        public IList<RoomReg> GetRoomRegList(Int64 userId)
        {
            return this.service.GetRoomRegList(userId);
        }

        #endregion
    }
}
