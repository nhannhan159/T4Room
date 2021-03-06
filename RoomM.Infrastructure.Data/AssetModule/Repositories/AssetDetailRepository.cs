﻿using RoomM.Domain.AssetModule.Aggregates;
using RoomM.Infrastructure.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RoomM.Infrastructure.Data.AssetModule.Repositories
{
    public class AssetDetailRepository : Repository<AssetDetail>, IAssetDetailRepository
    {
        public AssetDetailRepository(EFContext context)
            : base(context)
        { }

        protected override string IncludeProperties()
        {
            return "Room,Asset";
        }

        public void AddOrUpdate(Int64 assetId, Int64 roomId, int amount)
        {
            var query = this.Get(filter: p => p.RoomId == roomId && p.AssetId == assetId);
            AssetDetail entity;
            if (query.Count() > 0)
            {
                entity = query.First();
                entity.Amount += amount;
                this.Edit(entity);
            }
            else
            {
                entity = new AssetDetail(assetId, roomId, amount);
                this.Add(entity);
            }
        }

        public IList<AssetDetail> GetByRoomId(Int64 id)
        {
            return this.Get(filter: p => p.RoomId == id).ToList();
        }

        public IList<AssetDetail> GetByAssetId(Int64 id)
        {
            return this.Get(filter: p => p.AssetId == id).ToList();
        }

        public string GetAllRoomName(Int64 assetId)
        {
            IList<AssetDetail> assetDetails = this.GetByAssetId(assetId);
            return string.Join(",", assetDetails.Select(p => p.Room.Name));
        }
    }
}