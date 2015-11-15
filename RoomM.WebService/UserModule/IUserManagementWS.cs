using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using RoomM.Domain.RoomModule.Aggregates;
using RoomM.Domain.UserModule.Aggregates;

namespace RoomM.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IStaffService" in both code and config file together.
    [ServiceContract]
    public interface IUserManagementWS
    {
        [OperationContract]
        IList<User> GetUserList();

        [OperationContract]
        IList<UserRole> GetUserRoleList();

        [OperationContract]
        IList<RoomType> GetRoomTypeList();

        [OperationContract]
        IList<RoomRegType> GetRoomRegTypeList();

        [OperationContract]
        IList<RoomReg> GetRoomRegList(Int64 userId);

        [OperationContract]
        void AddUser(User user);

        [OperationContract]
        void EditUser(User user);

        [OperationContract]
        void DeleteUser(User user);
    }
}
