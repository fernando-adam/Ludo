using Ludo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo.Application.VIewModels
{
    public class UserViewModel
    {
        public UserViewModel(string firstName, string lastName, string email, List<GameViewModel> userGames)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            UserGames = userGames;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<GameViewModel> UserGames { get;}
    }
}
