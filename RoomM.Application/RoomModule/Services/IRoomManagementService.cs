using RoomM.Application.RoomM.Domain.RoomModule.Aggregates;
using System;
using System.Collections.Generic;

namespace RoomM.Application.RoomModule.Services
{
    public interface IRoomManagementService
    {
        Room GetRoom(string roomId);

        IList<Room> GetRoomList();

        IList<Room> GetRoomListByRoomTypeId(string roomTypeId);

        IList<RoomType> GetRoomTypeList();

        RoomReg GetRoomReg(string roomRegId);

        IList<RoomReg> GetRoomRegListByRoomId(string roomId);

        IList<RoomReg> GetRoomRegListByUserId(string userId);

        IList<RoomReg> GetRoomRegListByDate(DateTime date, string roomId);

        IList<RoomReg> GetRoomRegListByWeek(DateTime date, string roomId);

        IList<RoomReg> GetRoomRegListByWatchedState(bool isWatched, string userId);

        IList<KeyValuePair<Room, int>> GetRoomLimitByRegister(int limit, DateTime from, DateTime to);

        void AddRoom(Room room);

        void EditRoom(Room room);

        void DeleteRoom(Room room);

        void AddRoomReg(RoomReg roomReg);

        void EditRoomReg(RoomReg roomReg);

        void DeleteRoomReg(string roomRegId);
    }
}