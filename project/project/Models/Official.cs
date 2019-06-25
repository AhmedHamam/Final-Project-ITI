namespace project.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;
    using project.MyValidation;

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

        [Required(ErrorMessage = "*")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = " length between 3 and 25 character")] public string fName { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = " length between 3 and 25 character")]
        public string mName { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = " length between 3 and 25 character")]
        public string lName { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(25, MinimumLength = 5, ErrorMessage = " length between 5 and 25 character")]

        public string userName { get; set; }
        
        [Required]
        [StringLength(15, MinimumLength = 3)]
        [MyValidation.PasswordValidation(ErrorMessage = "Password not valid againest to custome validation")]
        public string passWord { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z0-9]+@[A-Za-z]+.[a-zA-Z]{2,4}")]
        public string email { get; set; }

        [StringLength(11)]
        public string phone { get; set; }

        [Required]
        [StringLength(11)]
        public string mobile { get; set; }

        public int? job_id { get; set; }

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

        public virtual OfficialJob OfficialJob { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Official> Officials1 { get; set; }

        public virtual Official Official1 { get; set; }
    }
}
