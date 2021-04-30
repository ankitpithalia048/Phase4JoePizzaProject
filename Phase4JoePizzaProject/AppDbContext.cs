using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phase4JoePizzaProject
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext()
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<PizzaModel> PizzaModel { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
    }
}
