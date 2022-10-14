using System.ComponentModel.DataAnnotations;

namespace Inventory.Models
{
    public class Category
    {
        [Key]
        public int Id_Category { get; set; }
        public string Name { get; set; }
    }
}
