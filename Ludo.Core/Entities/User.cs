using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo.Core.Entities
{
    public class User : BaseEntity
    {

        public User(string firstName, string lastName, string email,string password, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            BirthDate = birthDate;

            Active = true;
            CreatedAt = DateTime.Now;
            OwnedGames = new List<Game>();
        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public bool Active { get; private set; }
        public DateTime BirthDate { get; private set; }
        public DateTime CreatedAt { get; private set; }
        
        public List<Game>OwnedGames { get; private set; }
    }
}
