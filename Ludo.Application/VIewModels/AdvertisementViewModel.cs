namespace Ludo.Application.VIewModels
{
    public class AdvertisementViewModel
    {
        public AdvertisementViewModel(int id, string? title, string? description, decimal totalPrice, List<GameViewModel>? games, int userId)
        {
            Id = id;
            Title = title;
            Description = description;
            TotalPrice = totalPrice;
            Games = games;
            UserId = userId;
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public decimal TotalPrice { get; set; }
        public int UserId { get; set; }
        public List <GameViewModel>? Games { get; set; }
    }
}
