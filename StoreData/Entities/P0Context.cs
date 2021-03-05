using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace StoreData.Entities
{
    public partial class P0Context : DbContext
    {
        public P0Context()
        {
        }

        public P0Context(DbContextOptions<P0Context> options)
            : base(options)
        {
            
        }

        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Cartproduct> Cartproducts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Orderitem> Orderitems { get; set; }
        public virtual DbSet<OrlandoView> OrlandoViews { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<TampaView> TampaViews { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("cart");

                entity.Property(e => e.CartId).HasColumnName("cart_id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__cart__customer_i__66603565");
            });

            modelBuilder.Entity<Cartproduct>(entity =>
            {
                entity.HasKey(e => e.CartProductsId)
                    .HasName("PK__cartprod__774210A8984322FB");

                entity.ToTable("cartproducts");

                entity.Property(e => e.CartProductsId).HasColumnName("cart_products_id");

                entity.Property(e => e.CartId).HasColumnName("cart_id");

                entity.Property(e => e.InventoryId).HasColumnName("inventory_id");

                entity.Property(e => e.ProductCount).HasColumnName("product_count");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.Cartproducts)
                    .HasForeignKey(d => d.CartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__cartprodu__cart___6E01572D");

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.Cartproducts)
                    .HasForeignKey(d => d.InventoryId)
                    .HasConstraintName("FK__cartprodu__inven__6FE99F9F");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Cartproducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__cartprodu__produ__6EF57B66");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.CustomerFname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("customer_fname");

                entity.Property(e => e.CustomerLname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("customer_lname");

                entity.Property(e => e.CustomerPasswordhash)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("customer_passwordhash");

                entity.Property(e => e.CustomerUsername)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("customer_username");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("inventory");

                entity.Property(e => e.InventoryId).HasColumnName("inventory_id");

                entity.Property(e => e.InventoryName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("inventory_name");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.ProductQuantity).HasColumnName("product_quantity");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__inventory__locat__628FA481");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__inventory__produ__6383C8BA");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("location");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.LocationAddress)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("location_address");

                entity.Property(e => e.LocationName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("location_name");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.CartId).HasColumnName("cart_id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasColumnName("order_date");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__orders__cart_id__74AE54BC");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__orders__customer__73BA3083");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__orders__location__72C60C4A");
            });

            modelBuilder.Entity<Orderitem>(entity =>
            {
                entity.HasKey(e => e.OrderItemsId)
                    .HasName("PK__orderite__7529155558475ECA");

                entity.ToTable("orderitems");

                entity.Property(e => e.OrderItemsId).HasColumnName("order_items_id");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.OrderItemQuantity).HasColumnName("order_item_quantity");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Orderitems)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__orderitem__order__04E4BC85");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Orderitems)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__orderitem__produ__05D8E0BE");
            });

            modelBuilder.Entity<OrlandoView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("orlandoView");

                entity.Property(e => e.InventoryId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("inventory_id");

                entity.Property(e => e.InventoryName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("inventory_name");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.ProductQuantity).HasColumnName("product_quantity");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Manufacturer)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("manufacturer");

                entity.Property(e => e.ProductDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("product_description");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("product_name");

                entity.Property(e => e.ProductPrice)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("product_price");
            });

            modelBuilder.Entity<TampaView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("tampaView");

                entity.Property(e => e.InventoryId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("inventory_id");

                entity.Property(e => e.InventoryName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("inventory_name");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.ProductQuantity).HasColumnName("product_quantity");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
