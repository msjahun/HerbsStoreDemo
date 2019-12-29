using HerbsStore.Libraries.HS.Core.Domain.Feedback;
using HerbsStore.Libraries.HS.Core.Domain.Hospitals;
using HerbsStore.Libraries.HS.Core.Domain.Orders;
using HerbsStore.Libraries.HS.Core.Domain.Products;
using HerbsStore.Libraries.HS.Core.Domain.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HerbsStore.Libraries.HS.Data
{
    public partial class Context : IdentityDbContext<User, UserRole, string>
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }



        public virtual DbSet<Feedback> Feedback{ get; set; }
        public virtual DbSet<Hospital> Hospitals{ get; set; }
        public virtual DbSet<Product> Products{ get; set; }
        public virtual DbSet<Cart> Carts{ get; set; }
        public virtual DbSet<Order> Orders{ get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);






        }
    }
}
