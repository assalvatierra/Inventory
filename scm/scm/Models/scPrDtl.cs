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
    
    public partial class scPrDtl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public scPrDtl()
        {
            this.scPoDtls = new HashSet<scPoDtl>();
        }
    
        public int Id { get; set; }
        public int scPrHdrId { get; set; }
        public int scItemId { get; set; }
        public decimal Qty { get; set; }
        public int scUomId { get; set; }
    
        public virtual scPrHdr scPrHdr { get; set; }
        public virtual scItem scItem { get; set; }
        public virtual scUom scUom { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<scPoDtl> scPoDtls { get; set; }
    }
}
