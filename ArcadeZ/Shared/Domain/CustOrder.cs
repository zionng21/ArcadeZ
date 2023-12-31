﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcadeZ.Shared.Domain
{
    public class CustOrder : BaseDomainModel
    {
        public DateTime? OrderDateTime { get; set; }
        public int CustId { get; set; }
        public virtual Customer? Customer { get; set; }
        public int StaffId { get; set; }
        public virtual Staff? Staff { get; set; }
    }
}
