using Microsoft.EntityFrameworkCore;
using PizzaPalace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPalace.Persistence.Context
{
    public class AppDbContext:DbContext
    {
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Topping> Toppings { get; set; }

        public DbSet<Pizza> Pizzas { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetails> OrderDetails { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<Size>().ToTable("Sizes");
            builder.Entity<Size>().HasKey(p => p.Id);
            builder.Entity<Size>().Property(p => p.Name).IsRequired();
            builder.Entity<Size>().Property(p => p.Price).IsRequired();

            builder.Entity<Size>().HasData
            (
                new Size { Id = "Small", Name = "Small", Price = 12 },
                new Size { Id = "Medium", Name = "Medium", Price = 14 },
                new Size { Id = "Large", Name = "Large", Price = 16 }
            );

            builder.Entity<Topping>().ToTable("Toppings");
            builder.Entity<Topping>().HasKey(p => p.Id);
            builder.Entity<Topping>().Property(p => p.Name).IsRequired();

            builder.Entity<Topping>().HasData
           (
               new Topping { Id = "Cheese", Name = "Cheese"},
               new Topping { Id = "Pepperoni", Name = "Pepperoni"},
               new Topping { Id = "Ham", Name = "Ham"},
               new Topping { Id = "Pineapple", Name = "Pineapple"},
               new Topping { Id = "Sausage", Name = "Sausage"},
               new Topping { Id = "FetaCheese", Name = "Feta Cheese"},
               new Topping { Id = "Tomatoes", Name = "Tomatoes"},
               new Topping { Id = "Olives", Name = "Olives"}
           );


            builder.Entity<Pizza>().ToTable("Pizzas");
            builder.Entity<Pizza>().HasKey(p => p.Id);
            builder.Entity<Pizza>().Property(p => p.Size).IsRequired();
            builder.Entity<Pizza>().Property(p => p.Topping).IsRequired();
            builder.Entity<Pizza>().Property(p => p.Price).IsRequired();

            builder.Entity<Pizza>().HasData
           (
               new Pizza { Id="1", Size="Small", Topping = "Cheese", Price =0.50f},
               new Pizza { Id = "2", Size = "Medium", Topping = "Cheese", Price = 0.75f },
               new Pizza { Id = "3", Size = "Large", Topping = "Cheese", Price = 1.00f },
                new Pizza { Id = "4", Size = "Small", Topping = "Pepperoni", Price = 0.50f },
               new Pizza { Id = "5", Size = "Medium", Topping = "Pepperoni", Price = 0.75f },
               new Pizza { Id = "6", Size = "Large", Topping = "Pepperoni", Price = 1.00f },
                new Pizza { Id = "7", Size = "Small", Topping = "Ham", Price = 0.50f },
               new Pizza { Id = "8", Size = "Medium", Topping = "Ham", Price = 0.75f },
               new Pizza { Id = "9", Size = "Large", Topping = "Ham", Price = 1.00f },
                new Pizza { Id = "10", Size = "Small", Topping = "Pineapple", Price = 0.50f },
               new Pizza { Id = "11", Size = "Medium", Topping = "Pineapple", Price = 0.75f },
               new Pizza { Id = "12", Size = "Large", Topping = "Pineapple", Price = 1.00f },
                new Pizza { Id = "13", Size = "Small", Topping = "Sausage", Price = 2.00f },
               new Pizza { Id = "14", Size = "Medium", Topping = "Sausage", Price = 3.00f },
               new Pizza { Id = "15", Size = "Large", Topping = "Sausage", Price = 4.00f },
                new Pizza { Id = "16", Size = "Small", Topping = "FetaCheese", Price = 2.00f },
               new Pizza { Id = "17", Size = "Medium", Topping = "FetaCheese", Price = 3.00f },
               new Pizza { Id = "18", Size = "Large", Topping = "FetaCheese", Price = 4.00f },
                new Pizza { Id = "19", Size = "Small", Topping = "Tomatoes", Price = 2.00f },
               new Pizza { Id = "20", Size = "Medium", Topping = "Tomatoes", Price = 3.00f },
               new Pizza { Id = "21", Size = "Large", Topping = "Tomatoes", Price = 4.00f },
                new Pizza { Id = "22", Size = "Small", Topping = "Olives", Price = 2.00f },
               new Pizza { Id = "23", Size = "Medium", Topping = "Olives", Price = 3.00f },
               new Pizza { Id = "24", Size = "Large", Topping = "Olives", Price = 4.00f }

           );

            builder.Entity<Order>().ToTable("Orders");
            builder.Entity<Order>().HasKey(p => p.Id);
            builder.Entity<Order>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Order>().Property(p => p.SubTotal).IsRequired();
            builder.Entity<Order>().Property(p => p.Total).IsRequired();


            builder.Entity<OrderDetails>().ToTable("OrderDetails");
            builder.Entity<OrderDetails>().HasKey(p => p.Id);
            builder.Entity<OrderDetails>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<OrderDetails>().Property(p => p.OrderId).IsRequired();
            builder.Entity<OrderDetails>().Property(p => p.Toppings).IsRequired();
            builder.Entity<OrderDetails>().Property(p => p.Size).IsRequired();
            builder.Entity<OrderDetails>().Property(p => p.UnitPrice).IsRequired();
            builder.Entity<OrderDetails>().Property(p => p.Units).IsRequired();
            builder.Entity<OrderDetails>().Property(p => p.Total).IsRequired();




        }
    }
}
