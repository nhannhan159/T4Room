using RoomM.Models;
using RoomM.Repositories.RepositoryFramework;
using RoomM.Models.Assets;
using RoomM.Repositories.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Repositories.Assets
{
    public class AssetRepository : RepositoryBase<EFDataContext, Asset>, IAssetRepository
    {
        public AssetRepository()
        { 
        
        }

        public Asset GetSingle(int assetId)
        {
            var query = GetAllWithQuery().SingleOrDefault(x => x.ID == assetId);
            return query;
        }


        public IList<string> GetNameList()
        {
            return (from p in GetAllWithQuery()
                    select p.Name).ToList();
        }

        public bool isUniqueName(string name)
        {
            return (from p in GetAllWithQuery()
                    where p.Name.Equals(name)
                    select p).ToList().Count == 0;

        }
    }
}
