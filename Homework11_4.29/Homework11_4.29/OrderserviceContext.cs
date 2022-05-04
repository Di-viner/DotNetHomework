using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Task1;
using MySql.Data.EntityFramework;

namespace Homework11_4._29
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class OrderserviceContext: DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrdersDetails { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public OrderserviceContext():base("OrderDataBase")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<OrderserviceContext>());
        }
    }
}
