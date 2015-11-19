using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RoomM.Domain.AssetModule.Aggregates;
using RoomM.Domain.RoomModule.Aggregates;

namespace RoomM.Application.RoomModule.Services
{
    public interface IRoomManagementService
    {
        Room GetRoom(Int64 roomId);
        IList<Room> GetRoomList();
        IList<Room> GetRoomListByRoomId(Int64 roomTypeId);
        IList<RoomType> GetRoomTypeList();
        RoomReg GetRoomReg(Int64 roomRegId);
        IList<RoomReg> GetRoomRegList(Int64 roomId);
        IList<RoomReg> GetRoomRegListByDate(DateTime date, Int64 roomId);
        IList<RoomReg> GetRoomRegListByWeek(DateTime date, Int64 roomId);
        IList<RoomReg> GetRoomRegListByWatchedState(bool isWatched, Int64 userId);
        IList<AssetDetail> GetAssetDetailList(Int64 roomId);
        IList<AssetHistory> GetAssetHistoryList(Int64 roomId);
        IList<AssetHistory> GetByRoom2RoomId(Room room, DateTime timeForBacktrace);
        void AddRoom(Room room);
        void EditRoom(Room room);
        void DeleteRoom(Room room);
        void EditRoomReg(RoomReg roomReg);
        void DeleteRoomReg(Int64 roomRegId);
    }
}
