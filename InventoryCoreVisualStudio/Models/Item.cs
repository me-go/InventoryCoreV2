﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryCoreVisualStudio.Models
{
    public class Item
    {
        public int Id { get; set; }

        public string Name { get {
                return Manufacturer != null ? Manufacturer.Name + " " + Model : Model;
            } }

        public virtual Manufacturer Manufacturer { get; set; }

        public int ManufacturerId { get; set; }

        public string Model { get; set; }

        public string PartNumber { get; set; }

        public virtual Caliber Caliber { get; set; }

        public int CaliberId { get; set; }

        public virtual Category Category { get; set; }

        public int? CategoryId { get; set; }

        public virtual FiringAction FiringAction { get; set; }

        public int? FiringActionId { get; set; }

        public virtual Platform Platform { get; set; }

        public int PlatformId { get; set; }

        [StringLength(20, ErrorMessage = "Color name cannot be longer thatn 20 characters")]
        public string Color { get; set; }

        [DataType(DataType.Date), Display(Name = "Purchase Date")]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? PurchaseDate { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal PurchasePrice { get; set; }

        public string PurchaseFrom { get; set; }

        public virtual Retailer Retailer { get; set; }

        public int? RetailerId { get; set; }

        public decimal? ListPrice { get; set; }

        public virtual Location Location { get; set; }

        [Display(Name = "Storage Location")]
        public int LocationId { get; set; }

        public string SerialNumber { get; set; }

        public decimal? Weight { get; set; }

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
