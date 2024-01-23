using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcadeZ.Shared.Domain
{
    public class Payment : BaseDomainModel
    {
        public DateTime? PaymentDateTime { get; set; }
        public double? Amount { get; set; }
        public string? PaymentType { get; set; }
        public int CustomerId {  get; set; }
        public virtual Customer? Customer { get; set; }
        public int CustOrderId { get; set; }
        public virtual CustOrder? CustOrder { get; set; }
    }
}
