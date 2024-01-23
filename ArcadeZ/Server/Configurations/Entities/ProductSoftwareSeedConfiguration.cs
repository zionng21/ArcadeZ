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
                    Id = 1,
                    sTitle = "Black War 1",
                    sPrice = 69.89,
                    Category = "Shooter, Action",
                    Description = "World War 1 action",
                    EnterpriseId = 1
                },
                new ProductSoftware
                {
                    Id = 2,
                    sTitle = "Overboost",
                    sPrice = 100.12,
                    Category = "Shooter, FPS, Violence",
                    Description = "Boosting in game",
                    EnterpriseId = 2
                }
            );
        }
    }
}
