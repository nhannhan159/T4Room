using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace RoomM.Models
{
    [DataContract]
    public class Room : EntityBase
    {
        [DataMember]
        [Required]
        [Display(Name = "Tên phòng")]
        [StringLength(120)]
        public string Name { get; set; }

        [DataMember]
        [Display(Name = "Ngày tạo")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateCreate { get; set; }

        [DataMember]
        [Display(Name = "Loại phòng")]
        public Int64 RoomTypeId { get; set; }

        public virtual RoomType RoomType { get; set; }

        [DataMember]
        public Boolean IsUsing { get; set; }

        public Boolean IsHaveRegistered
        {
            get
            {
                var query = from p in RoomCalendars
                            where p.RoomCalendarStatusId == 1
                            select p;
                return query.Count() > 0;
            }
           
        }

        public string NotifyText
        {
            get { return "xxx"; return this.IsHaveRegistered ? "!!!" : ""; }
        }

        public string NotifyToolTip
        {
            get { return "aaa"; return this.IsHaveRegistered ? "Đang có người đăng ký cần xác nhận" : ""; }
        }

        [DataMember]
        public string Description { get; set; }

        public virtual ICollection<RoomAsset> RoomAssets { get; set; }
        public virtual ICollection<RoomAssetHistory> AssetHistories { get; set; }
        public virtual ICollection<RoomCalendar> RoomCalendars { get; set; }

        public Room()
        {
            this.IsUsing = true;
            this.DateCreate = DateTime.Now.Date;
            this.RoomAssets = new List<RoomAsset>();
            this.AssetHistories = new List<RoomAssetHistory>();
            this.RoomCalendars = new List<RoomCalendar>();
        }

        public override string ToString()
        {
            return ID + "#" + Name + "#RoomType:" + RoomTypeId + "#Status: " + IsUsing;
        }
    }
}
