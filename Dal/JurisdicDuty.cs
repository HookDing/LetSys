namespace Dal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("JurisdicDuty")]
    public partial class JurisdicDuty
    {
        [Key]
        public int JDID { get; set; }

        public int? JurID { get; set; }

        public int? DutyID { get; set; }

        public virtual Dutys Dutys { get; set; }

        public virtual Jurisdictions Jurisdictions { get; set; }
    }
}
