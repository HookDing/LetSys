namespace Dal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Employs
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employs()
        {
            Lets = new HashSet<Lets>();
        }

        [Key]
        public int EmpID { get; set; }

        public int? DepID { get; set; }

        public int? DutyID { get; set; }

        [StringLength(18)]
        public string LoginName { get; set; }

        [StringLength(47)]
        public string LoginPWD { get; set; }

        [StringLength(50)]
        public string EmpName { get; set; }

        [StringLength(1)]
        public string EmpSex { get; set; }

        [StringLength(50)]
        public string EmpTel { get; set; }

        [StringLength(100)]
        public string EmpAdd { get; set; }

        public int? EmpState { get; set; }

        [StringLength(500)]
        public string EmpMark { get; set; }

        public virtual Departments Departments { get; set; }

        public virtual Dutys Dutys { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lets> Lets { get; set; }
    }
}
