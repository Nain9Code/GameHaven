using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHaven.Models
{
    public partial class Ratings
    {
        public int RatingId { get; set; }
        public int GameId { get; set; }
        public int UserId { get; set; }
        public int? RatingValue { get; set; }

        public virtual Games Game { get; set; }
        public virtual Users User { get; set; }
    }
}
