using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using RoomM.Repositories;
using RoomM.Models;

namespace RoomM.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class AssetService : ServiceBase<Asset>, IAssetService
    {
        public AssetService(EFDataContext context)
            : base(context)
        {
            this.repo = (IRepository<Asset>)this.uow.AssetRepository;
        }

        public Asset GetSingle(int assetId)
        {
            return this.uow.AssetRepository.GetSingle(assetId);
        }

        public IList<string> GetNameList()
        {
            return this.uow.AssetRepository.GetNameList();
        }

        public bool isUniqueName(string name)
        {
            return this.uow.AssetRepository.isUniqueName(name);
        }
    }
}
