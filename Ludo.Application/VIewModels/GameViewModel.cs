using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo.Application.VIewModels
{
    public class GameViewModel
    {
        public GameViewModel() { }
        public GameViewModel(int id, string title, string description, string category, string publisher, string language, int minimumNumberOfPlayers,int maximumNumberOfPlayers, int minimumAge)
        {
            Id = id;
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Category = category;
            Publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
            Language = language ?? throw new ArgumentNullException(nameof(language));
            MinimumNumberOfPlayers = minimumNumberOfPlayers;
            MaximumNumberOfPlayers = maximumNumberOfPlayers;
            MinimumAge = minimumAge;
        }

        public int Id { get; set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Category { get; private set; }
        public string Publisher { get; private set; }
        public string Language { get; private set; }
        public int MinimumNumberOfPlayers { get; private set; }
        public int MaximumNumberOfPlayers { get; private set; }
        public int MinimumAge { get; private set; }
        public DateTime CreatedAt { get; private set; }

    }
}
