using Ludo.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo.Application.Commands.AddAdvertisement
{
    public class AddAdvertisementCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int SellerId { get; set; }
        public decimal TotalCost { get; set; }
        public int[] GamesId { get; set; }
    }
}
