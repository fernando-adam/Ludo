using Ludo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
