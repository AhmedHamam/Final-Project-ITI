namespace project.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public partial class Admin
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Admin()
        {
            Admin_Roles = new HashSet<Admin_Roles>();
            Citzens = new HashSet<Citzen>();
        }

        public int id { get; set; }

        [Required(ErrorMessage ="*")]
        [StringLength(50)]
        public string fName { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(50)]
        public string mName { get; set; }

        [Required (ErrorMessage ="*")]
        [StringLength(50)]
        public string lName { get; set; }

        [Required(ErrorMessage ="*")]
        [EmailAddress]
        [StringLength(50)]
        public string email { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(50)]
        public string userName { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        [StringLength(50)]
        public string password { get; set; }
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        [StringLength(50)]
        [Compare("password",ErrorMessage ="password not matched")]
        [NotMapped]
        public string confpassword { get; set; }
        [Required(ErrorMessage = "*")]
        [RegularExpression("^(01)[0-9]{9}", ErrorMessage = "—ﬁ„ €Ì— ’ÕÌÕ")]
        [StringLength(11)]
        public string phone { get; set; }

        public bool isdeleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Admin_Roles> Admin_Roles { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Citzen> Citzens { get; set; }
    }
}
