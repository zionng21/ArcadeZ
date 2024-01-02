using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcadeZ.Shared.Domain
{
    public class Enterprise : BaseDomainModel
    {
        public string? FirstName { get; set; }
        public string? EnterpriseName { get; set; }
        public string? Password { get; set; }
        public int? ContactNumber { get; set; }
        public string? Email { get; set; }
        public string? EnterpriseAddress { get; set; }
        public DateTime JoinedDateTime { get; set; }
        
    }
}
