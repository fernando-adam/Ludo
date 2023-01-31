using Ludo.Core.Entities;
using Ludo.Core.Interfaces;
using Ludo.Infra.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo.Infra.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LudoDbContext _dbContext;
        public UserRepository(LudoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(User user)
        {
            await _dbContext.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddGamesAsync(int idUser, int[] idGames)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(p => p.UserId == idUser);

            var gameList = new List<UserGame>();

            for (int i = 0; i < idGames.Length; i++)
            {
                var game = await _dbContext.Games.FirstOrDefaultAsync(p => p.GameId == idGames[i]);
                var gameConvertido = new UserGame(game, user);

                _dbContext.UserGames.Add(gameConvertido);

            }
            await _dbContext.SaveChangesAsync(); 

        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(p => p.UserId == id);
        }

        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash)
        {
            return await _dbContext.Users.SingleOrDefaultAsync( u => u.Email == email && u.Password == passwordHash);
        }
    }
}
