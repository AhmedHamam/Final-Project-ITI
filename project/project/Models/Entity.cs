namespace project.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Entity")]
    public partial class Entity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Entity()
        {
            Complaints = new HashSet<Complaint>();
            Entity_Branchs = new HashSet<Entity_Branchs>();
            Officials = new HashSet<Official>();
        }

        public int id { get; set; }

        [StringLength(500)]
        public string Title { get; set; }

        [StringLength(500)]
        public string address { get; set; }

        [StringLength(11)]
        public string phone { get; set; }

        [StringLength(11)]
        public string fax { get; set; }

        public bool? is_deleted { get; set; }

        public int? mangerId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Complaint> Complaints { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Entity_Branchs> Entity_Branchs { get; set; }

        public virtual Official Official { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Official> Officials { get; set; }
    }
}
