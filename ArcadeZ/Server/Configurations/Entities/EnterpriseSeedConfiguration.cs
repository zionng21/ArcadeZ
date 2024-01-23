using ArcadeZ.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArcadeZ.Server.Configurations.Entities
{
    public class EnterpriseSeedConfiguration : IEntityTypeConfiguration<Enterprise>
    {
        public void Configure(EntityTypeBuilder<Enterprise> builder)
        {
            builder.HasData(
                new Enterprise
                {
                    Id = 1,
                    FirstName = "EntEmployee1",
                    EnterpriseName = "Enterprise1",
                    Password = "Enterprise1",
                    ContactNumber = 61232345,
                    Email = "Enterprise1@mail.com",
                    EnterpriseAddress = "Jurong West St 123",
                    JoinedDateTime = new DateTime(2020, 5, 19)
                },
                new Enterprise
                {
                    Id = 2,
                    FirstName = "EntEmployee2",
                    EnterpriseName = "Enterprise2",
                    Password = "Enterprise2",
                    ContactNumber = 81239022,
                    Email = "Enterprise2@mail.com",
                    EnterpriseAddress = "Ang Mo Kio Ave 7",
                    JoinedDateTime = new DateTime(2021, 3, 13)
                }
            );
        }
    }
}
