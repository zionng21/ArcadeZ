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
                    Id = 1,
                    hTitle = "Mouse",
                    hPrice = 20.99,
                    Description = "Gaming Mouse Brand1",
                    Inventory = 100,
                    EnterpriseId = 1
                },
                new ProductHardware
                {
                    Id = 2,
                    hTitle = "Keyboard",
                    hPrice = 42.99,
                    Description = "RGB Gaming Keyboard Brand1",
                    Inventory = 100,
                    EnterpriseId = 1
                },
                new ProductHardware
                {
                    Id = 3,
                    hTitle = "Mouse",
                    hPrice = 89.99,
                    Description = "Gaming Mouse Brand2",
                    Inventory = 100,
                    EnterpriseId = 2
                },
                new ProductHardware
                {
                    Id = 4,
                    hTitle = "Keyboard",
                    hPrice = 63.67,
                    Description = "Gaming Keyboard Brand2",
                    Inventory = 100,
                    EnterpriseId = 2
                }
            );
        }
    }
}
