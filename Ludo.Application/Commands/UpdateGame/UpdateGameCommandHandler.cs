using Ludo.Core.Interfaces;
using Ludo.Infra.Persistance;
using Ludo.Infra.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace Ludo.Application.Commands.UpdateGameCommand
{
    public class UpdateGameCommandHandler : IRequestHandler<UpdateGameCommand, Unit>
    {
        private readonly IGameRepository _gameRepository;
        public UpdateGameCommandHandler(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }
        public async Task<Unit> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
        {
            var game = await _gameRepository.GetById(request.Id);

            if (game == null) { }

            game.Update(request.Title, request.Description);

            await _gameRepository.SaveChangesAsync();

            return Unit.Value;

        }
    }
}
