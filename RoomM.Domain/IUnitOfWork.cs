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
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void EnableWSMode();

        IRoomRepository RoomRep { get; }
        IRepository<RoomType> RoomTypeRep { get; }
        IRoomRegRepository RoomRegRep { get; }

        IAssetRepository AssetRep { get; }
        IAssetDetailRepository AssetDetailRep { get; }
        IAssetHistoryRepository AssetHistoryRep { get; }

        IUserRepository UserRep { get; }
        IRoleRepository RoleRep { get; }
    }
}
