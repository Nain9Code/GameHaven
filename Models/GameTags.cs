namespace GameHaven.Models
{
    public partial class GameTags
    {
        public int GameId { get; set; }
        public int TagId { get; set; }

        public virtual Games Game { get; set; }
        public virtual Tags Tag { get; set; }
    }
}
