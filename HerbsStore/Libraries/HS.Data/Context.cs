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



       
   



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);






        }
    }
}
