namespace project.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Official
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Official()
        {
            Complaints = new HashSet<Complaint>();
            Complaints1 = new HashSet<Complaint>();
            Entities = new HashSet<Entity>();
            Officials1 = new HashSet<Official>();
        }

        public int id { get; set; }

        [StringLength(50)]
        public string fName { get; set; }

        [StringLength(50)]
        public string mName { get; set; }

        [StringLength(50)]
        public string lName { get; set; }

        [StringLength(50)]
        public string userName { get; set; }

        [StringLength(500)]
        public string passWord { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(11)]
        public string phone { get; set; }

        [Required]
        [StringLength(11)]
        public string mobile { get; set; }

        [StringLength(50)]
        public string job { get; set; }

        [StringLength(500)]
        public string jobDesciption { get; set; }

        public bool? isLeader { get; set; }

        public int? leaderId { get; set; }

        public int? entityId { get; set; }

        public bool isdeleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Complaint> Complaints { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Complaint> Complaints1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Entity> Entities { get; set; }

        public virtual Entity Entity { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Official> Officials1 { get; set; }

        public virtual Official Official1 { get; set; }
    }
}
