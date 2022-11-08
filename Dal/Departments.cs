namespace Dal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Departments
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Departments()
        {
            Employs = new HashSet<Employs>();
        }

        [Key]
        public int DepID { get; set; }

        [StringLength(50)]
        public string DepName { get; set; }

        public bool? DepState { get; set; }

        [StringLength(500)]
        public string DepMark { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employs> Employs { get; set; }
    }
}
