using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using RoomM.Domain.AssetModule.Aggregates;
using RoomM.Domain.RoomModule.Aggregates;
using RoomM.Application.AssetModule.Services;

namespace RoomM.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class AssetManagementWS : IAssetManagementWS
    {
        private IAssetManagementService service;

        public AssetManagementWS(IAssetManagementService service)
        {
            this.service = service;
            this.service.EnableWSMode();
        }

        #region Basic CRUD

        public IList<Asset> GetAssetList()
        {
            return this.service.GetAssetList();
        }

        public void AddAsset(Asset asset)
        {
            this.service.AddAsset(asset);
        }

        public void EditAsset(Asset asset)
        {
            this.service.EditAsset(asset);
        }

        public void DeleteAsset(Asset asset)
        {
            this.service.DeleteAsset(asset);
        }

        #endregion

        #region Addition Lists

        public IList<Room> GetRoomList()
        {
            return this.service.GetRoomList();
        }

        public IList<RoomType> GetRoomTypeList()
        {
            return this.service.GetRoomTypeList();
        }

        public IList<AssetDetail> GetAssetDetailList(Int64 assetId)
        {
            return this.service.GetAssetDetailList(assetId);
        }

        #endregion

        #region Addition Services

        public void ImportAsset(Int64 assetId, Int64 roomId, int amount)
        {
            this.service.ImportAsset(assetId, roomId, amount);
        }

        public void DropAsset(AssetDetail assetDetail, int amount)
        {
            this.service.DropAsset(assetDetail, amount);
        }

        public void TransferAsset(AssetDetail assetDetail, Room target, int amount)
        {
            this.service.TransferAsset(assetDetail, target, amount);
        }

        #endregion
    }
}
