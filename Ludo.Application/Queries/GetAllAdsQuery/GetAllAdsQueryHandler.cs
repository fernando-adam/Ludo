using Ludo.Application.VIewModels;
using Ludo.Core.Interfaces;
using MediatR;

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

            var adViewModel = ads.
                              Select(p => new AdvertisementViewModel(
                                  p.AdvertisementId,
                                  p.Title,
                                  p.Description,
                                  p.TotalCost,
                                  new List<GameViewModel>(),
                                  p.SellerId
                                  )).ToList();

            return adViewModel;
        }
    }
}
