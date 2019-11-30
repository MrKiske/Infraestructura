using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class BusStop
    {
        public int IdBusStop { get; set; }

        public Route CodRoute { get; set; }

        public Station CodStation { get; set; }

        public DateTime DateStartOperation { get; set; }

        public DateTime DateEndOperation { get; set; }

        public int DaysOperation { get; set; }

        public int StopWagon { get; set; }
    }
}
