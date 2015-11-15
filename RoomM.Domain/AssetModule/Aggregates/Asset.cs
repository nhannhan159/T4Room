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
    public class Asset : EntityBase
    {
        [DataMember]
        [StringLength(50)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        [DataMember]
        public Boolean IsUsing { get; set; }

        [DataMember]
        public string Description { get; set; }

        public virtual ICollection<AssetDetail> AssetDetails
        {
            get
            {
                if (this.assetDetails == null)
                    this.assetDetails = new List<AssetDetail>();
                return this.assetDetails;
            }
            set
            {
                this.assetDetails = new List<AssetDetail>(value);
            }
        }

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

        private IList<AssetDetail> assetDetails;
        private IList<AssetHistory> assetHistories;

        public string AllRoomName
        {
            get { return string.Join(",", this.AssetDetails.Select(p => p.Room.Name)); }
        }

        public int Amount
        {
            get { return this.AssetDetails.Sum(x => x.Amount); }
        }

        public Asset()
        {
            this.IsUsing = true;
        }

        public override string ToString()
        {
            return this.ID + " # " + this.Name;
        }
    }
}
