//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SMMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Technician
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Technician()
        {
            this.InstumentServices = new HashSet<InstumentService>();
        }
    
        public int TechnicianID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a technician description.")]
        [Display(Name = "Technician Description")]
        public string Description { get; set; }

        public int UserID { get; set; }
    
        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InstumentService> InstumentServices { get; set; }
    }
}
