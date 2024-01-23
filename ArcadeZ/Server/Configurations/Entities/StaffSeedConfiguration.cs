using ArcadeZ.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArcadeZ.Server.Configurations.Entities
{
    public class StaffSeedConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.HasData(
                new Staff
                {
                    Id = 1,
                    Name = "Staff1",
                    Email = "staff1@arcadeZmail.com",
                    DateOfBirth = new DateTime(1987, 1, 1),
                    DateJoined = new DateTime(2022, 2, 2),
                    Password = "P@ssw0rd",
                    Department = "Customer Service",
                    Role = "CS Support" 
                },
                new Staff
                {
                    Id = 2,
                    Name = "Staff2",
                    Email = "staff2@arcadeZmail.com",
                    DateOfBirth = new DateTime(2003, 2, 2),
                    DateJoined = new DateTime(2021, 3, 3),
                    Password = "P@ssw0rd",
                    Department = "Customer Service",
                    Role = "CS Manager"
                }
            );
        }
    }
}
