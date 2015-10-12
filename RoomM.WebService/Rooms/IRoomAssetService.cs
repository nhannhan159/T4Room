using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using RoomM.Models;

namespace RoomM.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRoomAssetService" in both code and config file together.
    [ServiceContract]
    public interface IRoomAssetService
    {
        [OperationContract]
        RoomAsset GetSingle(Int64 roomDeviceId);

        [OperationContract]
        IList<RoomAsset> GetByRoomId(Int64 id);

        [OperationContract]
        IList<RoomAsset> GetByAssetId(Int64 id);

        [OperationContract]
        void AddOrUpdate(Int64 roomId, Int64 assetId, int amount);
    }
}
