//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _4H_VFMS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class vYear
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public vYear()
        {
            this.tblVehicleLists = new HashSet<tblVehicleList>();
        }
    
        public int Id { get; set; }
        public string vYear1 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblVehicleList> tblVehicleLists { get; set; }
    }
}
