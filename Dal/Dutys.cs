namespace Dal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Dutys
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dutys()
        {
            Employs = new HashSet<Employs>();
            JurisdicDuty = new HashSet<JurisdicDuty>();
        }

        [Key]
        public int DutyID { get; set; }

        [StringLength(50)]
        public string DutyName { get; set; }

        [StringLength(500)]
        public string DutyMark { get; set; }

        public bool? DutyState { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employs> Employs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JurisdicDuty> JurisdicDuty { get; set; }
    }
}
