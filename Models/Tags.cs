using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHaven.Models
{
    public partial class Tags
    {
        public Tags()
        {
            GameTags = new HashSet<GameTags>();
        }

        public int TagId { get; set; }
        public string TagName { get; set; }

        public virtual ICollection<GameTags> GameTags { get; set; }
    }
}
