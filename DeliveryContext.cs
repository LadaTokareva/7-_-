namespace Laba7
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DeliveryContext : DbContext
    {
        public DeliveryContext()
            : base("name=DeliveryContext")
        {
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Delivery> Deliveries { get; set; }
        public virtual DbSet<Provider> Providers { get; set; }
        public virtual DbSet<Shop> Shops { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasMany(e => e.Shops)
                .WithRequired(e => e.City)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Provider>()
                .HasMany(e => e.Deliveries)
                .WithRequired(e => e.Provider)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Shop>()
                .HasMany(e => e.Deliveries)
                .WithRequired(e => e.Shop)
                .WillCascadeOnDelete(false);
        }
    }
}
