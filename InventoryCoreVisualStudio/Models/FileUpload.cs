using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace InventoryCoreVisualStudio.Models
{
    public class FileUpload
    { 
        public string Name { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? PurchaseDate { get; set; }
        [DataType(DataType.Currency)]
        public decimal PurchasePrice { get; set; }
        public decimal? ListPrice { get; set; }
        public string SerialNumber { get; set; }
    }
}
