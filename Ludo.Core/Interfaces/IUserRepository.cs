using Ludo.Core.Entities;

namespace Ludo.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash);
        Task AddAsync(User user);
        Task AddGamesAsync(int idUser, int[] idGames);
    }
}
