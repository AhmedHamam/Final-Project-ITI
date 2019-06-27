namespace project.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EntityBranchs
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EntityBranchs()
        {
            Complaints = new HashSet<Complaint>();
        }

        public int id { get; set; }

        [Required (ErrorMessage ="*")]
        [StringLength(500)]
        public string title { get; set; }

        public int? entity_id { get; set; }

        public bool is_deleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Complaint> Complaints { get; set; }

        public virtual Entity Entity { get; set; }
    }
}
