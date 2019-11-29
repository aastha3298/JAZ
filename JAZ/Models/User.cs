namespace JAZ.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Order_Transactions = new HashSet<Order_Transactions>();
            Shopping_Cart = new HashSet<Shopping_Cart>();
        }

        public int ID { get; set; }

        [StringLength(255)]
        public string Username { get; set; }

        [StringLength(255)]
        public string First_Name { get; set; }

        [StringLength(255)]
        public string Last_Name { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(255)]
        public string Phone_Number { get; set; }

        [StringLength(255)]
        public string Password { get; set; }

        [StringLength(255)]
        public string Role { get; set; }

        [StringLength(255)]
        public string StAddress { get; set; }

        public int? City { get; set; }

        [StringLength(255)]
        public string Province { get; set; }

        [StringLength(255)]
        public string PostalCode { get; set; }

        public int? Country { get; set; }

        public virtual City City1 { get; set; }

        public virtual Country Country1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Transactions> Order_Transactions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Shopping_Cart> Shopping_Cart { get; set; }
    }
}
