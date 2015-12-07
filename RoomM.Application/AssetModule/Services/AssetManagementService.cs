using RoomM.Domain.AssetModule.Aggregates;
using RoomM.Domain.RoomModule.Aggregates;
using RoomM.Infrastructure.Data.UnitOfWork;
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
                this.context.AssetRep.Add(asset);
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

        #endregion Basic CRUD

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

        public IList<AssetDetail> GetAssetDetailListByAssetId(Int64 assetId)
        {
            return this.context.AssetDetailRep.GetByAssetId(assetId);
        }

        public IList<AssetDetail> GetAssetDetailListByRoomId(Int64 roomId)
        {
            return this.context.AssetDetailRep.GetByRoomId(roomId);
        }

        public IList<AssetHistory> GetAssetHisListByRoomId(Int64 roomId)
        {
            return this.context.AssetHistoryRep.GetByRoomId(roomId);
        }

        public IList<AssetHistory> GetAssetHisListByBacktrace(Room room, DateTime timeForBacktrace)
        {
            return this.context.AssetHistoryRep.GetByRoom2RoomId(room, timeForBacktrace);
        }

        public string GetAssetAllRoomName(Int64 assetId)
        {
            return this.context.AssetDetailRep.GetAllRoomName(assetId);
        }

        #endregion Addition Lists

        #region Addition Services

        public void ImportAsset(Int64 assetId, Int64 roomId, int amount)
        {
            try
            {
                this.context.AssetDetailRep.AddOrUpdate(assetId, roomId, amount);

                Asset asset = this.context.AssetRep.GetSingle(assetId);
                asset.Amount += amount;
                this.context.AssetRep.Edit(asset);

                AssetHistory assetHistory = new AssetHistory(DateTime.Now, AssetHistory.ASSETS_IMPORT, assetId, roomId, "", amount);
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
                    assetDetail.Amount -= changedAmount;
                    this.context.AssetDetailRep.Edit(assetDetail);
                }

                Asset asset = this.context.AssetRep.GetSingle(assetDetail.AssetId);
                asset.Amount -= changedAmount;
                this.context.AssetRep.Edit(asset);

                AssetHistory assetHistory = new AssetHistory(DateTime.Now, AssetHistory.ASSETS_TRANSFER, assetDetail.AssetId, assetDetail.RoomId, "", changedAmount);
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
                    this.context.AssetDetailRep.AddOrUpdate(assetDetail.AssetId, target.Id, changedAmount);
                    this.context.AssetDetailRep.Delete(assetDetail);
                }
                else
                {
                    assetDetail.Amount -= changedAmount;
                    this.context.AssetDetailRep.Edit(assetDetail);
                    this.context.AssetDetailRep.AddOrUpdate(assetDetail.AssetId, target.Id, changedAmount);
                }

                AssetHistory assetHistory1 = new AssetHistory(DateTime.Now, AssetHistory.ASSETS_TRANSFER, assetDetail_AssetId, assetDetail_RoomId, target.Name, changedAmount);
                AssetHistory assetHistory2 = new AssetHistory(DateTime.Now, AssetHistory.ASSETS_RECEVIE, assetDetail_AssetId, target.Id, assetDetail_Roomname, changedAmount);
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

        #endregion Addition Services
    }
}