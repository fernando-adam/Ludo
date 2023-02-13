using Ludo.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ludo.Infra.Persistence.Configurations
{
    public class AdvertisementConfiguration : IEntityTypeConfiguration<Advertisement>
    {
        public void Configure(EntityTypeBuilder<Advertisement> builder)
        {
            builder
                .HasKey(p => p.AdvertisementId);

            builder.HasOne(p => p.Seller)
                .WithMany(o => o.OwnedAdvertisements)
                .HasForeignKey(p => p.SellerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
