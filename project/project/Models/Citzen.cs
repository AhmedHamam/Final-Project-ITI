namespace project.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Citzen")]
    public partial class Citzen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Citzen()
        {
            Complaints = new HashSet<Complaint>();
        }

        public int id { get; set; }

        [Required(ErrorMessage="*")]
        [StringLength(50)]
        public string fName { get; set; }

        [Required(ErrorMessage="*")]
        [StringLength(50)]
        public string lName { get; set; }

        [Required(ErrorMessage="*")]
        [StringLength(50)]
        public string mName { get; set; }

        [Required(ErrorMessage="*")]
        [StringLength(14)]
        public string nationailnumber { get; set; }

        [Required(ErrorMessage="*")]
        [StringLength(500)]
        public string nationalNumberImage { get; set; }

        [Required(ErrorMessage="*")]
        [StringLength(50)]
        public string gender { get; set; }

        [Required(ErrorMessage="*")]
        [StringLength(50)]
        public string userName { get; set; }

        [Required(ErrorMessage="*")]
        [StringLength(50)]
        public string email { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(500)]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "*")]
        //[Compare("password")]
        [StringLength(500)]
        [NotMapped]
        public string confirmPassword { get; set; }
        [Required(ErrorMessage="*")]
        [StringLength(500)]
        
        public string address { get; set; }

        [Required(ErrorMessage="*")]
        [StringLength(11)]
        public string phone { get; set; }

        [Required(ErrorMessage="*")]
        [StringLength(11)]
        public string mobile { get; set; }

        [Column(TypeName = "date")]
        public DateTime? reg_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? accept_date { get; set; }

        [StringLength(50)]
        public string works_on { get; set; }

        public bool? accpted { get; set; }

        public bool? isdeleated { get; set; }

        public bool? blocked { get; set; }

        public int? cityId { get; set; }

        public int? accptedBy { get; set; }

        public virtual Admin Admin { get; set; }

        public virtual city city { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Complaint> Complaints { get; set; }
    }
}
