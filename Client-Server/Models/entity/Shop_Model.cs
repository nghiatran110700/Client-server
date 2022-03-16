using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Client_Server.Models.entity
{
    public partial class Shop_Model : DbContext
    {
        public Shop_Model()
            : base("name=Shop_Model")
        {
        }

        public virtual DbSet<account> accounts { get; set; }
        public virtual DbSet<bill> bills { get; set; }
        public virtual DbSet<brand> brands { get; set; }
        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<detailBill> detailBills { get; set; }
        public virtual DbSet<discout> discouts { get; set; }
        public virtual DbSet<product> products { get; set; }
        public virtual DbSet<slide> slides { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<account>()
                .HasMany(e => e.bills)
                .WithOptional(e => e.account)
                .HasForeignKey(e => e.idDiscount);

            modelBuilder.Entity<brand>()
                .HasMany(e => e.products)
                .WithOptional(e => e.brand)
                .HasForeignKey(e => e.idBrand);

            modelBuilder.Entity<category>()
                .HasMany(e => e.products)
                .WithOptional(e => e.category)
                .HasForeignKey(e => e.idCate);

            //modelBuilder.Entity<detailBill>()
            //    .Property(e => e.size)
            //    .IsFixedLength();
        }
    }
}
