using RoomM.Repositories.RepositoryFramework;
using RoomM.Models.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Repositories.Rooms
{
    public interface IRoomAssetRepository : IRepository<RoomAsset>
    {
        RoomAsset GetSingle(Int64 roomDeviceId);
        IList<RoomAsset> GetByRoomId(Int64 id);
        IList<RoomAsset> GetByAssetId(Int64 id);
        void AddOrUpdate(Int64 roomId, Int64 assetId, int amount);
    }
}
