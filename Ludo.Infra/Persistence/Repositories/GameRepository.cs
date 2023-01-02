using Ludo.Core.Entities;
using Ludo.Core.Interfaces;
using Ludo.Infra.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Ludo.Infra.Persistence.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly LudoDbContext _dbContext;
        public GameRepository(LudoDbContext dbContext)
        {
            _dbContext= dbContext;
        }

        public async Task<List<Game>> GetAllAsync()
        {
            return await _dbContext.Games.ToListAsync();
        }

        public async Task<Game> GetById(int id)
        {
            return await _dbContext.Games.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(Game game)
        {
            await _dbContext.Games.AddAsync(game);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Game game)
        {
            _dbContext.Remove(game);
            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
