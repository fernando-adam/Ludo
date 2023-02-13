using Ludo.Application.VIewModels;
using Ludo.Core.Interfaces;
using MediatR;

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
                game.GameId,
                game.Title,
                game.Description,
                game.Category,
                game.Publisher,
                game.Language,
                game.MinimumNumberOfPlayers,
                game.MaximumNumberOfPlayers,
                game.MinimumAge
                );

            return gameViewModel;


        }

    }
}
