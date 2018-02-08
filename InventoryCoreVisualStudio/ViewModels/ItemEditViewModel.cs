using InventoryCoreVisualStudio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryCoreVisualStudio.ViewModels
{
    public class ItemEditViewModel
    {
        public int Id { get; set; }
        public string Name
        {
            get
            {
                return SelectedManufacturer != null ? SelectedManufacturer.Name + " " + Model : Model;
            }
        }
        public Manufacturer SelectedManufacturer { get; set; }
        public IEnumerable<Manufacturer> Manufacturers { get; set; }
        public string Model { get; set; }
        public string PartNumber { get; set; }
        public Caliber SelectedCaliber { get; set; }
        public IEnumerable<Caliber> Calibers { get; set; }
        public Category SelectedCategory { get; set; }
        public IEnumerable<Category> Categorys { get; set; }
        public FiringAction SelectedFiringAction { get; set; }
        public IEnumerable<FiringAction> Actions { get; set; }
        public Platform SelectedPlatform { get; set; }
        public IEnumerable<Platform> Platforms { get; set; }
        public string Color { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public decimal PurchasePrice { get; set; }
        public string PurchaseFrom { get; set; }
        public Retailer SelectedRetailer { get; set; }
        public IEnumerable<Retailer> Retailers { get; set; }
        public decimal? ListPrice { get; set; }
        public Location SelectedLocation { get; set; }
        public IEnumerable<Location> Locations { get; set; }
        public string SerialNumber { get; set; }
        public decimal? Weight { get; set; }
        public string WeightUnitOfMeasure { get; set; }
        public DateTime? SoldDate { get; set; }
        public string SoldTo { get; set; }
        public decimal? SoldPrice { get; set; }
        public List<Part> Parts { get; set; }

    }
}
