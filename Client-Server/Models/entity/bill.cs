namespace Client_Server.Models.entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bill")]
    public partial class bill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public bill()
        {
            detailBills = new HashSet<detailBill>();
        }

        [Key]
        public int idBill { get; set; }

        public int? idCustomer { get; set; }

        [Column(TypeName = "date")]
        public DateTime? billDate { get; set; }

        [StringLength(10)]
        public string phone { get; set; }

        [StringLength(100)]
        public string statusBill { get; set; }

        [StringLength(100)]
        public string addressCustomer { get; set; }

        public int? idDiscount { get; set; }

        public virtual account account { get; set; }

        public virtual discout discout { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detailBill> detailBills { get; set; }
    }
}
