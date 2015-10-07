using RoomM.Models;
using RoomM.Repositories.RepositoryFramework;
using RoomM.Models.Rooms;
using RoomM.Repositories.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Repositories.Rooms
{
    public class RoomAssetRepository : RepositoryBase<EFDataContext, RoomAsset>, IRoomAssetRepository
    {
        public RoomAssetRepository()
        { 

        }

        public RoomAsset GetSingle(Int64 roomDeviceId)
        {
            var query = GetAllWithQuery().SingleOrDefault(x => x.ID == roomDeviceId);
            return query;
        }

        public void AddOrUpdate(Int64 assetId, Int64 roomId, int amount)
        {
            var query = from p in GetAllWithQuery()
                        where p.RoomId == roomId && p.AssetId == assetId
                        select p;
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
            return (from p in GetAllWithQuery()
                    where p.Room.ID == id
                    select p).ToList();
        }

        public IList<RoomAsset> GetByAssetId(Int64 id)
        {
            return (from p in GetAllWithQuery()
                    where p.Asset.ID == id
                    select p).ToList();
        }
    }
}
