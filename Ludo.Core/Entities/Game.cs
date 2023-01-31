namespace Ludo.Core.Entities
{
    public class Game
    {
        public Game(string title, string description, string category, string publisher, string language, int minimumNumberOfPlayers, int maximumNumberOfPlayers,int minimumAge)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Category = category;
            Publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
            Language = language ?? throw new ArgumentNullException(nameof(language));
            MinimumNumberOfPlayers = minimumNumberOfPlayers;
            MaximumNumberOfPlayers = maximumNumberOfPlayers;
            MinimumAge = minimumAge;

            UserGames = new List<UserGame> { };
        }

        public int GameId { get; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Category { get; private set; }
        public string Publisher { get; private set; }
        public string Language { get; private set; }
        public int MinimumNumberOfPlayers { get; private set; }
        public int MaximumNumberOfPlayers { get; private set; }
        public int MinimumAge { get; private set; }
        public DateTime CreatedAt { get; private set; }

        /* EF Relations */
        public List<UserGame> UserGames { get; private set; }


        public void Update(string title, string description)
        {
            Title = title;
            Description = description;
        }
    
    }

    
}
