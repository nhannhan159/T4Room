using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace RoomM.Domain.AssetModule.Aggregates
{
    [DataContract(IsReference = true)]
    public class AssetHistoryType : EntityBase
    {
        [DataMember]
        [StringLength(50)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<AssetHistory> AssetHistories
        {
            get
            {
                if (this.assetHistories == null)
                    this.assetHistories = new List<AssetHistory>();
                return this.assetHistories;
            }
            set
            {
                this.assetHistories = new List<AssetHistory>(value);
            }
        }

        private IList<AssetHistory> assetHistories;

        public AssetHistoryType() { }

        public AssetHistoryType(string name)
        {
            this.Name = name;
        }
    }
}
