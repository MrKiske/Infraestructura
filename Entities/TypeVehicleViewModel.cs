using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [DataContract]
    public class TypeVehicleViewModel
    {
        [DataMember]
        public int IdZone { get; set; }

        [DataMember]
        public int IdTypeVehicle { get; set; }
    }
}
