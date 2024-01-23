using ArcadeZ.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArcadeZ.Server.Configurations.Entities
{
    public class PaymentSeedConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasData(
                new Payment
                {
                    Id = 1,
                    PaymentDateTime = new DateTime(2024, 1, 3),
                    Amount = 90.88,
                    PaymentType = "Card",
                    CustId = 1,
                    CohId = 1
                },
                new Payment
                {
                    Id = 2,
                    PaymentDateTime = new DateTime(2024, 1, 5),
                    Amount = 148.33,
                    PaymentType = "PayNow",
                    CustId = 2,
                    CohId = 2
                }
            );
        }
    }
}