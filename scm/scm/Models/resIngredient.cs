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
    
    public partial class resIngredient
    {
        public int Id { get; set; }
        public int resRecipeId { get; set; }
        public decimal Qty { get; set; }
        public int scItemId { get; set; }
    
        public virtual resRecipe resRecipe { get; set; }
        public virtual scItem scItem { get; set; }
    }
}