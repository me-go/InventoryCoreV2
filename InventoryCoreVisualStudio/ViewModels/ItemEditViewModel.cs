using InventoryCoreVisualStudio.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Required]
        public string Model { get; set; }

        public string PartNumber { get; set; }

        [Required]
        public int Caliber { get; set; }
        public IEnumerable<SelectListItem> Calibers { get; set; }

        [Required]
        public int Category { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }

        [Required, Display(Name = "Firing Action")]
        public int FiringAction { get; set; }
        public IEnumerable<SelectListItem> FiringActions { get; set; }

        [Required]
        public int Platform { get; set; }
        public IEnumerable<SelectListItem> Platforms { get; set; }

        [StringLength(20, ErrorMessage ="Color name cannot be longer than 20 Characters")]
        public string Color { get; set; }

        [DataType(DataType.Date), Display(Name = "Purchase Date")]
        [DisplayFormat(DataFormatString ="{0:yyy-MM-dd}", ApplyFormatInEditMode =true)]
        public DateTime? PurchaseDate { get; set; }

        [Required, DataType(DataType.Currency), Column(TypeName = "money"), Display(Name="Purchase Price")]
        public decimal PurchasePrice { get; set; }
        
        [Display(Name="Purchased From")]
        public string PurchaseFrom { get; set; }

        [Required]
        public int Retailer { get; set; }
        public IEnumerable<SelectListItem> Retailers { get; set; }

        public decimal? ListPrice { get; set; }

        [Required, Display(Name = "Storage Location")]
        public int Location { get; set; }
        public IEnumerable<SelectListItem> Locations { get; set; }

        public string SerialNumber { get; set; }

        public decimal? Weight { get; set; }

        [Display(Name="Weight Unit of Measure")]
        public string WeightUnitOfMeasure { get; set; }

        [DataType(DataType.Date), Display(Name = "Sold Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? SoldDate { get; set; }

        public string SoldTo { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal? SoldPrice { get; set; }

        public List<Part> Parts { get; set; }
    }
}
