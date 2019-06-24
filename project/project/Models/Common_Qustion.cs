namespace project.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Common_Qustion
    {
        public int id { get; set; }

        [Required]
        public string Questation { get; set; }

        [Required]
        public string answer { get; set; }
    }
}
