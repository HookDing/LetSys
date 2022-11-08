namespace Dal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChargeCategory")]
    public partial class ChargeCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChargeCategory()
        {
            PayInfo = new HashSet<PayInfo>();
        }

        [Key]
        public int CCID { get; set; }

        [StringLength(50)]
        public string CCName { get; set; }

        [StringLength(500)]
        public string CCMark { get; set; }

        public bool? ISDate { get; set; }

        public bool? CCState { get; set; }

        [StringLength(50)]
        public string CCColumn1 { get; set; }

        [StringLength(50)]
        public string CCColumn2 { get; set; }

        [StringLength(50)]
        public string CDateColumn { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PayInfo> PayInfo { get; set; }
    }
}
