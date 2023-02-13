using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo.Core.DTOs
{
    public class PaymentInfoDTO
    {
        public int IdProject { get; set; }
        public string CreditCardNumber { get; set; }
        public string Cvv { get; set; }
        public string ExpiresAt { get; set; }
        public string CardName { get; set; }
        public decimal Amount { get; set; }
    }
}
