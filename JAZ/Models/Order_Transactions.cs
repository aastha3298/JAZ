namespace JAZ.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order_Transactions
    {
        [Key]
        public int Transaction_ID { get; set; }
        [Required(ErrorMessage = "Card number is required")]
        [DisplayName("Credit Card Number")]
        public Int32 CreditCardNo { get; set; }
        [Required(ErrorMessage = "CVV is required")]
       
        public int CVV { get; set;}
        [Required(ErrorMessage = "Expiry year is required")]
        [Range(2016, 2031, ErrorMessage = "Enter year between 2016 to 2031")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "Invalid expiry year")]
 
        public int ExpiryDate { get; set; }
        [Required(ErrorMessage = "Expiry month is required")]
        [Range(01, 12, ErrorMessage = "Enter month between 01 to 12")]
        [RegularExpression(@"^\d{2}$", ErrorMessage = "Invalid expiry month")]
      
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
