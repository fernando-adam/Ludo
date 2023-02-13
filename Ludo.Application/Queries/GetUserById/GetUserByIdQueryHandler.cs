using Ludo.Application.VIewModels;
using Ludo.Core.Interfaces;
using MediatR;

namespace Ludo.Application.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserViewModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IGameRepository _gameRepository;
        public GetUserByIdQueryHandler(IUserRepository userRepository, IGameRepository gameRepository) 
        {
            _userRepository = userRepository;
            _gameRepository = gameRepository;
        }
        public async Task<UserViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);
            if (user == null) return null;
            var gameList = new List<GameViewModel>();

            for (int i = 0; i < user.UserGames.Count; i++)
            {
                var game = await _gameRepository.GetById(user.UserGames[i].GameId);
                var gameConvertido = new GameViewModel(game.GameId, game.Title, game.Description, game.Category, game.Publisher, game.Language, game.MinimumNumberOfPlayers, game.MaximumNumberOfPlayers, game.MinimumAge);

                gameList.Add(gameConvertido);
            }
            return new UserViewModel( user.UserId,user.FirstName, user.LastName, user.Email, gameList);
        }
    }
}
