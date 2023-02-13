using Ludo.Core.Entities;

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
