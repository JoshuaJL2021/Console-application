using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DataAccessLogic.Entities
{
    public partial class P0DatabaseContext : DbContext
    {
        public P0DatabaseContext()
        {
        }

        public P0DatabaseContext(DbContextOptions<P0DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<OrderHistory> OrderHistories { get; set; }
        public virtual DbSet<OrdersRecord> OrdersRecords { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<StoreFront> StoreFronts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrderHistory>(entity =>
            {
                entity.HasKey(e => e.ReferenceId)
                    .HasName("PK__OrderHis__E1A99A798589480E");

                entity.ToTable("OrderHistory");

                entity.Property(e => e.ReferenceId).HasColumnName("ReferenceID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.OrderHistories)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__OrderHist__Custo__07C12930");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderHistories)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__OrderHist__Order__06CD04F7");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderHistories)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__OrderHist__Produ__09A971A2");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.OrderHistories)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK__OrderHist__Store__08B54D69");
            });

            modelBuilder.Entity<OrdersRecord>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__OrdersRe__C3905BCF2432D13D");

                entity.Property(e => e.Total).HasColumnType("money");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(16, 2)");
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.HasKey(e => new { e.StoreId, e.ProductId })
                    .HasName("PK__Stock__F0C23C8FFE8CD921");

                entity.ToTable("Stock");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Stock__ProductID__114A936A");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Stock__StoreID__10566F31");
            });

            modelBuilder.Entity<StoreFront>(entity =>
            {
                entity.HasKey(e => e.StoreId)
                    .HasName("PK__StoreFro__3B82F0E1A4CC44F6");

                entity.ToTable("StoreFront");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StoreName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
