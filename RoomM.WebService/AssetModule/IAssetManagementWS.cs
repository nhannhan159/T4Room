using RoomM.Domain.AssetModule.Aggregates;
using RoomM.Domain.RoomModule.Aggregates;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace RoomM.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IAssetManagementWS
    {
        [OperationContract]
        IList<Asset> GetAssetList();

        [OperationContract]
        IList<AssetDetail> GetAssetDetailList();

        [OperationContract]
        IList<AssetDetail> GetAssetDetailListByAssetId(Int64 assetId);

        [OperationContract]
        IList<AssetDetail> GetAssetDetailListByRoomId(Int64 roomId);

        [OperationContract]
        IList<AssetHistory> GetAssetHisListByRoomId(Int64 roomId);

        [OperationContract]
        IList<AssetHistory> GetAssetHisListByBacktrace(Room room, DateTime timeForBacktrace);

        [OperationContract]
        void AddAsset(Asset asset);

        [OperationContract]
        void EditAsset(Asset asset);

        [OperationContract]
        void DeleteAsset(Asset asset);

        [OperationContract]
        void ImportAsset(Int64 assetId, Int64 roomId, int amount);

        [OperationContract]
        void DropAsset(AssetDetail assetDetail, int amount);

        [OperationContract]
        void TransferAsset(AssetDetail assetDetail, Room target, int amount);
    }
}