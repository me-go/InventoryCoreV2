using InventoryCoreVisualStudio.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryCoreVisualStudio.Data
{
    public class InventoryContext: DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options): base(options)
        {
        }

        public DbSet<Caliber> Caliber { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Manufacturer> Manufacturer { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Platform> Platform { get; set; }
        public DbSet<Retailer> Retailer { get; set; }
        public DbSet<FiringAction> FiringAction { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Part>().ToTable("Part");
            modelBuilder.Entity<Item>().ToTable("Item");
            modelBuilder.Entity<Caliber>().Property(c => c.DecimalSize).HasColumnType("decimal(4,3)");
            modelBuilder.Entity<Category>()                
                .HasMany(c => c.Children)
                .WithOne(c => c.Parent)
                .HasForeignKey(c => c.ParentId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            
                
        }

        //	    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //	    {
        //		    optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=InventoryCore;Integrated Security=True;MultipleActiveResultSets=True");
        //	    }        
    }
}
