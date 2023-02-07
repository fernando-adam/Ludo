using Ludo.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo.Core.Entities
{
    public class Advertisement
    {
        public Advertisement(string title, string description, int sellerId, decimal totalCost) 
        {
            Title = title;
            Description = description;
            SellerId = sellerId;
            TotalCost = totalCost;

            CreatedAt= DateTime.Now;
            Status = AdvertisementEnum.InProgress;
            AdvertisementGames = new List<AdvertisementGame>();
        }


        public int AdvertisementId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int SellerId { get; private set; }
        public User Seller { get; private set; }
        public decimal TotalCost { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? FinishedAt { get; private set; }
        public AdvertisementEnum Status { get; private set; }


        /* EF Relations */
        public List<AdvertisementGame>? AdvertisementGames { get; private set; }

    }
}
