using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcadeZ.Shared.Domain
{
    public class CustOrder : BaseDomainModel
    {
        [Required]
        public DateTime? OrderDateTime { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }
        public int? StaffId { get; set; }
        public virtual Staff? Staff { get; set; }
    }
}
