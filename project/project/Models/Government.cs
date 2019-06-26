namespace project.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Government
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Government()
        {
            cities = new HashSet<city>();
        }

        public int id { get; set; }

        [Required(ErrorMessage ="*")]
        [StringLength(500)]
        [Display(Name = "«”„ «·„Õ«›Ÿ… :")]
        
        public string name { get; set; }
       
        public bool isdeleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<city> cities { get; set; }
    }
}
