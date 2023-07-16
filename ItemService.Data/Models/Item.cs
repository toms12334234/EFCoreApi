using System.ComponentModel.DataAnnotations;

namespace ItemService.Data.Models
{
    public class Item
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}