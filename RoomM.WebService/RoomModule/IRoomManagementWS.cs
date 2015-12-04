using RoomM.Domain.RoomModule.Aggregates;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace RoomM.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRoomAssetService" in both code and config file together.
    [ServiceContract]
    public interface IRoomManagementWS
    {
        [OperationContract]
        Room GetRoom(Int64 roomId);

        [OperationContract]
        IList<Room> GetRoomList();

        [OperationContract]
        IList<Room> GetRoomListByRoomId(Int64 roomTypeId);

        [OperationContract]
        IList<RoomType> GetRoomTypeList();

        [OperationContract]
        RoomReg GetRoomReg(Int64 roomRegId);

        [OperationContract]
        IList<RoomReg> GetRoomRegListByRoomId(Int64 roomId);

        [OperationContract]
        IList<RoomReg> GetRoomRegListByUserId(Int64 userId);

        [OperationContract]
        IList<RoomReg> GetRoomRegListByDate(DateTime date, Int64 roomId);

        [OperationContract]
        IList<RoomReg> GetRoomRegListByWeek(DateTime date, Int64 roomId);

        [OperationContract]
        IList<RoomReg> GetRoomRegListByWatchedState(bool isWatched, Int64 userId);

        [OperationContract]
        IList<KeyValuePair<Room, int>> GetRoomLimitByRegister(int limit, DateTime from, DateTime to);

        [OperationContract]
        void AddRoom(Room room);

        [OperationContract]
        void EditRoom(Room room);

        [OperationContract]
        void DeleteRoom(Room room);

        [OperationContract]
        void EditRoomReg(RoomReg roomReg);

        [OperationContract]
        void DeleteRoomReg(Int64 roomRegId);
    }
}