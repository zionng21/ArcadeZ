using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcadeZ.Shared.Domain
{
    public class ProductHardware : BaseDomainModel
    {
        public string? hTitle { get; set; }
        public double? hPrice { get; set; }
        public string? Description { get; set; }
		public byte[]? hthumbnail { get; set; }
		public int Inventory { get; set; }    
        public int EnterpriseId { get; set; }
        public virtual Enterprise? Enterprise { get; set; }
    }
}
