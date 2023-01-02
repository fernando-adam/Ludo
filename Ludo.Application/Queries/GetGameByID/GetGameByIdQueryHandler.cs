using Dapper;
using Ludo.Application.VIewModels;
using Ludo.Core.Interfaces;
using Ludo.Infra.Persistance;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo.Application.Queries.GetGameByID
{
    public class GetGameByIdQueryHandler : IRequestHandler<GetGameByIdQuery, GameViewModel>
    {
        private readonly IGameRepository _gameRepository;
        public GetGameByIdQueryHandler(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }
        public async Task<GameViewModel> Handle(GetGameByIdQuery request, CancellationToken cancellationToken)
        {
            var game = await _gameRepository.GetById(request.Id);

            if (game == null) return null;

            var gameViewModel = new GameViewModel(
                game.Id,
                game.Title,
                game.Description,
                game.Category,
                game.Publisher,
                game.Language,
                game.NumberOfPlayers,
                game.Age
                );

            return gameViewModel;


        }

    }
}
