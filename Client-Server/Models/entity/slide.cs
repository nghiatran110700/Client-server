namespace Client_Server.Models.entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("slide")]
    public partial class slide
    {
        [Key]
        public int idSlide { get; set; }

        [StringLength(100)]
        public string Content_slide { get; set; }
    }
}
