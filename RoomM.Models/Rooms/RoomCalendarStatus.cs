using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Models
{
    public class RoomCalendarStatus : EntityBase
    {
        public string Name { get; set; }
        public virtual ICollection<RoomCalendar> RoomCalendars { get; set; }

        public RoomCalendarStatus()
        {
            this.RoomCalendars = new List<RoomCalendar>();
        }

        public RoomCalendarStatus(string name)
        {
            this.Name = name;
            this.RoomCalendars = new List<RoomCalendar>();
        }

        public RoomCalendarStatus GetDetached()
        {
            RoomCalendarStatus detached = new RoomCalendarStatus();
            detached.ID = this.ID;
            detached.Name = this.Name;
            return detached;
        }
    }
}
