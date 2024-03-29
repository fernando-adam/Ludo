﻿using Ludo.Application.VIewModels;
using Ludo.Core.Interfaces;
using MediatR;

namespace Ludo.Application.Queries.GetAllGames
{
    public class GetAllGamesQueryHandler : IRequestHandler<GetAllGamesQuery, List<GameViewModel>>
    {
        private readonly IGameRepository _gameRepository;

        public GetAllGamesQueryHandler(IGameRepository gameRepository)
        {
            _gameRepository= gameRepository;
        }

        public async Task<List<GameViewModel>> Handle(GetAllGamesQuery request, CancellationToken cancellationToken)
        {
            var games = await _gameRepository.GetAllAsync();

            var gamesViewModel = games
                                .Select(p => new GameViewModel(p.GameId, p.Title, p.Description, p.Category,
                                                               p.Publisher, p.Language, p.MinimumNumberOfPlayers,
                                                               p.MaximumNumberOfPlayers, p.MinimumAge)).ToList();

            return gamesViewModel;
        }
    }
}
