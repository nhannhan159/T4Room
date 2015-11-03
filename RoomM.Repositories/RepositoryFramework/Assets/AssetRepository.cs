using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RoomM.Models;

namespace RoomM.Repositories
{
    public class AssetRepository : RepositoryBase<Asset>, IAssetRepository
    {
        public AssetRepository(EFDataContext context)
            : base(context)
        { }

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
