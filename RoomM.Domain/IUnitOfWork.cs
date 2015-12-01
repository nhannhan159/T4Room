using RoomM.Domain.AssetModule.Aggregates;
using RoomM.Domain.RoomModule.Aggregates;
using RoomM.Domain.UserModule.Aggregates;
using System;

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
        IUserClaimRepository UserClaimRep { get; }
        IUserLoginRepository UserLoginRep { get; }
        IRoleRepository RoleRep { get; }
    }
}