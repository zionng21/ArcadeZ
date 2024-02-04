using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcadeZ.Shared.Domain
{
    public class Customer : BaseDomainModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "User Name does not meet length requirements")]
        public string? UserName { get; set; }
        public string? Address { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email address is not a valid email")] 
        [EmailAddress]
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [Required]
        public string? Password { get; set; }
    }
    
}
