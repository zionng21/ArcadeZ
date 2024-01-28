using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcadeZ.Shared.Domain
{
    public class ProductSoftware : BaseDomainModel
    {
        public string? sTitle { get; set; }
        public double? sPrice { get; set; }
        public string? Category { get; set; }
        public string? Description { get; set; }
        public byte[]? sthumbnail { get; set; }
        public int EnterpriseId { get; set; }
        public virtual Enterprise? Enterprise { get; set; }
    }
}
