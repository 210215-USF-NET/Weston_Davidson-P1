using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace StoreData
{
    public class StoreDBContext : IdentityDbContext<ApplicationUser>
    {

        public StoreDBContext(DbContextOptions options) : base(options)
        {

        }

        public StoreDBContext()
        {

        }


        public DbSet<ApplicationUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartProducts> CartProducts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<LocationProduct> LocationProducts { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProducts> OrderProducts { get; set; }
        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);


            //THIS WILL LET US HAVE A SELF INCREMENTING PRIMARY KEY WHEN OUR DB IS BUILT
            //cart PK auto gen
            modelBuilder.Entity<Cart>()
                .Property(x => x.ID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<CartProducts>()
                .Property(x => x.ID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Customer>()
                .Property(x => x.ID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<LocationProduct>()
                .Property(x => x.ID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Location>()
                .Property(x => x.ID)
                .ValueGeneratedOnAdd();


            modelBuilder.Entity<Order>()
                .Property(x => x.ID)
                .ValueGeneratedOnAdd();


            modelBuilder.Entity<OrderProducts>()
                .Property(x => x.ID)
                .ValueGeneratedOnAdd();


            modelBuilder.Entity<Product>()
                .Property(x => x.ID)
                .ValueGeneratedOnAdd();


            //customer has a one to many relationship with cart
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Carts)
                    .WithOne(c => c.Customer)
                    .OnDelete(DeleteBehavior.Cascade);

            //customer has a one to many relationship with orders
            //one customer can have many orders, but an order can only belong to one customer.
            //if a customer account is deleted, then we should set the order customer to a null value?
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Orders)
                .WithOne(o => o.Customer)
                .OnDelete(DeleteBehavior.SetNull);

            //cart time!
            //cart already has it's relationship with customer defined previously
            //show that join table reference the other two tables
            modelBuilder.Entity<CartProducts>()
                .HasKey(cp => new { cp.CartID, cp.ProductID });
            //build the one to many relationships between the product and cart tables to the cartproducts table
            modelBuilder.Entity<CartProducts>()
                .HasOne(cp => cp.Product)
                .WithMany(p => p.CartProducts)
                .HasForeignKey(cp => cp.ProductID);
            modelBuilder.Entity<CartProducts>()
                .HasOne(cp => cp.Cart)
                .WithMany(c => c.CartProducts)
                .HasForeignKey(cp => cp.CartID);


            //location time!
            //a location can have many carts, but a cart can only belong to one location
            //one to many
            modelBuilder.Entity<Location>()
                .HasMany(l => l.Cart)
                .WithOne(c => c.Location)
                .OnDelete(DeleteBehavior.Cascade);

            //a location can have many orders, but an order can only belong to one location
            // one to many
            modelBuilder.Entity<Location>()
                .HasMany(l => l.Orders)
                .WithOne(o => o.Location)
                .OnDelete(DeleteBehavior.SetNull);

            //a location can have many inventories, but only one inventory can belong to a location
            //inventory is a COMPOSITE TABLE BETWEEN PRODUCT AND LOCATION
            //show that join table references the two other tables
            modelBuilder.Entity<LocationProduct>()
                .HasKey(lp => new { lp.LocationID, lp.ProductID });
            //build the one to many relationship between the location and the locationProducts, as well as the product to locationProducts
            //product to locationproducts
            modelBuilder.Entity<LocationProduct>()
                .HasOne(lp => lp.Product)
                .WithMany(p => p.LocationProducts)
                .HasForeignKey(lp => lp.ProductID);
            //location to locationproduct next
            modelBuilder.Entity<LocationProduct>()
                .HasOne(lp => lp.Location)
                .WithMany(l => l.LocationProducts)
                .HasForeignKey(lp => lp.LocationID);



            // orders are up next!!

            // we only need to define the orders to orderproducts relationships still, along with the product to orderproducts

            //show that orderproducts table has fk references to order id and product id
            modelBuilder.Entity<OrderProducts>()
                .HasKey(op => new { op.OrderID, op.ProductID });

            //build the onte to many relationships between order and orderproducts, as well as product and orderproducts
            modelBuilder.Entity<OrderProducts>()
                .HasOne(op => op.Order)
                .WithMany(o => o.OrderProducts)
                .HasForeignKey(op => op.OrderID);
            //next, product and orderproducts
            modelBuilder.Entity<OrderProducts>()
                .HasOne(op => op.Product)
                .WithMany(p => p.OrderProducts)
                .HasForeignKey(op => op.ProductID);

            modelBuilder.Entity<Customer>()
                .HasOne(c => c.ApplicationUser)
                .WithOne(a => a.Customer)
                .HasForeignKey<Customer>(c => c.AppUserFK);


            /*

            //TEMPLATES FOR DIFFERENT RELATIONSHIP TYPES - provided at :
            //a company has many employees, and each employee only has one company
            //one to many relationship
            modelBuilder.Entity<Company>()
                .HasMany(c => c.Employees)
                   .WithOne(e => e.Company)
                   .OnDelete(DeleteBehavior.Cascade);


            //one author has only one biography
            //one to one
            modelBuilder.Entity<Author>()
                .HasOne(a => a.Biography)
                .WithOne(b => b.Author)
                .HasForeignKey<AuthorBiography>(b => b.AuthorRef);
            

            //a book can belong in many categories, and a category can have many books
            //many to many example
            //show that table has fk references to both other tables
            modelBuilder.Entity<BookCategory>()
            .HasKey(bc => new { bc.BookId, bc.CategoryId });
            //show the one to many relationships between the individual tables that need the join table
            modelBuilder.Entity<BookCategory>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.BookCategories)
                .HasForeignKey(bc => bc.BookId);
            modelBuilder.Entity<BookCategory>()
                .HasOne(bc => bc.Category)
                .WithMany(c => c.BookCategories)
                .HasForeignKey(bc => bc.CategoryId);

            //you can add seed data here, but it's probably easier to add it db side rather than in modelbuild
            */
        }

    }
}
