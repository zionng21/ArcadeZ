using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcadeZ.Shared.Domain
{
    public class CustOrderItem : BaseDomainModel
    {
        public int? Qty { get; set; }
        public int PhId { get; set; }
        public virtual ProductHardware? ProductHardware {  get; set; }
        public int PsId { get; set; }
        public virtual ProductSoftware? ProductSoftware { get; set; }
        public int CohId { get; set; }
        public virtual CustOrder? CustOrder { get; set; }
    }
}
