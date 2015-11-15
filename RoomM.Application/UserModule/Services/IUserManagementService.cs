using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RoomM.Domain.RoomModule.Aggregates;
using RoomM.Domain.UserModule.Aggregates;

namespace RoomM.Application.UserModule.Services
{
    public interface IUserManagementService
    {
        void EnableWSMode();
        IList<User> GetUserList();
        IList<UserRole> GetUserRoleList();
        IList<RoomType> GetRoomTypeList();
        IList<RoomRegType> GetRoomRegTypeList();
        IList<RoomReg> GetRoomRegList(Int64 userId);
        void AddUser(User user);
        void EditUser(User user);
        void DeleteUser(User user);
    }
}
