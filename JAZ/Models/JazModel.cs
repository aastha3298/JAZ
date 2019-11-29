namespace JAZ.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class JazModel : DbContext
    {
        public JazModel()
            : base("name=JazModel")
        {
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Order_Transactions> Order_Transactions { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Product_Category> Product_Category { get; set; }
        public virtual DbSet<Shopping_Cart> Shopping_Cart { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.City1)
                .HasForeignKey(e => e.City);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.Country1)
                .HasForeignKey(e => e.Country);

            modelBuilder.Entity<Order_Transactions>()
                .Property(e => e.Transaction_Total)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Product>()
                .Property(e => e.Product_Price)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Shopping_Cart)
                .WithOptional(e => e.Product)
                .HasForeignKey(e => e.Product_ID);

            modelBuilder.Entity<Product_Category>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Product_Category1)
                .HasForeignKey(e => e.Product_Category);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Order_Transactions)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.User_ID);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Shopping_Cart)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.User_ID);
        }
    }
}
