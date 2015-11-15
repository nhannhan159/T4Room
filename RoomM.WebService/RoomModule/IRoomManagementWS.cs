using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using RoomM.Domain.AssetModule.Aggregates;
using RoomM.Domain.RoomModule.Aggregates;

namespace RoomM.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRoomAssetService" in both code and config file together.
    [ServiceContract]
    public interface IRoomManagementWS
    {
        [OperationContract]
        IList<Room> GetRoomList();

        [OperationContract]
        IList<RoomType> GetRoomTypeList();

        [OperationContract]
        IList<RoomRegType> GetRoomRegTypeList();

        [OperationContract]
        IList<AssetHistoryType> GetAssetHistoryTypeList();

        [OperationContract]
        IList<RoomReg> GetRoomRegList(Int64 roomId);

        [OperationContract]
        IList<AssetDetail> GetAssetDetailList(Int64 roomId);

        [OperationContract]
        IList<AssetHistory> GetAssetHistoryList(Int64 roomId);

        [OperationContract]
        IList<AssetHistory> GetByRoom2RoomId(Room room, DateTime timeForBacktrace);

        [OperationContract]
        void AddRoom(Room room);

        [OperationContract]
        void EditRoom(Room room);

        [OperationContract]
        void DeleteRoom(Room room);

        [OperationContract]
        void ChangeRoomRegType(RoomReg roomReg);
    }
}
