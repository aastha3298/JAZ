namespace JAZ.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Shopping_Cart = new HashSet<Shopping_Cart>();
        }

        public int ID { get; set; }

        [StringLength(255)]
        public string Product_Name { get; set; }

        public int? Product_Category { get; set; }

        [StringLength(255)]
        public string Product_Created_By { get; set; }

        public int? Product_Qantity { get; set; }

        public bool? Product_Availability { get; set; }

        public decimal? Product_Price { get; set; }

        [StringLength(255)]
        public string Product_Material { get; set; }

        [StringLength(255)]
        public string Product_Imgage_Source { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Shopping_Cart> Shopping_Cart { get; set; }

        public virtual Product_Category Product_Category1 { get; set; }
    }
}
