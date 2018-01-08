using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryCoreVisualStudio.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryCoreVisualStudio.Models
{
    public class CaliberContext : DbContext
    {
        public CaliberContext (DbContextOptions<CaliberContext> options)
            : base(options)
        {
        }

        public DbSet<Caliber> Caliber { get; set; }

    }
}
