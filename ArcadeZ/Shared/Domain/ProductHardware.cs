using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcadeZ.Shared.Domain
{
    public class ProductHardware : BaseDomainModel
    {
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Title does not meet length requirements")]
        public string? hTitle { get; set; }
        [Required]
        public double? hPrice { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Description does not meet length requirements")]
        public string? Description { get; set; }
		public byte[]? hthumbnail { get; set; }
        [Required]
        public int Inventory { get; set; }
        [Required]
        public int EnterpriseId { get; set; }
        public virtual Enterprise? Enterprise { get; set; }
    }
}
