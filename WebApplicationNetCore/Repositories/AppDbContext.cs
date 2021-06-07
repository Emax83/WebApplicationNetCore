using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationNetCore.Models;

namespace WebApplicationNetCore.Repositories
{

    //aggiungi pacchetto. nuget : Microsoft.EntityFrameworkCore.SqlServer
    //aggiungi riferimento using Microsoft.EntityFrameworkCore;
    //crea classe AppDbContext : DbContext
    //adding entity framework service --> vedi 1) appsettings.json per la connection.
    //startup.cs -->  services.addDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
    //aggiungi properties DbSets


    //public class AppDbContext : DbContext
    public class AppDbContext : IdentityDbContext<IdentityUser> //identitydb
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Pie> Pies { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed default datas..

            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 1, CategoryName = "Category1", Description = "The best category" });

            modelBuilder.Entity<Pie>().HasData(new Pie { CategoryId = 1, PieId = 1, Name = "Pie1", ShortDescription = "The Pie 1", LongDescription = "", Price = 5.99M, InStock = true, IsPieOfTheWeek = true });
            modelBuilder.Entity<Pie>().HasData(new Pie { CategoryId = 1, PieId = 2, Name = "Pie2", ShortDescription = "The Pie 2", LongDescription = "", Price = 7.99M, InStock = true, IsPieOfTheWeek = false });



        }

    }
}
