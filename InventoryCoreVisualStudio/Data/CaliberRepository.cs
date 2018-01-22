using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryCoreVisualStudio.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryCoreVisualStudio.Data
{
    public class CaliberRepository : ICaliberRepository, IDisposable
    {
        private readonly InventoryContext _context;
        private bool disposed = false;

        public CaliberRepository(InventoryContext context)
        {
            _context = context;
        }
        public void DeleteCaliber(int id)
        {
            Caliber caliber = _context.Caliber.Find(id);
            _context.Caliber.Remove(caliber);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Caliber> GetCaliber()
        {
            return _context.Caliber.ToList();
        }

        public Caliber GetCaliberById(int? id)
        {
            return _context.Caliber.Find(id);
        }

        public void InsertCaliber(Caliber caliber)
        {
            _context.Caliber.Add(caliber);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateCaliber(Caliber caliber)
        {
            _context.Entry(caliber).State = EntityState.Modified;
        }
    }
}
