﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcadeZ.Shared.Domain
{
	public class TempCart : BaseDomainModel
	{
		[Required]
		public int Quantity { get; set; }
		public int? ProductHardwareId { get; set; }
		public virtual ProductHardware? ProductHardware { get; set; }
		public int? ProductSoftwareId { get; set; }
		public virtual ProductSoftware? ProductSoftware { get; set; }
        [Required]
        public int CustomerId { get; set; }
		public virtual Customer? Customer { get; set; }
	}
}
