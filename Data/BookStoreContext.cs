using BookStore_01.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_01.Data
{
    public class BookStoreContext : DbContext
    {
        private readonly IConfiguration _config;

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public BookStoreContext(IConfiguration config)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_config["ConnectionStrings:BookStoreContextDB"]);//config.json
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Book>().HasMany(c => c.Authors).WithMany(c => c.Books);
        //    modelBuilder.Entity<Author>().HasMany(c => c.Books).WithMany(c => c.Authors);
        //    //modelBuilder.Entity<Book>(b => { b.HasKey(e => e.Id); b.Property(e => e.Id).ValueGeneratedOnAdd(); });
        //}
    }
}
