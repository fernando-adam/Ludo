using Ludo.Core.DTOs;
using Ludo.Core.Interfaces;
using Ludo.Core.Services;
using MediatR;

namespace Ludo.Application.Commands.FinishAdvertisement
{
    public class FinishAddCommandHandler : IRequestHandler<FinishAdCommand, bool>
    {
        private readonly IAdvertisementRepository _adRepository;
        private readonly IPaymentService _paymentService;
        public FinishAddCommandHandler(IAdvertisementRepository advertisementRepository, IPaymentService paymentService)
        {
            _adRepository = advertisementRepository;
            _paymentService = paymentService;
        }
        public async Task<bool> Handle(FinishAdCommand request, CancellationToken cancellationToken)
        {
            var ad = await _adRepository.GetByIdAsync(request.Id);

            var paymentInfoDto = new PaymentInfoDTO(request.Id, request.CreditCardNumber, request.Cvv, request.ExpiresAt, request.FullName, request.Amount);

            _paymentService.ProcessPayment(paymentInfoDto);

            ad.SetPaymentPending();

            await _adRepository.SaveChangesAsync();

            return true;   
        }
    }
}
