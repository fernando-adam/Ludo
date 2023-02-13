using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo.Core.DTOs
{
    public class PaymentInfoDTO
    {
        public PaymentInfoDTO(int idProject, string creditCardNumber, string cvv, string expiresAt, string cardName, decimal amount)
        {
            IdProject = idProject;
            CreditCardNumber = creditCardNumber;
            Cvv = cvv;
            ExpiresAt = expiresAt;
            CardName = cardName;
            Amount = amount;
        }

        public int IdProject { get; set; }
        public string CreditCardNumber { get; set; }
        public string Cvv { get; set; }
        public string ExpiresAt { get; set; }
        public string CardName { get; set; }
        public decimal Amount { get; set; }
    }
}
