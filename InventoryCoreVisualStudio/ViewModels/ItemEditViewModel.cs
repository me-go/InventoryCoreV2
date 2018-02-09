using InventoryCoreVisualStudio.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
                return ManufacturerObj != null ? ManufacturerObj.Name + " " + Model : Model;
            }
        }

        public int Manufacturer { get; set; }
        public Manufacturer ManufacturerObj { get; set; }
        public IEnumerable<SelectListItem> Manufacturers { get; set; }
        public string Model { get; set; }
        public string PartNumber { get; set; }
        public int Caliber { get; set; }
        public IEnumerable<SelectListItem> Calibers { get; set; }
        public int Category { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        public int FiringAction { get; set; }
        public IEnumerable<SelectListItem> FiringActions { get; set; }
        public int Platform { get; set; }
        public IEnumerable<SelectListItem> Platforms { get; set; }
        public string Color { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public decimal PurchasePrice { get; set; }
        public string PurchaseFrom { get; set; }
        public int Retailer { get; set; }
        public IEnumerable<SelectListItem> Retailers { get; set; }
        public decimal? ListPrice { get; set; }
        public int Location { get; set; }
        public IEnumerable<SelectListItem> Locations { get; set; }
        public string SerialNumber { get; set; }
        public decimal? Weight { get; set; }
        public string WeightUnitOfMeasure { get; set; }
        public DateTime? SoldDate { get; set; }
        public string SoldTo { get; set; }
        public decimal? SoldPrice { get; set; }
        public List<Part> Parts { get; set; }

    }
}
