using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using RoomM.Models;

namespace RoomM.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRoomAssetHistory" in both code and config file together.
    [ServiceContract]
    public interface IRoomAssetHistoryService : IService<RoomAssetHistory>
    {
        [OperationContract]
        RoomAssetHistory GetSingle(int id);

        [OperationContract]
        IList<RoomAssetHistory> GetByRoomId(Int64 id);

        // List<RoomAssetHistory> GetHistoriesByToRoomId(Int64 roomId);

        [OperationContract]
        IList<RoomAssetHistory> GetByRoom2RoomId(Room room, DateTime timeForBacktrace);
    }
}
