using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Models.Users
{
    public class UserType : EntityBase
    {
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
