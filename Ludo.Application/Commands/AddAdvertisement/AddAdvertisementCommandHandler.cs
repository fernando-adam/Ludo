using Ludo.Core.Entities;
using Ludo.Core.Interfaces;
using MediatR;

namespace Ludo.Application.Commands.AddAdvertisement
{
    public class AddAdvertisementCommandHandler : IRequestHandler<AddAdvertisementCommand, int>
    {
        private readonly IAdvertisementRepository _advertisementRepository;
        
        public AddAdvertisementCommandHandler(IAdvertisementRepository advertisementRepository)
        {
            _advertisementRepository = advertisementRepository;
        }

        public async Task<int> Handle(AddAdvertisementCommand request, CancellationToken cancellationToken)
        {
            var advertisement = new Advertisement(request.Title, request.Description, request.SellerId, request.TotalCost);

            _advertisementRepository.Add(advertisement);
            _advertisementRepository.AddGames(advertisement.AdvertisementId, request.GamesId);
            

            return advertisement.AdvertisementId;
        }
    }
}
