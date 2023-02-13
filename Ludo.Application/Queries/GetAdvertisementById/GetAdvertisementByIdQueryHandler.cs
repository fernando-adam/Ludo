using Ludo.Application.VIewModels;
using Ludo.Core.Interfaces;
using MediatR;

namespace Ludo.Application.Queries.GetAdvertisementById
{
    public class GetAdvertisementByIdQueryHandler : IRequestHandler<GetAdvertisementByIdQuery, AdvertisementViewModel>
    {
        private readonly IGameRepository _gameRepository;
        private readonly IAdvertisementRepository _advertisementRepository;

        public GetAdvertisementByIdQueryHandler(IGameRepository gameRepository, IAdvertisementRepository advertisementRepository)
        {
            _advertisementRepository = advertisementRepository;
            _gameRepository = gameRepository;
        }

        public async Task<AdvertisementViewModel> Handle(GetAdvertisementByIdQuery request, CancellationToken cancellationToken)
        {
            var ad = await _advertisementRepository.GetDetailsByIdAsync(request.Id);
            if (ad == null) return null;

            var gameList = new List<GameViewModel>();
            for (int i = 0; i < ad.AdvertisementGames.Count; i++)
            {
                var game = await _gameRepository.GetById(ad.AdvertisementGames[i].GameId);
                var gameConvertido = new GameViewModel(game.GameId, game.Title, game.Description, game.Category, game.Publisher, game.Language, game.MinimumNumberOfPlayers, game.MaximumNumberOfPlayers, game.MinimumAge);

                gameList.Add(gameConvertido);
            }
            return new AdvertisementViewModel(ad.AdvertisementId, ad.Title, ad.Description, ad.TotalCost, gameList, ad.SellerId);
        }
    }
}
