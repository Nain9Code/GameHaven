using System;
using System.Collections.Generic;

namespace GameHaven.Models
{
    public partial class Comments
    {
        public Comments()
        {
            CommentReports = new HashSet<CommentReports>();
        }

        public int CommentId { get; set; }
        public int GameId { get; set; }
        public int UserId { get; set; }
        public string CommentText { get; set; }

        public virtual Games Game { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<CommentReports> CommentReports { get; set; }
    }
}
