//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class VEHICLE
    {
        public long Id { get; set; }
        public string IdVehicle { get; set; }
        public long Mileage { get; set; }
        public int Capacity { get; set; }
        public bool Status { get; set; }
        public bool Available { get; set; }
    
        public virtual TYPEVEHICLE TYPEVEHICLE { get; set; }
        public virtual ZONE ZONE { get; set; }
    }
}
