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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required(ErrorMessage ="Field is mandatory")]
        [RegularExpression(@"^([a-zA-Z \.\&\'\-]+)$", ErrorMessage = "Field should not contain any special character or digit ")]
        [StringLength(255)]
        public string First_Name { get; set; }
        [Required(ErrorMessage = "Field is mandatory")]
        [RegularExpression(@"^([a-zA-Z \.\&\'\-]+)$", ErrorMessage = "Field should not contain any special character or digit ")]
        [StringLength(255)]
        public string Last_Name { get; set; }

        [Required(ErrorMessage = "Field is mandatory")]
        [EmailAddress(ErrorMessage = "Invalid Email address")]
        [StringLength(255)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Field is mandatory")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Phone number must be valid")]
        [StringLength(255)]
        public string Phone_Number { get; set; }
        
        [DataType(DataType.Password)]
        [StringLength(255)]
        public string Password { get; set; }

        [StringLength(255)]
        public string Role { get; set; }
        [Required(ErrorMessage = "Field is mandatory")]
        [StringLength(255)]
        public string StAddress { get; set; }
        [Required(ErrorMessage = "Field is mandatory")]
        [RegularExpression(@"^([a-zA-Z \.\&\'\-]+)$", ErrorMessage = "Field should not contain any special character or digit ")]
        [StringLength(255)]
        public string Province { get; set; }
        [Required(ErrorMessage = "Field is mandatory")]
        [RegularExpression(@"^[0-9]{5}$|^[A-Z][0-9][A-Z] ?[0-9][A-Z][0-9]$", ErrorMessage = "PostalCode can be either US or CANADA")]
        [StringLength(255)]
        public string PostalCode { get; set; }
        public virtual City City1 { get; set; }
        public int? City { get; set; }
        public int? Country { get; set; }
        public virtual Country Country1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Transactions> Order_Transactions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Shopping_Cart> Shopping_Cart { get; set; }
    }
}
