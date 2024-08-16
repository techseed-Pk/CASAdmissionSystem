using Microsoft.EntityFrameworkCore;
using OnlineAdmissionSystem2.Data.Entities;

namespace OnlineAdmissionSystem2.Data
{
    public class AdmissionDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // configure the connection string

            optionsBuilder.UseSqlServer("Server=.\\sqlexpress;Database=AdmissionDb;Trusted_Connection=True;Encrypt=false");

            base.OnConfiguring(optionsBuilder);
        }


        public DbSet<User> Users { get; set; }
    }
}
