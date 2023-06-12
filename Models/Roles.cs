using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GameHaven.Models
{
    public partial class Roles
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<Users> Users { get; set; }

        public Roles()
        {
            Users = new HashSet<Users>();
        }
    }
}

