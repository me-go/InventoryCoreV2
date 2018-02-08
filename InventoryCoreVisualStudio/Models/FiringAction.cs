using System.ComponentModel.DataAnnotations;

namespace InventoryCoreVisualStudio.Models
{
    public class FiringAction
    {
        public int Id { get; set; }
        [RegularExpression(@"[a-zA-Z""'\s-]*$"), Required, StringLength(30)]
        public string Name { get; set; }
    }
}