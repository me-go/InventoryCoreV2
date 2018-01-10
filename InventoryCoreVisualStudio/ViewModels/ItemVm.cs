using InventoryCoreVisualStudio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryCoreVisualStudio.ViewModels
{
    public class ItemVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public int ManufacturerId { get; set; }
        public string Model { get; set; }
        public string PartNumber { get; set; }
        public virtual Caliber Caliber { get; set; }
        public int CaliberId { get; set; }
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
        public virtual FiringAction FiringAction { get; set; }
        public int ActionId { get; set; }
        public virtual Platform Platform { get; set; }
        public int PlatformId { get; set; }
        public string Color { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal PurchasePrice { get; set; }
        public string PurchaseFrom { get; set; }
        public virtual Retailer Retailer { get; set; }
        public int? RetailerId { get; set; }
        public decimal ListPrice { get; set; }
        public virtual Location Location { get; set; }
        public int LocationId { get; set; }
        public string SerialNumber { get; set; }
        public decimal Weight { get; set; }
        public string WeightUnitOfMeasure { get; set; }
        public DateTime SoldDate { get; set; }
        public string SoldTo { get; set; }
        public decimal SoldPrice { get; set; }
        public List<Part> Parts { get; set; }

    }
}
