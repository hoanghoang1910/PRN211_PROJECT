using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace PRN211_PROJECT.Models
{
    public partial class ProjectPRN211Context : DbContext
    {
        public ProjectPRN211Context()
        {
        }

        public ProjectPRN211Context(DbContextOptions<ProjectPRN211Context> options)
            : base(options)
        {
        }

        public virtual DbSet<AdminStock> AdminStocks { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<LoginInfo> LoginInfos { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<NotifyType> NotifyTypes { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<SaleDetail> SaleDetails { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<StoreStock> StoreStocks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder().AddJsonFile("AppConfig.json").Build();
                optionsBuilder.UseSqlServer(config.GetConnectionString("PRN221-Hoang"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AdminStock>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.ToTable("AdminStock");

                entity.Property(e => e.ProductId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Product)
                    .WithOne(p => p.AdminStock)
                    .HasForeignKey<AdminStock>(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AdminStock_Product");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<LoginInfo>(entity =>
            {
                entity.HasKey(e => e.LoginId);

                entity.ToTable("Login_info");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.ToTable("Notification");

                entity.Property(e => e.NotiDate).HasColumnType("datetime");

                entity.HasOne(d => d.NotiFromNavigation)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.NotiFrom)
                    .HasConstraintName("FK_Notification_Store");

                entity.HasOne(d => d.NotiTypeNavigation)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.NotiType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Notification_NotifyType");
            });

            modelBuilder.Entity<NotifyType>(entity =>
            {
                entity.HasKey(e => e.NotiTypeId);

                entity.ToTable("NotifyType");

                entity.Property(e => e.NotiTypeId).ValueGeneratedNever();

                entity.Property(e => e.NotiTypeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Category");
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Requests_Product");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Requests_Store");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.Property(e => e.Bill).HasColumnType("money");

                entity.Property(e => e.SaleDate).HasColumnType("datetime");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sales_Store");
            });

            modelBuilder.Entity<SaleDetail>(entity =>
            {
                entity.HasKey(e => new { e.SaleId, e.ProductId });

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.SaleDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SaleDetails_Product");

                entity.HasOne(d => d.Sale)
                    .WithMany(p => p.SaleDetails)
                    .HasForeignKey(d => d.SaleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SaleDetails_Sales");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Store");

                entity.Property(e => e.StoreAddress).IsRequired();

                entity.Property(e => e.StoreName).IsRequired();

                entity.Property(e => e.StorePhoneNumber)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<StoreStock>(entity =>
            {
                entity.HasKey(e => new { e.StoreId, e.ProductId });

                entity.ToTable("StoreStock");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.StoreStocks)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StoreStock_Product");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.StoreStocks)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StoreStock_Store");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
