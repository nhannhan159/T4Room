using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

using RoomM.Domain.AssetModule.Aggregates;
using RoomM.Infrastructure.Data.UnitOfWork;

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
