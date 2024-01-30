using Microsoft.AspNetCore.Identity;

namespace ArcadeZ.Server.Models
{
	public class ApplicationUser : IdentityUser
	{
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string? DisplayName {  get; set; }
		public string? Address { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string? Password {  get; set; }
	}
}
