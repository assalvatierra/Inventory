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
    
    public partial class scInvOutHdr
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public scInvOutHdr()
        {
            this.scInvOutDtls = new HashSet<scInvOutDtl>();
        }
    
        public int Id { get; set; }
        public System.DateTime dtOut { get; set; }
        public string Remarks { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<scInvOutDtl> scInvOutDtls { get; set; }
    }
}
