using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using RoomM.Repositories.RepositoryFramework;
using RoomM.Repositories;
using RoomM.Models;

namespace RoomM.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class AssetService : ServiceBase<Asset>, IAssetService
    {
        private IAssetRepository assetRepository;

        public AssetService()
        {
            this.assetRepository = RepositoryFactory.GetRepository<IAssetRepository, Asset>();
            this.repo = (IRepository<Asset>)this.assetRepository;
        }

        public Asset GetSingle(int assetId)
        {
            return this.assetRepository.GetSingle(assetId).GetDetached();
        }

        public IList<string> GetNameList()
        {
            return this.assetRepository.GetNameList();
        }

        public bool isUniqueName(string name)
        {
            return this.assetRepository.isUniqueName(name);
        }
    }
}
