using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Models.Devices
{
    public class DeviceHistoryType : EntityBase
    {
        public string Name { get; set; }
        public virtual ICollection<DeviceHistory> DeviceHistorys { get; set; }
    }
}
