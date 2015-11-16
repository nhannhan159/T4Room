using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Validation;

using RoomM.Domain;
using RoomM.Domain.AssetModule.Aggregates;
using RoomM.Domain.RoomModule.Aggregates;

namespace RoomM.Application.AssetModule.Services
{
    public class AssetManagementService : IAssetManagementService 
    {
        private IUnitOfWork context;

        public AssetManagementService(IUnitOfWork context)
        {
            this.context = context;
        }

        public void EnableWSMode()
        {
            this.context.EnableWSMode();
        }

        #region Basic CRUD

        public IList<Asset> GetAssetList()
        {
            return this.context.AssetRep.GetAll();
        }

        public void AddAsset(Asset asset)
        {
            try
            {
                this.context.AssetRep.Edit(asset);
                this.context.Commit();
            }
            catch (DbEntityValidationException ex)
            {
                var error = ex.EntityValidationErrors.First().ValidationErrors.First();
                throw new ApplicationException(error.ErrorMessage);
            } 
        }

        public void EditAsset(Asset asset)
        {
            try
            {
                this.context.AssetRep.Edit(asset);
                this.context.Commit();
            }
            catch (DbEntityValidationException ex)
            {
                var error = ex.EntityValidationErrors.First().ValidationErrors.First();
                throw new ApplicationException(error.ErrorMessage);
            } 
        }

        public void DeleteAsset(Asset asset)
        {
            try
            {
                asset.IsUsing = false;
                this.context.AssetRep.Edit(asset);
                this.context.Commit();
            }
            catch (DbEntityValidationException ex)
            {
                var error = ex.EntityValidationErrors.First().ValidationErrors.First();
                throw new ApplicationException(error.ErrorMessage);
            }
        }

        #endregion

        #region Addition Lists

        public IList<Room> GetRoomList()
        {
            return this.context.RoomRep.GetAll();
        }

        public IList<RoomType> GetRoomTypeList()
        {
            return this.context.RoomTypeRep.GetAll();
        }

        public IList<AssetDetail> GetAssetDetailList()
        {
            return this.context.AssetDetailRep.GetAll();
        }

        public IList<AssetDetail> GetAssetDetailList(Int64 assetId)
        {
            return this.context.AssetDetailRep.GetByAssetId(assetId);
        }

        #endregion

        #region Addition Services

        public void ImportAsset(Int64 assetId, Int64 roomId, int amount)
        {
            try
            {
                this.context.AssetDetailRep.AddOrUpdate(assetId, roomId, amount);

                AssetHistory assetHistory = new AssetHistory(DateTime.Now, Contants.ASSETS_IMPORT, assetId, roomId, "", amount);
                this.context.AssetHistoryRep.Add(assetHistory);

                this.context.Commit();
            }
            catch (DbEntityValidationException ex)
            {
                var error = ex.EntityValidationErrors.First().ValidationErrors.First();
                throw new ApplicationException(error.ErrorMessage);
            } 
        }

        public void DropAsset(AssetDetail assetDetail, int amount)
        {
            try
            {
                int changedAmount = amount;
                if (assetDetail.Amount <= amount)
                {
                    changedAmount = assetDetail.Amount;
                    this.context.AssetDetailRep.Delete(assetDetail);
                }
                else
                {
                    assetDetail.Amount -= amount;
                    this.context.AssetDetailRep.Edit(assetDetail);
                }

                AssetHistory assetHistory = new AssetHistory(DateTime.Now, Contants.ASSETS_TRANSFER, assetDetail.AssetId, assetDetail.RoomId, "", changedAmount);
                this.context.AssetHistoryRep.Add(assetHistory);

                this.context.Commit();
            }
            catch (DbEntityValidationException ex)
            {
                var error = ex.EntityValidationErrors.First().ValidationErrors.First();
                throw new ApplicationException(error.ErrorMessage);
            }
        }

        public void TransferAsset(AssetDetail assetDetail, Room target, int amount)
        {
            try
            {
                Int64 assetDetail_AssetId = assetDetail.AssetId;
                Int64 assetDetail_RoomId = assetDetail.RoomId;
                string assetDetail_Roomname = assetDetail.Room.Name;

                int changedAmount = amount;
                if (assetDetail.Amount <= amount)
                {
                    changedAmount = assetDetail.Amount;
                    this.context.AssetDetailRep.AddOrUpdate(assetDetail.AssetId, target.ID, changedAmount);
                    this.context.AssetDetailRep.Delete(assetDetail);
                }
                else
                {
                    assetDetail.Amount -= changedAmount;
                    this.context.AssetDetailRep.Edit(assetDetail);
                    this.context.AssetDetailRep.AddOrUpdate(assetDetail.AssetId, target.ID, changedAmount);
                }

                AssetHistory assetHistory1 = new AssetHistory(DateTime.Now, Contants.ASSETS_TRANSFER, assetDetail_AssetId, assetDetail_RoomId, target.Name, changedAmount);
                AssetHistory assetHistory2 = new AssetHistory(DateTime.Now, Contants.ASSETS_RECEVIE, assetDetail_AssetId, target.ID, assetDetail_Roomname, changedAmount);
                this.context.AssetHistoryRep.Add(assetHistory1);
                this.context.AssetHistoryRep.Add(assetHistory2);

                this.context.Commit();
            }
            catch (DbEntityValidationException ex)
            {
                var error = ex.EntityValidationErrors.First().ValidationErrors.First();
                throw new ApplicationException(error.ErrorMessage);
            }
        }

        #endregion
    }
}
