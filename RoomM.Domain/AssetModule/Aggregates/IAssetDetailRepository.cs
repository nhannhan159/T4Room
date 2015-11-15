using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Domain.AssetModule.Aggregates
{
    public interface IAssetDetailRepository : IRepository<AssetDetail>
    {
        IList<AssetDetail> GetByRoomId(Int64 id);
        IList<AssetDetail> GetByAssetId(Int64 id);
        void AddOrUpdate(Int64 roomId, Int64 assetId, int amount);
    }
}
