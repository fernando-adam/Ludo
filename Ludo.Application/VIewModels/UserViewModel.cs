namespace Ludo.Application.VIewModels
{
    public class UserViewModel
    {
        public UserViewModel(int id,string firstName, string lastName, string email, List<GameViewModel>? userGames)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            UserGames = userGames;
        }

        public UserViewModel(int id, string firstName, string lastName, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<GameViewModel>? UserGames { get;}
    }
}
