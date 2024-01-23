using ArcadeZ.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArcadeZ.Server.Configurations.Entities
{
    public class CustOrderSeedConfiguration : IEntityTypeConfiguration<CustOrder>
    {
        public void Configure(EntityTypeBuilder<CustOrder> builder)
        {
            builder.HasData(
                new CustOrder
                {
                    Id = 1,
                    OrderDateTime = new DateTime(2024, 1, 3),
                    CustomerId = 1,
                    StaffId = 1
                },
                new CustOrder
                {
                    Id = 2,
                    OrderDateTime = new DateTime(2024, 1, 5),
                    CustomerId = 2,
                    StaffId = 2
                }
            );
        }
    }
}
