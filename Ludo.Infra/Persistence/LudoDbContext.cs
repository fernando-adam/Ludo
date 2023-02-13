using Ludo.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Ludo.Infra.Persistance
{
    public class LudoDbContext : DbContext
    {
        public LudoDbContext(DbContextOptions<LudoDbContext> options) : base(options) { }
        
        public DbSet<Game> Games { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserGame> UserGame { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<AdvertisementGame> AdvertisementGames { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
