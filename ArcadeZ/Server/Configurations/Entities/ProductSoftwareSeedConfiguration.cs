using ArcadeZ.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArcadeZ.Server.Configurations.Entities
{
    public class ProductSoftwareSeedConfiguration : IEntityTypeConfiguration<ProductSoftware>
    {
        public void Configure(EntityTypeBuilder<ProductSoftware> builder)
        {
            builder.HasData(
                new ProductSoftware
                {

                },

                new ProductSoftware
                {

                }
                );
        }
    }
}
