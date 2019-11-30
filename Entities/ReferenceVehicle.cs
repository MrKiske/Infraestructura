using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ReferenceVehicle
    {
        public int IdReference { get; set; }

        public int Year { get; set; }

        public TypeBrand CodBrand { get; set; } 

        public string Model { get; set; }

        public TypeTransmission CodTransmission { get; set; }

        public TypeFuel CodFuel { get; set; }

        public string Engine { get; set; }

        public int EngineSize { get; set; }

        public int Cilinders { get; set; }

        public TypeCountry CodCountry { get; set; }

        public decimal TankSize { get; set; }

        public decimal OverallHeight { get; set; }

        public decimal OverallLength { get; set; }

        public decimal OverallWidth { get; set; }

        public int seating { get; set; }
    }
}
