using Ludo.Infra.Persistance;
using Ludo.Infra.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo.Application.Commands.DeleteGameCommand
{
    public class DeleteGameCommandHandler : IRequestHandler<DeleteGameCommand, Unit>
    {
        private GameRepository _gameRepository;
        public DeleteGameCommandHandler(GameRepository gameRepository) 
        {
            _gameRepository = gameRepository;
        }
        public async Task<Unit> Handle(DeleteGameCommand request, CancellationToken cancellationToken) 
        {
            var game = await _gameRepository.GetById(request.Id);

            await _gameRepository.Delete(game);

            return Unit.Value;

        }


    }
}
