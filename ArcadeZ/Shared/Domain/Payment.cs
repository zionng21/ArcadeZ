using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcadeZ.Shared.Domain
{
    public class Payment : BaseDomainModel
    {
        [Required]
        public DateTime? PaymentDateTime { get; set; }
        [Required]
        public double? Amount { get; set; }
        [Required]
        public string? PaymentType { get; set; }
        [Required]
        public int CustomerId {  get; set; }
        public virtual Customer? Customer { get; set; }
        [Required]
        public int CustOrderId { get; set; }
        public virtual CustOrder? CustOrder { get; set; }
    }
}
