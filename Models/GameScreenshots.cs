using System;

namespace GameHaven.Models
{
    public partial class GameScreenshots
    {
        public int ScreenshotId { get; set; }
        public int? GameId { get; set; }
        public string ScreenshotImagePath { get; set; }

        public virtual Games Game { get; set; }
    }
}
