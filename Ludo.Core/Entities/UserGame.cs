using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo.Core.Entities
{
    public class UserGame
    {
        public int GameId { get; set; }
        public Game? Game { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
