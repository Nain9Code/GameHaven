using System;
using System.Collections.Generic;

namespace GameHaven.Models
{
    public partial class GameReports
    {
        public int ReportId { get; set; }
        public int UserId { get; set; }
        public int GameId { get; set; }
        public string ReportComments { get; set; }

        public virtual Games Game { get; set; }
        public virtual Users User { get; set; }
    }
}
