using InventoryCoreVisualStudio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryCoreVisualStudio.Data
{
    public interface ICaliberRepository : IDisposable
    {
        IEnumerable<Caliber> GetCaliber();
        Caliber GetByIdNotracking(int? id);
        void InsertCaliber(Caliber caliber);
        void DeleteCaliber(int id);
        void UpdateCaliber(Caliber caliber);
        void Save();
    }
}
