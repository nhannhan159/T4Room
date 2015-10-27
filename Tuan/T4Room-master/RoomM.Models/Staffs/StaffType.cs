using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Models
{
    public class StaffType : Detachable<StaffType>
    {
        public string Name { get; set; }
        public virtual ICollection<Staff> Staffs { get; set; }

        public override StaffType GetDetached()
        {
            StaffType detached = new StaffType();
            detached.ID = this.ID;
            detached.Name = this.Name;
            return detached;
        }
    }
}
