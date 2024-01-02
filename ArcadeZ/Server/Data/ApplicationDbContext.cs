using ArcadeZ.Server.Models;
using ArcadeZ.Shared.Domain;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ArcadeZ.Server.Data
{
	public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
	{
		public ApplicationDbContext(
			DbContextOptions options,
			IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
		{
		}

		public DbSet<Enterprise> Enterprises { get; set; }
        public DbSet<ProductHardware> ProductHardwares { get; set; }
        public DbSet<ProductSoftware> ProductSoftwares { get; set; }
		public DbSet<CustOrderItem> CustOrderItems { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Staff> Staffs { get; set; }
		public DbSet<CustEnquiry> CustEnquiries { get; set; }
		public DbSet<CustOrder> CustOrders { get; set; }
		public DbSet<Payment> Payments { get; set; }
    }
}
