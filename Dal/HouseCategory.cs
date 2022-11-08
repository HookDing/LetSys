namespace Dal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HouseCategory")]
    public partial class HouseCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HouseCategory()
        {
            HouseInfo = new HashSet<HouseInfo>();
        }

        [Key]
        public int HCID { get; set; }

        [StringLength(50)]
        public string HCName { get; set; }

        [StringLength(500)]
        public string HCMark { get; set; }

        public bool? HCState { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HouseInfo> HouseInfo { get; set; }
    }
}
