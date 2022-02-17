namespace Client_Server.Models.entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("product")]
    public partial class product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public product()
        {
            detailBills = new HashSet<detailBill>();
        }

        [Key]
        public int idProduct { get; set; }

        [StringLength(100)]
        public string NameProduct { get; set; }

        public int? Price { get; set; }

        [StringLength(100)]
        public string img { get; set; }

        public string descriptions { get; set; }

        public int? idBrand { get; set; }

        public int? idCate { get; set; }

        public bool? status { get; set; }

        public virtual brand brand { get; set; }

        public virtual category category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detailBill> detailBills { get; set; }
    }
}
