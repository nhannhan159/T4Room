﻿using System;
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
    public class RoomCalendarStatus : EntityBase
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
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
    }
}
