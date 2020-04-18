namespace Laba7
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Delivery")]
    public partial class Delivery
    {
        public int id_shop { get; set; }

        public int id_provider { get; set; }

        [Column(TypeName = "date")]
        public DateTime deliveryDate { get; set; }

        [Key]
        public int id_delivery { get; set; }

        public virtual Provider Provider { get; set; }

        public virtual Shop Shop { get; set; }
    }
}
