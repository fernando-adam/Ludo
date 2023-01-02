namespace Ludo.Core.Entities
{
    public class Game : BaseEntity
    {
        public Game(string title, string description, string category, string publisher, string language, string numberOfPlayers, int age)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Category = category;
            Publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
            Language = language ?? throw new ArgumentNullException(nameof(language));
            NumberOfPlayers = numberOfPlayers;
            Age = age;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Category { get; private set; }
        public string Publisher { get; private set; }
        public string Language { get; private set; }
        public string NumberOfPlayers { get; private set; }
        public int Age { get; private set; }
        public DateTime CreatedAt { get; private set; }


        public void Update(string title, string description)
        {
            Title = title;
            Description = description;
        }
    
    }

    
}
