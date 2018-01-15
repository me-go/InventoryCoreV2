using InventoryCoreVisualStudio.Models;
using InventoryCoreVisualStudio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryCoreVisualStudio.Services
{
    public interface ICaliberData
    {
        IEnumerable<Caliber> GetAll();
        Caliber Get(int? id);
        void Add(Caliber caliber);
    }
    public class InMemoryCaliberData : ICaliberData
    {
        static List<Caliber> _calibers;

        static InMemoryCaliberData()
        {
            _calibers = new List<Caliber>
            {
                new Caliber{ Id=1, Name ="555", DecimalSize = .224M, MetricSize = "5.56 X 45" },
                new Caliber{ Id=2, Name="308", DecimalSize=.308M, MetricSize="7.62 X 51" },
                new Caliber{ Id=3, Name="9mm Luger", DecimalSize=.355M, MetricSize="9 X 19" }
            };
        }

        public void Add(Caliber newCaliber)
        {
            newCaliber.Id = _calibers.Max(c => c.Id) + 1;
            _calibers.Add(newCaliber);
        }

        public Caliber Get(int? id)
        {
            return _calibers.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Caliber> GetAll()
        {
            return _calibers;
        }
    }
}
