using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcadeZ.Shared.Domain
{
    public class Staff : BaseDomainModel
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime DateJoined { get; set; }
        public string? Password { get; set; }
        public string? Department { get; set; }
        public string? Role { get; set; }

    }
}
