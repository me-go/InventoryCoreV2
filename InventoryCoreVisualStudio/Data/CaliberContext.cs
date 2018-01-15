using InventoryCoreVisualStudio.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryCoreVisualStudio.Data
{
    public class CaliberContext : DbContext
    {
        public CaliberContext (DbContextOptions<CaliberContext> options)
            : base(options)
        {
        }

        

        public DbSet<Caliber> Caliber { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }

    }
}
