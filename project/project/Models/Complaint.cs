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

        [StringLength(500)]
        public string comTitle { get; set; }

        public string comDescription { get; set; }

        public int? comEntitybranch_id { get; set; }

        public int? comEntity_id { get; set; }

        [StringLength(500)]
        public string comFile { get; set; }

        [Column(TypeName = "date")]
        public DateTime? comDate { get; set; }

        public bool? comStatus { get; set; }

        public int? comCity { get; set; }

        public virtual city city { get; set; }

        public virtual Entity Entity { get; set; }

        public virtual Entity_Branchs Entity_Branchs { get; set; }
    }
}
