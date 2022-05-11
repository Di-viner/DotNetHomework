using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task1;
using Microsoft.EntityFrameworkCore;

namespace Homework12_5._7
{
    public class OrderServiceContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Cargo> Cargos { get; set; }

        public OrderServiceContext(DbContextOptions<OrderServiceContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
