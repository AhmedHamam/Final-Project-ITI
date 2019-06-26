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
            Entity_Branchs = new HashSet<EntityBranchs>();
            Officials = new HashSet<Official>();
        }

        public int id { get; set; }

        [Required (ErrorMessage ="*")]
        [StringLength(500)]
        public string Title { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(500)]
        public string address { get; set; }

        [Required(ErrorMessage = "*")]
        [RegularExpression("^(01)[0-9]{9}", ErrorMessage = "—ﬁ„ €Ì— ’ÕÌÕ")]
        [StringLength(11)]
        public string phone { get; set; }

        [Required]
        [StringLength(11)]
        public string fax { get; set; }

        public bool is_deleted { get; set; }

        public int mangerId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EntityBranchs> Entity_Branchs { get; set; }

        public virtual Official Official { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Official> Officials { get; set; }
    }
}
