using Ludo.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo.Application.Commands.AddUserGame
{
    public class AddUserGameCommandHandler : IRequestHandler<AddUserGameCommand>
    {
        private readonly IUserRepository _userRepository;
        public AddUserGameCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(AddUserGameCommand command, CancellationToken cancellationToken)
        {
            await _userRepository.AddGamesAsync(command.UserId, command.GameIds);
            return Unit.Value;
        }
    }
}
