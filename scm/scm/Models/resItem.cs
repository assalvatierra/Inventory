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
    
    public partial class resItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public resItem()
        {
            this.resOrderDtls = new HashSet<resOrderDtl>();
        }
    
        public int Id { get; set; }
        public int scItemId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string barcode { get; set; }
        public decimal resQty { get; set; }
    
        public virtual scItem scItem { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<resOrderDtl> resOrderDtls { get; set; }
    }
}
