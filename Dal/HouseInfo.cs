namespace Dal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HouseInfo")]
    public partial class HouseInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HouseInfo()
        {
            Lets = new HashSet<Lets>();
        }

        [Key]
        public int HID { get; set; }

        public int? HCID { get; set; }

        [StringLength(100)]
        public string HAdd { get; set; }

        [StringLength(50)]
        public string HNum { get; set; }

        [StringLength(50)]
        public string HType { get; set; }

        public int? HArea { get; set; }

        [StringLength(50)]
        public string HDirection { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? HRent { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? HNet { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? HElectric { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? HWater { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? HElectricMoney { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? HWaterMoney { get; set; }

        [StringLength(500)]
        public string HMark { get; set; }

        public int? HState { get; set; }

        public virtual HouseCategory HouseCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lets> Lets { get; set; }
    }
}
