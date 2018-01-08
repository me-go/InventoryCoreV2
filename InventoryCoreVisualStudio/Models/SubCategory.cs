using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryCoreVisualStudio.Models
{
    public class SubCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
