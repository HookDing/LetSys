namespace Dal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Lets
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lets()
        {
            PayInfo = new HashSet<PayInfo>();
            Repair = new HashSet<Repair>();
        }

        [Key]
        public int LetID { get; set; }

        public int? HID { get; set; }

        public int? CusID { get; set; }

        public int? EmpID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? LetBeginDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ExpectEndDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? LetEndDate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? LetRent { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? LetNet { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? BeginElectric { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? BeginWater { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? EndElectric { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? EndWater { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? EndMoney { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CurrentNetDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CurrentRentDate { get; set; }

        public int? CreateEmp { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? LetState { get; set; }

        [StringLength(500)]
        public string LetMark { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? LetElectric { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? LetWater { get; set; }

        public virtual Customers Customers { get; set; }

        public virtual Employs Employs { get; set; }

        public virtual HouseInfo HouseInfo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PayInfo> PayInfo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Repair> Repair { get; set; }
    }
}
