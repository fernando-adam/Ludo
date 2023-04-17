using Ludo.Core.Entities;
using Ludo.Core.Interfaces;
using Ludo.Infra.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Ludo.Infra.Persistence.Repositories
{
    public class AdvertisementRepository : IAdvertisementRepository
    {
        private readonly LudoDbContext _dbContext;
        public AdvertisementRepository(LudoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Advertisement advertisement)
        {
            _dbContext.Advertisements.Add(advertisement);
            _dbContext.SaveChanges();
        }

        public async Task<List<Advertisement>> GetAllAsync()
        {
            return await _dbContext.Advertisements.
                            Include(a=> a.Seller).
                            Include(a => a.AdvertisementGames)
                            .Where(p => p.Status == Core.Enums.AdvertisementEnum.InProgress) 
                            .ToListAsync();
        }

        public async Task<Advertisement> GetDetailsByIdAsync(int id)
        {
            return await _dbContext.Advertisements
                         .Include(a => a.Seller)
                         .Include(a => a.AdvertisementGames)
                         .FirstOrDefaultAsync(p => p.AdvertisementId == id);
        }

        public async Task<Advertisement> GetByIdAsync(int id)
        {
            return await _dbContext.Advertisements.FirstOrDefaultAsync(p => p.AdvertisementId == id);
        }

        public void AddGames(int adId,int[] idGames)
        {
            var advertisement =  _dbContext.Advertisements.FirstOrDefault(p => p.AdvertisementId == adId);
            for (int i = 0; i < idGames.Length; i++)
            {
                if (idGames[i] != 0)
                {
                    var game = _dbContext.Games.FirstOrDefault(p => p.GameId == idGames[i]);
                    var gameConvertido = new AdvertisementGame { Advertisement = advertisement, Game = game };
                    _dbContext.AdvertisementGames.Add(gameConvertido);
                }
                
            }
             _dbContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
