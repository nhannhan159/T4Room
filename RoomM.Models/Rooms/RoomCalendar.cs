using RoomM.Models.Staffs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Models.Rooms
{
    public class RoomCalendar : EntityBase
    {
        [DataType(DataType.Date)]
        [Display(Name = "Ngày đăng kí")]
        public DateTime Date { get; set; }

        [Display(Name = "Tiết bắt đầu")]
        public int Start { get; set; }

        [Display(Name = "Số tiết")]
        public int Length { get; set; }

        [Display(Name = "Mã phòng")]
        public Int64 RoomId { get; set; }
        public virtual Room Room { get; set; }

        public Int64 StaffId { get; set; }
        public virtual Staff Staff { get; set; }

        public Int64 RoomCalendarStatusId { get; set; }

        [Display(Name = "Trạng thái đăng kí")]
        public virtual RoomCalendarStatus RoomCalendarStatus { get; set; }

        public bool IsWatched { get; set; }

        public override string ToString()
        {
            return ID + " #room " + RoomId + " #user " + StaffId + " #start " + Start + " #len " + Length;
        }

        public RoomCalendar GetDetached()
        {
            RoomCalendar detached = new RoomCalendar();
            detached.ID = this.ID;
            detached.Date = this.Date;
            detached.Start = this.Start;
            detached.Length = this.Length;
            detached.RoomId = this.RoomId;
            detached.Room = this.Room.GetDetached();
            detached.StaffId = this.StaffId;
            detached.Staff = this.Staff.GetDetached();
            detached.RoomCalendarStatusId = this.RoomCalendarStatusId;
            detached.RoomCalendarStatus = this.RoomCalendarStatus.GetDetached();
            detached.IsWatched = this.IsWatched;
            return detached;
        }
    }
}
