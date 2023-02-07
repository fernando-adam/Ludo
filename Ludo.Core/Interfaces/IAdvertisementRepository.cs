using Ludo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo.Core.Interfaces
{
    public interface IAdvertisementRepository
    {
        Task<List<Advertisement>> GetAllAsync();
        Task<Advertisement> GetDetailsByIdAsync(int id);
        Task<Advertisement> GetByIdAsync(int id);
        void Add(Advertisement advertisement);
        Task SaveChangesAsync();
        void AddGames(int adId, int[] gamesId);
    }
}
