namespace Ludo.Core.Entities
{
    public class AdvertisementGame
    {
        public int GameId { get; set; }
        public Game Game { get; set; }
        public int AdvertisementId { get; set; }
        public Advertisement Advertisement { get; set; }
    }
}
