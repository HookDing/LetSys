namespace Dal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PayInfo")]
    public partial class PayInfo
    {
        [Key]
        public int PayID { get; set; }

        public int? LetID { get; set; }

        public int? CCID { get; set; }

        [StringLength(14)]
        public string PayNum { get; set; }

        public int? CreateEmp { get; set; }

        public DateTime? CreateDate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PayPrice { get; set; }

        public int? PayAmount { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PayBeginDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PayEndDate { get; set; }

        [StringLength(500)]
        public string PayMark { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PayMoney1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PayMoney2 { get; set; }

        public int PayState { get; set; }

        public virtual ChargeCategory ChargeCategory { get; set; }

        public virtual Lets Lets { get; set; }
    }
}
