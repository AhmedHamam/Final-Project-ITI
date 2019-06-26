namespace project.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OfficialJob
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OfficialJob()
        {
            Officials = new HashSet<Official>();
        }

       
        public int id { get; set; }

        [Required(ErrorMessage ="*")]
        [StringLength(500)]
        public string Job { get; set; }

        [Required(ErrorMessage ="*")]
        public string jobDescriptaion { get; set; }
        public bool? isdeleted { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Official> Officials { get; set; }
    }
}
