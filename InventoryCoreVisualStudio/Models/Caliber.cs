using System.ComponentModel.DataAnnotations;

namespace InventoryCoreVisualStudio.Models
{
    public class Caliber
    {
        public int Id { get; set; }
        [RegularExpression(@"^[0-9A-Za-z ]+$"), Required, StringLength(30)]
        public string Name { get; set; }
        [DisplayFormat(DataFormatString ="{0:0.000}")]
        public decimal DecimalSize { get; set; }
        public string MetricSize { get; set; }
    }
}
