using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcadeZ.Shared.Domain
{
    public class CustEnquiry : BaseDomainModel
    {
        public string? EnquiryDesc { get; set; }
        public string? EnquiryType { get; set; }
        public string? UpdatedBy { get; set; }
        public bool? Resolved { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }
        public int StaffId { get; set; }
        public virtual Staff? Staff { get; set; }
    }
}
