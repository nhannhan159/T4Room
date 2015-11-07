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
    [DataContract(IsReference = true)]
    public class RoomCalendar : EntityBase
    {
        [DataMember]
        [DataType(DataType.Date)]
        [Display(Name = "Ngày đăng kí")]
        public DateTime Date { get; set; }

        [DataMember]
        [Display(Name = "Tiết bắt đầu")]
        public int Start { get; set; }

        [DataMember]
        [Display(Name = "Số tiết")]
        public int Length { get; set; }

        [DataMember]
        [Display(Name = "Mã phòng")]
        public Int64 RoomId { get; set; }

        [DataMember]
        public virtual Room Room { get; set; }

        [DataMember]
        public Int64 StaffId { get; set; }

        [DataMember]
        public virtual Staff Staff { get; set; }

        [DataMember]
        public Int64 RoomCalendarStatusId { get; set; }

        [DataMember]
        [Display(Name = "Trạng thái đăng kí")]
        public virtual RoomCalendarStatus RoomCalendarStatus { get; set; }

        [DataMember]
        public bool IsWatched { get; set; }

        public override string ToString()
        {
            return this.ID + " #room " + this.RoomId + " #user " + this.StaffId + " #start " + this.Start + " #len " + this.Length;
        }
    }
}
