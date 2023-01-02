using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ludo.Application.Commands.CreateGameCommand
{
    public class CreateGameCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Publisher { get; set; }
        public string Language { get; set; }
        public string NumberOfPlayers { get; set; }
        public int Age { get; set; }

    }
}
