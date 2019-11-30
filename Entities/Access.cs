using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Access
    {
        public int IdAccess { get; set; }

        public Station CodStation { get; set; }

        public User CodUser { get; set; }

        public DateTime DateEntry  { get; set; }

        public DateTime? DateExit { get; set; }
    }
}
