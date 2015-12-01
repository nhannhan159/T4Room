using RoomM.Domain.AssetModule.Aggregates;
using RoomM.Domain.RoomModule.Aggregates;
using System;
using System.Collections.Generic;

namespace RoomM.Application.AssetModule.Services
{
    public interface IAssetManagementService
    {
        IList<Asset> GetAssetList();

        IList<AssetDetail> GetAssetDetailList();

        IList<AssetDetail> GetAssetDetailListByAssetId(Int64 assetId);

        IList<AssetDetail> GetAssetDetailListByRoomId(Int64 roomId);

        IList<AssetHistory> GetAssetHisListByRoomId(Int64 roomId);

        IList<AssetHistory> GetAssetHisListByBacktrace(Room room, DateTime timeForBacktrace);

        void AddAsset(Asset asset);

        void EditAsset(Asset asset);

        void DeleteAsset(Asset asset);

        void ImportAsset(Int64 assetId, Int64 roomId, int amount);

        void DropAsset(AssetDetail assetDetail, int amount);

        void TransferAsset(AssetDetail assetDetail, Room target, int amount);
    }
}