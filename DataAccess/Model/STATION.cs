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
    
    public partial class STATION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public STATION()
        {
            this.ACCESS = new HashSet<ACCESS>();
        }
    
        public int IdStation { get; set; }
        public string AbbreviationStation { get; set; }
        public string NameStation { get; set; }
        public bool Status { get; set; }
    
        public virtual TYPESTATION TYPESTATION { get; set; }
        public virtual ZONE ZONE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ACCESS> ACCESS { get; set; }
    }
}
