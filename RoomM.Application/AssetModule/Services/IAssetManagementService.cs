using RoomM.Application.RoomM.Domain.AssetModule.Aggregates;
using RoomM.Application.RoomM.Domain.RoomModule.Aggregates;
using System;
using System.Collections.Generic;

namespace RoomM.Application.AssetModule.Services
{
    public interface IAssetManagementService
    {
        IList<Asset> GetAssetList();

        IList<AssetDetail> GetAssetDetailList();

        IList<AssetDetail> GetAssetDetailListByAssetId(string assetId);

        IList<AssetDetail> GetAssetDetailListByRoomId(string roomId);

        IList<AssetHistory> GetAssetHisListByRoomId(string roomId);

        IList<AssetHistory> GetAssetHisListByBacktrace(Room room, DateTime timeForBacktrace);

        string GetAssetAllRoomName(string assetId);

        void AddAsset(Asset asset);

        void EditAsset(Asset asset);

        void DeleteAsset(Asset asset);

        void ImportAsset(string assetId, string roomId, int amount);

        void DropAsset(AssetDetail assetDetail, int amount);

        void TransferAsset(AssetDetail assetDetail, Room target, int amount);
    }
}