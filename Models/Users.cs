using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GameHaven.Models
{
    public partial class Users
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? RoleId { get; set; }
        public bool? IsBanned { get; set; }

        public string ProfileImagePath { get; set; }
        public virtual Roles Role { get; set; }

        public virtual ICollection<Ratings> Ratings { get; set; }
        public virtual ICollection<GameReports> GameReports { get; set; }

        public virtual ICollection<Comments> Comments { get; set; }

        public virtual ICollection<ActivityLog> ActivityLog { get; set; }

        public virtual ICollection<CommentReports> CommentReports { get; set; }
    }
}
