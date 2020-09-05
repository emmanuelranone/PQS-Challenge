using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PQS.FSChalenge.Business.Models
{
    public partial class FSChalengeContext : DbContext
    {
        public FSChalengeContext()
        {
        }

        public FSChalengeContext(DbContextOptions<FSChalengeContext> options)
            : base(options)
        {
        }

        // genera las clases necesarias utilizando el concepto de database first

        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OrdersItems> OrdersItems { get; set; }
        public DbQuery<OrderInfo> OrderInfo { get; set; } // utilizo para la vista

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=EMMANUEL-PC\\SQLEXPRESS;Initial Catalog=FSChalenge;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.ToTable("ORDERS");

                entity.HasIndex(e => e.Status)
                    .HasName("IX_ORDER_Status");

                entity.Property(e => e.AuthDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OrderDescription)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<OrdersItems>(entity =>
            {
                entity.HasKey(e => e.OrderItemId)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("ORDERS_ITEMS");

                entity.HasIndex(e => e.OrderId)
                    .HasName("IX_ORDER_ITEMS_OrderId")
                    .ForSqlServerIsClustered();

                entity.Property(e => e.ItemDescription)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UnitPrice).HasColumnType("numeric(32, 2)");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrdersItems)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ORDERS_IT__Order__3B75D760");
            });

            modelBuilder.Query<OrderInfo>().ToView("vORDERS_INFO");
        }
    }
}
