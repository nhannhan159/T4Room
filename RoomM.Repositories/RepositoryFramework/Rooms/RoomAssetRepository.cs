using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

using RoomM.Models;

namespace RoomM.Repositories
{
    public class RoomAssetRepository : RepositoryBase<RoomAsset>, IRoomAssetRepository
    {
        public RoomAssetRepository(EFDataContext context)
            : base(context)
        { }

        protected override string IncludeProperties()
        {
            return "Room,Asset";
        }

        public void AddOrUpdate(Int64 assetId, Int64 roomId, int amount)
        {
            var query = this.Get(filter: p => p.RoomId == roomId && p.AssetId == assetId);
            RoomAsset entity;
            if (query.Count() > 0)
            {
                entity = query.First();
                entity.Amount += amount;
                this.Edit(entity);
            }
            else
            {
                entity = new RoomAsset(assetId, roomId, amount);
                this.Add(entity);
            }
        }

        public IList<RoomAsset> GetByRoomId(Int64 id)
        {
            return this.Get(filter: p => p.RoomId == id).ToList();
        }

        public IList<RoomAsset> GetByAssetId(Int64 id)
        {
            return this.Get(filter: p => p.AssetId == id).ToList();
        }
    }
}
