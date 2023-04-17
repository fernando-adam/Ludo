using Ludo.Application.VIewModels;
using Ludo.Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ludo.Application.Queries.GetAllAdsQuery
{
    public class GetAllAdsQueryHandler : IRequestHandler<GetAllAdsQuery, List<AdvertisementViewModel>>
    {
        private readonly IAdvertisementRepository _adRepository;
        private readonly IGameRepository _gameRepository;
        public GetAllAdsQueryHandler(IAdvertisementRepository adRepository, IGameRepository gameRepository)
        {
            _adRepository = adRepository;
            _gameRepository = gameRepository;
        }
        public async Task<List<AdvertisementViewModel>> Handle(GetAllAdsQuery request, CancellationToken cancellationToken)
        {
            var ads = await _adRepository.GetAllAsync();

            var adViewModelList = new List<AdvertisementViewModel>();
            var gameList = new List<GameViewModel>();

            for (int i = 0; i < ads.Count; i++)
            {
                for (int j = 0; j < ads[i].AdvertisementGames.Count; j++)
                {
                    var gameId = ads[i].AdvertisementGames[j].GameId;
                    var game = await _gameRepository.GetById(gameId);
                    var gameVm = new GameViewModel(game.GameId, game.Title, game.Description, game.Category, game.Publisher, game.Language, game.MinimumNumberOfPlayers, game.MaximumNumberOfPlayers, game.MinimumAge);

                    gameList.Add(gameVm);
                }

                var adViewModel = new AdvertisementViewModel(ads[i].AdvertisementId, ads[i].Title, ads[i].Description, ads[i].TotalCost, gameList, ads[i].SellerId);

                adViewModelList.Add(adViewModel);

            }
            return adViewModelList;
        }

    }
}