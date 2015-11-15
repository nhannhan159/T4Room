using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using RoomM.Domain.AssetModule.Aggregates;
using RoomM.Domain.RoomModule.Aggregates;
using RoomM.Domain.UserModule.Aggregates;

namespace RoomM.Domain
{
    public interface IUnitOfWork
    {
        void Commit();
        void EnableWSMode();

        IRoomRepository RoomRep { get; }
        IRepository<RoomType> RoomTypeRep { get; }
        IRoomRegRepository RoomRegRep { get; }
        IRepository<RoomRegType> RoomRegTypeRep { get; }

        IAssetRepository AssetRep { get; }
        IAssetDetailRepository AssetDetailRep { get; }
        IAssetHistoryRepository AssetHistoryRep { get; }
        IRepository<AssetHistoryType> AssetHistoryTypeRep { get; }

        IUserRepository UserRep { get; }
        IRepository<UserRole> UserRoleRep { get; }
    }
}
