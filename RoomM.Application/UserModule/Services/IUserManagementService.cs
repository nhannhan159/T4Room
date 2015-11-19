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
        User GetSingle(Int64 userId);
        User GetSingleByUsername(string username);
        IList<User> GetUserList();
        IList<Role> GetRoleList();
        IList<RoomType> GetRoomTypeList();
        IList<RoomReg> GetRoomRegList(Int64 userId);
        void AddUser(User user);
        void EditUser(User user);
        void DeleteUser(User user);
        void AddUserToRole(User user, string roleName);
    }
}
