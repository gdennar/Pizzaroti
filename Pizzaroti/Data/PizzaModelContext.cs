using Microsoft.EntityFrameworkCore;
using Pizzaroti.Models;

namespace Pizzaroti.Data
{
    public class PizzaModelContext : DbContext
    {
        public PizzaModelContext(DbContextOptions<PizzaModelContext> options) : base(options)
        {
        }

        public DbSet<PizzasModel> PizzaModel {get; set;}

        public DbSet<PizzaOrder> PizzaOrders { get; set; }

        public DbSet<TransactionModel> Transactions { get; set; }



    }
}
