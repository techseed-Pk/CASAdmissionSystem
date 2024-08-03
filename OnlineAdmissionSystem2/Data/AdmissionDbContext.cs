using Microsoft.EntityFrameworkCore;
using OnlineAdmissionSystem2.Mappings;

namespace OnlineAdmissionSystem2.Data
{
    public class AdmissionDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress;Database=AdmissionDb2;Trusted_Connection=True;Encrypt=false");

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<UserDataModel> Users { get; set; }
    }
}
