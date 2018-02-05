using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryCoreVisualStudio.Models
{
    public class Location
    {
        public int Id { get; set; }
        [RegularExpression(@"[a-zA-Z""'\s-]*$"), Required, StringLength(30)]
        public string Name { get; set; }
    }
}
