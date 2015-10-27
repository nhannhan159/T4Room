using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RoomM.Repositories.RepositoryFramework;
using RoomM.Models;

namespace RoomM.Repositories
{
    public interface IAssetRepository : IRepository<Asset>
    {
        Asset GetSingle(int deviceId);
        IList<String> GetNameList();
        bool isUniqueName(string name);
    }
}
