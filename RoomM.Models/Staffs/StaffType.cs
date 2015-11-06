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
    public class StaffType : EntityBase
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public virtual ICollection<Staff> Staffs { get; set; }
    }
}
