using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryCoreVisualStudio.Models
{
    public class Part
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public int? ManufacturerId { get; set; }
        public decimal Cost { get; set; }
        public string PartNumber { get; set; }
        public string Description { get; set; }
	    public Item Item { get; set; }
	    public int ItemId { get; set; }

    }
}
