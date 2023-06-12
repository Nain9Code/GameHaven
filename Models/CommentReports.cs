using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace GameHaven.Models
{
    public partial class CommentReports
    {
        public int ReportId { get; set; }
        public int? UserId { get; set; }
        public int? CommentId { get; set; }
        public string ReportComments { get; set; }

        public virtual Comments Comment { get; set; }
        public virtual Users User { get; set; }
    }
}
