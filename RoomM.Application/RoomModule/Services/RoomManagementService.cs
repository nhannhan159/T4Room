using RoomM.Application.RoomM.Domain.RoomModule.Aggregates;
using RoomM.Application.Default;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace RoomM.Application.RoomModule.Services
{
    public class RoomManagementService : IRoomManagementService
    {
        private Container container;

        public RoomManagementService(Container container)
        {
            this.container = container;
        }

        #region Basic CRUD

        public Room GetRoom(string roomId)
        {
            return this.container.Rooms.SingleOrDefault(p => roomId.Equals(p.Id));
        }

        public IList<Room> GetRoomList()
        {
            return this.container.Rooms.ToList();
        }

        public IList<Room> GetRoomListByRoomTypeId(string roomTypeId)
        {
            return this.container.Rooms.Where(p => roomTypeId.Equals(p.RoomTypeId)).ToList();
        }

        public void AddRoom(Room room)
        {
            this.container.AddToRooms(room);
            this.container.SaveChanges();
        }

        public void EditRoom(Room room)
        {
            this.container.UpdateObject(room);
            this.container.SaveChanges();
        }

        public void DeleteRoom(Room room)
        {
            room.IsUsing = false;
            this.container.UpdateObject(room);
            this.container.SaveChanges();
        }

        #endregion Basic CRUD

        #region Addition Lists

        public static int REG_WAITING   = 1;
        public static int REG_COMFIRMED = 2;
        public static int REG_CANCELED  = 3;
        public static Dictionary<int, string> GetRoomRegType = new Dictionary<int, string>() {
            { REG_WAITING  , "Chờ xác nhận" },
            { REG_COMFIRMED, "Đã đăng ký" },
            { REG_CANCELED , "Hủy đăng ký" }
        };

        public IList<RoomType> GetRoomTypeList()
        {
            return this.container.RoomTypes.ToList();
        }

        public RoomReg GetRoomReg(string roomRegId)
        {
            return this.container.RoomRegs.SingleOrDefault(p => roomRegId.Equals(p.Id));
        }

        public IList<RoomReg> GetRoomRegListByRoomId(string roomId)
        {
            return this.container.RoomRegs.Where(p => roomId.Equals(p.RoomId)).ToList();
        }

        public IList<RoomReg> GetRoomRegListByUserId(string userId)
        {
            return this.container.RoomRegs.Where(p => userId.Equals(p.UserId)).ToList();
        }

        public IList<RoomReg> GetRoomRegListByDate(DateTime date, string roomId)
        {
            return new List<RoomReg>();
        }

        public IList<RoomReg> GetRoomRegListByWeek(DateTime date, string roomId)
        {
            return new List<RoomReg>();
        }

        public IList<RoomReg> GetRoomRegListByWatchedState(bool isWatched, string userId)
        {
            return new List<RoomReg>();
        }

        public IList<KeyValuePair<Room, int>> GetRoomLimitByRegister(int limit, DateTime from, DateTime to)
        {
            return new List<KeyValuePair<Room, int>>();
        }

        #endregion Addition Lists

        #region Addition Services

        public void AddRoomReg(RoomReg roomReg)
        {
            throw new NotImplementedException();
        }

        public void EditRoomReg(RoomReg roomReg)
        {
            throw new NotImplementedException();
        }

        public void DeleteRoomReg(string roomRegId)
        {
            throw new NotImplementedException();
        }

        #endregion Addition Services
    }
}