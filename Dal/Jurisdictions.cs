namespace Dal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Jurisdictions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Jurisdictions()
        {
            JurisdicDuty = new HashSet<JurisdicDuty>();
        }

        [Key]
        public int JurID { get; set; }

        [StringLength(50)]
        public string JurName { get; set; }

        [StringLength(500)]
        public string JurValue { get; set; }

        public int? JurState { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JurisdicDuty> JurisdicDuty { get; set; }
    }
}
