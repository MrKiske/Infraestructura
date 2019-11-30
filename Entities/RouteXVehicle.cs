using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class RouteXVehicle
    {
        public int IdRouteVehicle { get; set; }

        public Vehicle CodVehicle { get; set; }

        public Route CodRoute { get; set; }
    }
}
