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
    
    public partial class scItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public scItem()
        {
            this.scItemSuppliers = new HashSet<scItemSupplier>();
            this.scRcvDtls = new HashSet<scRcvDtl>();
            this.scPoDtls = new HashSet<scPoDtl>();
            this.resIngredients = new HashSet<resIngredient>();
            this.resItems = new HashSet<resItem>();
            this.scInvOutDtls = new HashSet<scInvOutDtl>();
            this.resPreparationDtls = new HashSet<resPrepMaterial>();
            this.resPreparations = new HashSet<resPreparation>();
            this.scStoreBins = new HashSet<scStoreBin>();
            this.scItemCategories = new HashSet<scItemCategory>();
            this.scPrDtls = new HashSet<scPrDtl>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int scUomId { get; set; }
        public Nullable<int> Expirydays { get; set; }
        public Nullable<int> LowLevel { get; set; }
    
        public virtual scUom scUom { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<scItemSupplier> scItemSuppliers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<scRcvDtl> scRcvDtls { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<scPoDtl> scPoDtls { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<resIngredient> resIngredients { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<resItem> resItems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<scInvOutDtl> scInvOutDtls { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<resPrepMaterial> resPreparationDtls { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<resPreparation> resPreparations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<scStoreBin> scStoreBins { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<scItemCategory> scItemCategories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<scPrDtl> scPrDtls { get; set; }
    }
}
