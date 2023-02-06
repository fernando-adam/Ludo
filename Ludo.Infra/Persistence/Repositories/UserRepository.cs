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
            var user = await _dbContext.Users.Include(x => x.UserGames).FirstOrDefaultAsync(p => p.UserId == idUser);
            for (int i = 0; i < idGames.Length; i++)
            {
                if (idGames[i] != 0 && !CheckDuplicateInGameList(user, idGames[i]))
                {
                    var game = await _dbContext.Games.FirstOrDefaultAsync(p => p.GameId == idGames[i]);
                    var gameConvertido = new UserGame { Game = game, User = user };
                    await _dbContext.UserGame.AddAsync(gameConvertido);
                } 
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _dbContext.Users.Include(p => p.UserGames).FirstOrDefaultAsync(i => i.UserId == id);
             
        }

        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash)
        {
            return await _dbContext.Users.FirstOrDefaultAsync( u => u.Email == email && u.Password == passwordHash);
        }

        private bool CheckDuplicateInGameList(User user, int gameId)
        {
            for (int i = 0; i < user.UserGames.Count; i++)
            {
                if (user.UserGames[i].GameId == gameId) return true;
            }
            return false;
        }
    }
}
