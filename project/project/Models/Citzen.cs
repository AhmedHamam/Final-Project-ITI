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
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string fName { get; set; }

        [Required]
        [StringLength(50)]
        public string lName { get; set; }

        [Required]
        [StringLength(50)]
        public string mName { get; set; }

        [Required]
        [StringLength(14)]
        public string nationailnumber { get; set; }

        [Required]
        [StringLength(500)]
        public string nationalNumberImage { get; set; }

        [Required]
        [StringLength(50)]
        public string gender { get; set; }

        [Required]
        [StringLength(50)]
        public string userName { get; set; }

        [Required]
        [StringLength(50)]
        public string email { get; set; }

        [Required]
        [StringLength(500)]
        public string password { get; set; }

        [StringLength(500)]
        public string address { get; set; }

        [StringLength(11)]
        public string phone { get; set; }

        [StringLength(11)]
        public string mobile { get; set; }

        [Column(TypeName = "date")]
        public DateTime? reg_date { get; set; }

        [StringLength(50)]
        public string works_on { get; set; }

        public bool? accpted { get; set; }

        public bool? deleated { get; set; }

        public bool? blocked { get; set; }

        public int? cityId { get; set; }

        public int accptedBy { get; set; }

        public virtual Admin Admin { get; set; }

        public virtual city city { get; set; }
    }
}