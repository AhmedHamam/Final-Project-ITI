namespace project.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class city
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public city()
        {
            Citzens = new HashSet<Citzen>();
            Complaints = new HashSet<Complaint>();
        }

        public int id { get; set; }

        [Required (ErrorMessage ="*")]
        [StringLength(500)]
        public string name { get; set; }
        [Required(ErrorMessage = "*")]
        public int gov_id { get; set; }

        public bool? isdeleted { get; set; }

        public virtual Government Government { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Citzen> Citzens { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Complaint> Complaints { get; set; }
    }
}
