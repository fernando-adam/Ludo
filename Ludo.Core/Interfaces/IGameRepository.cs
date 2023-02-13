using Ludo.Core.Entities;

namespace Ludo.Core.Interfaces
{
    public interface IGameRepository
    {
        Task<List<Game>> GetAllAsync();
        Task<Game> GetById(int id);
        Task AddAsync(Game game);
        Task SaveChangesAsync();
        Task Delete(Game game);
    }
}
