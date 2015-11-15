using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Domain.AssetModule.Aggregates
{
    public interface IAssetRepository : IRepository<Asset>
    {
        bool isUniqueName(string name);
    }
}
