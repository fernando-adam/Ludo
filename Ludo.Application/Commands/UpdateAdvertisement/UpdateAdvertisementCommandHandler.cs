using Ludo.Core.Interfaces;
using MediatR;

namespace Ludo.Application.Commands.UpdateAdvertisement
{
    public class UpdateAdvertisementCommandHandler : IRequestHandler<UpdateAdvertisementCommand, bool>
    {
        private readonly IAdvertisementRepository _adRepository;
        public UpdateAdvertisementCommandHandler(IAdvertisementRepository adRepository)
        {
            _adRepository = adRepository;
        }
        public async Task<bool> Handle(UpdateAdvertisementCommand request, CancellationToken cancellationToken)
        {
            var ad = await _adRepository.GetByIdAsync(request.Id);
            if (ad == null) return false;

            ad.Update(request.Title, request.Description, request.TotalCost);
            return true;
        }
    }
}
