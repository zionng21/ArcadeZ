using ArcadeZ.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArcadeZ.Server.Configurations.Entities
{
    public class CustomerSeedConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(
                new Customer
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Chan",
                    UserName = "Johnny123",
                    Address = "Tampines St 42 #03-12",
                    Email = "JohnChan@mail.com",
                    DateOfBirth = new DateTime(2002, 9, 17),
                    Password = "JohnChan"
                },
                new Customer
                {
                    Id = 2,
                    FirstName = "Tom",
                    LastName = "Ng",
                    UserName = "Xx_Tom_xX",
                    Address = "Bedok South Ave 3 #10-175",
                    Email = "TomNg@mail.com",
                    DateOfBirth = new DateTime(1985, 4, 21),
                    Password = "TomNg"
                }
            );
        }
    }
}
