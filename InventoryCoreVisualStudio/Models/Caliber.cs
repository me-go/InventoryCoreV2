using System.ComponentModel.DataAnnotations;

namespace InventoryCoreVisualStudio.Models
{
    public class Caliber
    {
        public int Id { get; set; }
        [RegularExpression(@"[a-zA-Z""'\s-]*$"), Required, StringLength(30)]
        public string Name { get; set; }
        [DisplayFormat(DataFormatString ="{0:0.000}")]
        public decimal DecimalSize { get; set; }
        public string MetricSize { get; set; }
    }
}
