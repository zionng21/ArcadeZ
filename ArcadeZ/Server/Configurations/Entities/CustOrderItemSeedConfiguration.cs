using ArcadeZ.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArcadeZ.Server.Configurations.Entities
{
    public class CustOrderItemSeedConfiguration : IEntityTypeConfiguration<CustOrderItem>
    {
        public void Configure(EntityTypeBuilder<CustOrderItem> builder)
        {
            builder.HasData(
                new CustOrderItem
                {
                    Id = 1,
                    Qty = 1,
                    PhId = 1,
                    CohId = 1
                },
                new CustOrderItem
                {
                    Id = 2,
                    Qty = 1,
                    PsId = 1,
                    CohId = 1
                },
                new CustOrderItem
                {
                    Id = 3,
                    Qty = 1,
                    PhId = 1,
                    CohId = 2
                },
                new CustOrderItem
                {
                    Id = 4,
                    Qty = 2,
                    PhId = 4,
                    CohId = 2
                }
            );
        }
    }
}
