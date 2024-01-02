using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcadeZ.Shared.Domain
{
    public class ProductSoftware
    {
        public int PsId { get; set; }
        public string? sTitle { get; set; }
        public string? sPrice { get; set; }
        public string? Category { get; set; }
        public string? Description { get; set; }
        public int EnterpriseId { get; set; }
        public virtual Enterprise? Enterprise { get; set; }
    }
}
