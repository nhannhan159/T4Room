using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RoomM.Domain;
using RoomM.Domain.AssetModule.Aggregates;
using RoomM.Domain.RoomModule.Aggregates;

namespace RoomM.Application.AssetModule.Services
{
    public interface IAssetManagementService
    {
        IList<Asset> GetAssetList();
        IList<Room> GetRoomList();
        IList<RoomType> GetRoomTypeList();
        IList<AssetDetail> GetAssetDetailList();
        IList<AssetDetail> GetAssetDetailListByAssetId(Int64 assetId);
        void AddAsset(Asset asset);
        void EditAsset(Asset asset);
        void DeleteAsset(Asset asset);
        void ImportAsset(Int64 assetId, Int64 roomId, int amount);
        void DropAsset(AssetDetail assetDetail, int amount);
        void TransferAsset(AssetDetail assetDetail, Room target, int amount);
    }
}
