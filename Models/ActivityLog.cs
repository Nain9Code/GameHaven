using System;
using System.Collections.Generic;

namespace GameHaven.Models
{
    public partial class ActivityLog
    {
        public int LogId { get; set; }
        public int UserId { get; set; }
        public DateTime? ActionTime { get; set; }
        public string ActionType { get; set; }
        public string ActionDetails { get; set; }

        public virtual Users User { get; set; }
    }
}
