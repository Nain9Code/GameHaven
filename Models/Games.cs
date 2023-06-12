using System;
using System.Collections.Generic;

namespace GameHaven.Models
{
    public partial class Games
    {
        public Games()
        {
            Comments = new HashSet<Comments>();
            GameReports = new HashSet<GameReports>();
            Ratings = new HashSet<Ratings>();
        }

        public int GameId { get; set; }
        public string FreeGameName { get; set; }
        public string GameDescription { get; set; }
        public string GameImagePath { get; set; }
        public string GameFileUrl { get; set; } // new property
        public int CategoryId { get; set; } // new property

        public virtual Categories Category { get; set; } // new navigation property
        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<GameReports> GameReports { get; set; }
        public virtual ICollection<Ratings> Ratings { get; set; }
        public virtual ICollection<GameTags> GameTags { get; set; }
        public virtual ICollection<GameScreenshots> GameScreenshots { get; set; }
    }
}
