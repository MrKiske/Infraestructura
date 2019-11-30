using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public partial class Station
    {
        public int IdStation { get; set; }

        public string NameStation { get; set; }

        public TypeStation CodTypeStation { get; set; }

        public Zone CodZone { get; set; }

    }

    public partial class Station
    {
        public bool status { get; set; }
    }
}
