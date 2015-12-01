using RoomM.Domain.AssetModule.Aggregates;
using RoomM.Infrastructure.Data.UnitOfWork;
using System.Linq;

namespace RoomM.Infrastructure.Data.AssetModule.Repositories
{
    public class AssetRepository : Repository<Asset>, IAssetRepository
    {
        public AssetRepository(EFContext context)
            : base(context)
        { }

        public bool isUniqueName(string name)
        {
            return this.Get(filter: p => p.Name.Equals(name)).Count() == 0;
        }
    }
}