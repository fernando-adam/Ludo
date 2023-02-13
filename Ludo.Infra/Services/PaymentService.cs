using Ludo.Core.DTOs;
using Ludo.Core.Services;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;

namespace Ludo.Infra.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IHttpClientFactory _http;
        private readonly string _paymentBaseUrl;
        public PaymentService(IHttpClientFactory http, IConfiguration configuration)
        {
            _http = http;
            _paymentBaseUrl = configuration.GetSection("Services:Payments").Value;
        }
        public async Task<bool> ProcessPayment(PaymentInfoDTO paymentInfoDTO)
        {
            var url = $"{_paymentBaseUrl}/api/payments";
            var paymentInfoJson = JsonSerializer.Serialize(paymentInfoDTO);

            var paymentInfoContent = new StringContent(
                paymentInfoJson,
                Encoding.UTF8,
                "application/json"
                );

            var httpClient = _http.CreateClient("Payment");

            var response = await httpClient.PostAsync(url, paymentInfoContent);

            return response.IsSuccessStatusCode;

        }
    }
}
