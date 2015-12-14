using RoomM.Application.RoomM.Domain.AssetModule.Aggregates;
using RoomM.Application.RoomM.Domain.RoomModule.Aggregates;
using RoomM.Application.Default;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.ServiceModel;
using System.Data.SqlClient;

namespace RoomM.Application.AssetModule.Services
{
    public class AssetManagementService : IAssetManagementService
    {
        private Container container;

        public AssetManagementService(Container container)
        {
            this.container = container;
        }

        #region Basic CRUD

        public IList<Asset> GetAssetList()
        {
            return this.container.Assets.ToList();
        }

        public void AddAsset(Asset asset)
        {
            this.container.AddToAssets(asset);
            this.container.SaveChanges();
        }

        public void EditAsset(Asset asset)
        {
            this.container.UpdateObject(asset);
            this.container.SaveChanges();
        }

        public void DeleteAsset(Asset asset)
        {
            asset.IsUsing = false;
            this.container.UpdateObject(asset);
            this.container.SaveChanges();
        }

        #endregion Basic CRUD

        #region Addition Lists

        public static int ASSETS_TRANSFER = 1;
        public static int ASSETS_REMOVE   = 2;
        public static int ASSETS_IMPORT   = 3;
        public static int ASSETS_RECEVIE  = 4;
        public static Dictionary<int, string> GetAssetHistoryType = new Dictionary<int, string>() {
            { ASSETS_TRANSFER       , "Chuyển thiết bị"   },
            { ASSETS_REMOVE         , "Thanh lí thiết bị" },
            { ASSETS_IMPORT         , "Nhập thiết bị"     },
            { ASSETS_RECEVIE        , "Nhận thiết bị"     }
        };

        public IList<AssetDetail> GetAssetDetailList()
        {
            return this.container.AssetDetails.ToList();
        }

        public IList<AssetDetail> GetAssetDetailListByAssetId(string assetId)
        {
            return this.container.AssetDetails.Where(p => assetId.Equals(p.AssetId)).ToList();
        }

        public IList<AssetDetail> GetAssetDetailListByRoomId(string roomId)
        {
            return this.container.AssetDetails.Where(p => roomId.Equals(p.RoomId)).ToList();
        }

        public IList<AssetHistory> GetAssetHisListByRoomId(string roomId)
        {
            return this.container.AssetHistories.Where(p => roomId.Equals(p.RoomId)).ToList();
        }

        public IList<AssetHistory> GetAssetHisListByBacktrace(Room room, DateTime timeForBacktrace)
        {
            return new List<AssetHistory>();
        }

        public string GetAssetAllRoomName(string assetId)
        {
            return "";
        }

        #endregion Addition Lists

        #region Addition Services

        public void ImportAsset(string assetId, string roomId, int amount)
        {
            throw new NotImplementedException();
        }

        public void DropAsset(AssetDetail assetDetail, int amount)
        {
            throw new NotImplementedException();
        }

        public void TransferAsset(AssetDetail assetDetail, Room target, int amount)
        {
            throw new NotImplementedException();
        }

        #endregion Addition Services
    }
}