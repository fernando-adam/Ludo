using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo.Core.Entities
{
    public class User
    {

        public User(string firstName, string lastName, string email,string password, string role, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            BirthDate = birthDate;
            Role = role;

            Active = true;
            CreatedAt = DateTime.Now;

            UserGames = new List<UserGame>();


        }

        public int UserId { get; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }
        public bool Active { get; private set; }
        public DateTime BirthDate { get; private set; }
        public DateTime CreatedAt { get; private set; }

        /* EF Relations */
        public List<UserGame> UserGames { get; private set; }
    }
}
