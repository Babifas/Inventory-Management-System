using System.ComponentModel.DataAnnotations;

namespace Inventory_Management_System.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
}
