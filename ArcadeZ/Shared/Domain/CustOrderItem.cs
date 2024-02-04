using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcadeZ.Shared.Domain
{
    public class CustOrderItem : BaseDomainModel
    {
        [Required]
        public int? Qty { get; set; }
        public int? ProductHardwareId { get; set; }
        public virtual ProductHardware? ProductHardware {  get; set; }
        public int? ProductSoftwareId { get; set; }
        public virtual ProductSoftware? ProductSoftware { get; set; }
        [Required]
        public int CustOrderId { get; set; }
        public virtual CustOrder? CustOrder { get; set; }
    }
}
