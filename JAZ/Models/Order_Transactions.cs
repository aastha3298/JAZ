namespace JAZ.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order_Transactions
    {
        [Key]
        public int Transaction_ID { get; set; }
        public Int32 CreditCardNo { get; set; }
        public int CVV { get; set;}
        public int ExpiryDate { get; set; }
        public int ExpiryMonth { get; set; }

        public string cardType { get; set; }

        public int? User_ID { get; set; }

        public DateTime? Transaction_Date { get; set; }

        public DateTime? Delivery_Date { get; set; }

        [StringLength(255)]
        public string Payment_Status { get; set; }

        public decimal? Transaction_Total { get; set; }

        public virtual User User { get; set; }
    }
}
