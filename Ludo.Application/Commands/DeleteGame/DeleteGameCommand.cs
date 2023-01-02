using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo.Application.Commands.DeleteGameCommand
{
    public class DeleteGameCommand: IRequest<Unit>
    {
        public DeleteGameCommand(int id) 
        {
            Id = id;
        }
        public int Id { get; private set; }
    }
}
