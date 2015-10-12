using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Models
{
    public class Room : EntityBase
    {
        [Required]
        [Display(Name = "Tên phòng")]
        [StringLength(120)]
        public string Name { get; set; }

        [Display(Name = "Ngày tạo")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateCreate { get; set; }

        [Display(Name = "Loại phòng")]
        public Int64 RoomTypeId { get; set; }

        public virtual RoomType RoomType { get; set; }

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
            get { return this.IsHaveRegistered ? "!!!" : ""; }
        }

        public string NotifyToolTip
        {
            get { return this.IsHaveRegistered ? "Đang có người đăng ký cần xác nhận" : ""; }
        }

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

        public Room GetDetached()
        {
            Room detached = new Room();
            detached.ID = this.ID;
            detached.Name = this.Name;
            detached.DateCreate = this.DateCreate;
            detached.RoomTypeId = this.RoomTypeId;
            detached.Description = this.Description;
            detached.IsUsing = this.IsUsing;
            //detached.IsHaveRegistered = this.IsHaveRegistered;
            detached.RoomType = this.RoomType.GetDetached();
            return detached;
        }

    }
}
