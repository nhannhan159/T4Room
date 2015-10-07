using RoomM.Repositories.RepositoryFramework;
using RoomM.Models.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Repositories.Assets
{
    public interface IAssetRepository : IRepository<Asset>
    {
        Asset GetSingle(int deviceId);
        IList<String> GetNameList();
        bool isUniqueName(string name);
    }
}
