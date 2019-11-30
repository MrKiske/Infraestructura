using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public partial class Vehicle
    {
        public string IdVehicle { get; set; }

        public virtual TypeVehicle type { get; set; }

        public int capable { get; set; }

        public virtual Zone zone { get; set; }

        public bool Status { get; set; } 

        public long Mileage { get; set; }

        public bool Available { get; set; }
    }
}
