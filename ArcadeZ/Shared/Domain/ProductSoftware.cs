using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcadeZ.Shared.Domain
{
    public class ProductSoftware : BaseDomainModel
    {
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Title does not meet length requirements")]
        public string? sTitle { get; set; }
        [Required]
        public double? sPrice { get; set; }
        [Required]
        public string? Category { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Description does not meet length requirements")]
        public string? Description { get; set; }
        public byte[]? sthumbnail { get; set; }
        [Required]
        public int EnterpriseId { get; set; }
        public virtual Enterprise? Enterprise { get; set; }
    }
}
