using System;
using System.Collections.Generic;

namespace RoomM.Domain.AssetModule.Aggregates
{
    public interface IAssetDetailRepository : IRepository<AssetDetail>
    {
        IList<AssetDetail> GetByRoomId(Int64 id);

        IList<AssetDetail> GetByAssetId(Int64 id);

        string GetAllRoomName(Int64 assetId);

        void AddOrUpdate(Int64 roomId, Int64 assetId, int amount);
    }
}