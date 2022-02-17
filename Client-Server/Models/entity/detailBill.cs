namespace Client_Server.Models.entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("detailBill")]
    public partial class detailBill
    {
        public int id { get; set; }

        public int? idBill { get; set; }

        public int? idProduct { get; set; }

        public int? amount { get; set; }

        [StringLength(10)]
        public string size { get; set; }

        public virtual bill bill { get; set; }

        public virtual product product { get; set; }
    }
}
