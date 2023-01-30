using Ludo.Core.Entities;
using Ludo.Core.Interfaces;
using Ludo.Infra.Persistance;
using Ludo.Infra.Persistence.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo.Application.Commands.CreateGameCommand
{
    public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand, int>
    {
        private readonly IGameRepository _gameRepository;
        public CreateGameCommandHandler(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }
        public async Task<int> Handle(CreateGameCommand request, CancellationToken cancellationToken)
        {
            var game = new Game(
                    request.Title,
                    request.Description,
                    request.Category,
                    request.Publisher,
                    request.Language,
                    request.MinimumNumberOfPlayers,
                    request.MaximumNumberOfPlayers,
                    request.Age);
            await _gameRepository.AddAsync(game);

            return game.GameId;
        }
    }
}
