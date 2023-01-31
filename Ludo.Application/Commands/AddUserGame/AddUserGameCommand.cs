using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo.Application.Commands.AddUserGame
{
    public class AddUserGameCommand : IRequest<Unit>
    {
        public int UserId { get; set; }
        public int[]? GameIds { get; set; }
    }
}
