using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcadeZ.Shared.Domain
{
    public class CustEnquiry : BaseDomainModel
    {
        [Required]
        public string? EnquiryDesc { get; set; }
        [Required]
        public string? EnquiryType { get; set; }
        public string? UpdatedBy { get; set; }
        public bool? Resolved { get; set; } = false;
        [Required]
        public int CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }
        public int? StaffId { get; set; }
        public virtual Staff? Staff { get; set; }
    }
}
