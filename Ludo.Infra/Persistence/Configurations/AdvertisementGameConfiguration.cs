using Ludo.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ludo.Infra.Persistence.Configurations
{
    public class AdvertisementGameConfiguration : IEntityTypeConfiguration<AdvertisementGame>
    {
        public void Configure(EntityTypeBuilder<AdvertisementGame> builder)
        {
            builder
                .HasKey(t => new { t.AdvertisementId, t.GameId });

            builder
                .HasOne(ag => ag.Game)
                .WithMany(a => a.AdvertisementGames)
                .HasForeignKey(a => a.GameId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(ag => ag.Advertisement)
                .WithMany(a => a.AdvertisementGames)
                .HasForeignKey(f => f.AdvertisementId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
