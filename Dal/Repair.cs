namespace Dal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Repair")]
    public partial class Repair
    {
        [Key]
        public int RepID { get; set; }

        public int? LetID { get; set; }

        public DateTime? RepDate { get; set; }

        [StringLength(500)]
        public string RepContent { get; set; }

        public int? RepEmp { get; set; }

        public int? RepState { get; set; }

        [StringLength(500)]
        public string RepMark { get; set; }

        public DateTime? RepEndDate { get; set; }

        public int? CreateEmp { get; set; }

        public DateTime? CreateDate { get; set; }

        public virtual Lets Lets { get; set; }
    }
}
