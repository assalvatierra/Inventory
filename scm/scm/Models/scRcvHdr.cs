//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace scm.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class scRcvHdr
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public scRcvHdr()
        {
            this.scRcvDtls = new HashSet<scRcvDtl>();
        }
    
        public int Id { get; set; }
        public System.DateTime dtRcv { get; set; }
        public int scSupplierId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<scRcvDtl> scRcvDtls { get; set; }
        public virtual scSupplier scSupplier { get; set; }
    }
}
