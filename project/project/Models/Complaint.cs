namespace project.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Complaint")]
    public partial class Complaint
    {
        public int id { get; set; }

        public long? comNumber { get; set; }

        [Required(ErrorMessage = "ادخل عنوان الشكوى")]
        [StringLength(500)]
        public string comTitle { get; set; }

        [Required(ErrorMessage = "ادخل تفاصيل الشكوى")]
        public string comDescription { get; set; }

        [StringLength(500)]
        public string comFile { get; set; }

        [StringLength(500)]
        public string comFile2 { get; set; }

        [Column(TypeName = "date")]
        public DateTime? comDate { get; set; }

        [Required]
        [StringLength(50)]
        public string comType { get; set; }

        public int comCategory { get; set; }

        public int? comCity { get; set; }

        public int? comEntitybranch { get; set; }

        public int? comCitzen { get; set; }

        public bool isreaded { get; set; }

        public int? readby { get; set; }

        public int? solveby { get; set; }

        public bool? isSolved { get; set; }

        public string solveDescription { get; set; }

        public virtual city city { get; set; }

        public virtual Citzen Citzen { get; set; }

        public virtual Complaint_Catgories Complaint_Catgories { get; set; }

        public virtual EntityBranchs Entity_Branchs { get; set; }

        public virtual Official Official { get; set; }

        public virtual Official Official1 { get; set; }
    }
}
