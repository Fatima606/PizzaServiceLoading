using Microsoft.EntityFrameworkCore;
using PizzaServiceLoading.Models;

namespace PizzaServiceLoading.DbComtext
{
    public class PizzaLoading : DbContext
    {
        public PizzaLoading(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Size> Size { get; set; }
        public DbSet<Base> Base { get; set; }
        public DbSet<Toppings> Toppings { get; set; }
        public DbSet<Pizza> Pizza { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<ToppingOrder> ToppingOrder { get; set; }

    }
}
