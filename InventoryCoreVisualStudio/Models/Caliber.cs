using System.ComponentModel.DataAnnotations;

namespace InventoryCoreVisualStudio.Models
{
    public class Caliber
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Decimal Size")]
        [DisplayFormat(DataFormatString ="{0:0.0000}")]
        public decimal DecimalSize { get; set; }

        [Display(Name = "Metric Size")]
        public string MetricSize { get; set; }
    }
}
