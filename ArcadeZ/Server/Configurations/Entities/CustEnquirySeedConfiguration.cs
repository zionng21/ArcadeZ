using ArcadeZ.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArcadeZ.Server.Configurations.Entities
{
    public class CustEnquirySeedConfiguration : IEntityTypeConfiguration<CustEnquiry>
    {
        public void Configure(EntityTypeBuilder<CustEnquiry> builder)
        {
            builder.HasData(
                new CustEnquiry
                {
                    Id = 1,
                    EnquiryDesc = "Refund for game",
                    EnquiryType = "Refund",
                    UpdatedBy = "Staff1",
                    Resolved = true,
                    CustomerId = 1,
                    StaffId = 1
                },
                new CustEnquiry
                {
                    Id = 2,
                    EnquiryDesc = "Console not working properly",
                    EnquiryType = "Product Fault",
                    UpdatedBy = null,
                    Resolved = null,
                    CustomerId = 2,
                    StaffId = 1
                }
            );
        }
    }
}
