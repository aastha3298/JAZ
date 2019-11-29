namespace JAZ.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Shopping_Cart
    {
        public int ID { get; set; }

        public int? User_ID { get; set; }

        public int? Product_ID { get; set; }

        public int? Product_Quantity { get; set; }

        public virtual Product Product { get; set; }

        public virtual User User { get; set; }
    }
}
