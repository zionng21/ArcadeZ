using ArcadeZ.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArcadeZ.Server.Configurations.Entities
{
    public class ProductHardwareSeedConfiguration : IEntityTypeConfiguration<ProductHardware>
    {
        public void Configure(EntityTypeBuilder<ProductHardware> builder)
        {
            builder.HasData(
                new ProductHardware
                {

                },

                new ProductHardware
                {

                }
                );
        }
    }
}
