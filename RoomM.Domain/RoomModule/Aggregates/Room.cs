using RoomM.Domain.AssetModule.Aggregates;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;

namespace RoomM.Domain.RoomModule.Aggregates
{
    [DataContract(IsReference = true)]
    public class Room : EntityBase
    {
        [DataMember]
        [Required]
        [Display(Name = "Tên phòng")]
        [StringLength(120)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        [DataMember]
        [Display(Name = "Ngày tạo")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateCreate { get; set; }

        [DataMember]
        [Display(Name = "Loại phòng")]
        public Int64 RoomTypeId { get; set; }

        [DataMember]
        public virtual RoomType RoomType { get; set; }

        [DataMember]
        public Boolean IsUsing { get; set; }

        [DataMember]
        public string Description { get; set; }

        public virtual ICollection<RoomReg> RoomRegs
        {
            get
            {
                if (this.roomRegs == null)
                    this.roomRegs = new List<RoomReg>();
                return this.roomRegs;
            }
            set
            {
                this.roomRegs = new List<RoomReg>(value);
            }
        }

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

        private IList<RoomReg> roomRegs;
        private IList<AssetDetail> assetDetails;
        private IList<AssetHistory> assetHistories;

        public Boolean IsHaveRegistered
        {
            get { return this.RoomRegs.Count(p => p.RoomRegTypeId == 1) > 0; }
        }

        public string NotifyText
        {
            get { return this.IsHaveRegistered ? "!!!" : ""; }
        }

        public string NotifyToolTip
        {
            get { return this.IsHaveRegistered ? "Đang có người đăng ký cần xác nhận" : ""; }
        }

        public Room()
        {
            this.IsUsing = true;
            this.DateCreate = DateTime.Now.Date;
        }

        public override string ToString()
        {
            return this.Id + "#" + this.Name + "#RoomType:" + this.RoomTypeId + "#Status: " + this.IsUsing;
        }
    }
}