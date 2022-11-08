namespace Dal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Customers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customers()
        {
            Lets = new HashSet<Lets>();
        }

        [Key]
        public int CusID { get; set; }

        [StringLength(50)]
        public string CusName { get; set; }

        [StringLength(1)]
        public string CusSex { get; set; }

        [StringLength(50)]
        public string CusTel { get; set; }

        [StringLength(18)]
        public string CusCard { get; set; }

        public int? CusState { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lets> Lets { get; set; }
    }
}
