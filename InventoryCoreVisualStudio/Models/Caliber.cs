using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryCoreVisualStudio.Models
{
    public class Caliber
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal DecimalSize { get; set; }
        public string MetricSize { get; set; }
    }
}
