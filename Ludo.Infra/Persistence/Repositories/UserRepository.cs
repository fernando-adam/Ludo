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

        public async Task<User> GetByIdAsync(int id)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash)
        {
            return await _dbContext.Users.SingleOrDefaultAsync( u => u.Email == email && u.Password == passwordHash);
        }
    }
}
