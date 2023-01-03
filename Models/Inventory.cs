using System.ComponentModel.DataAnnotations;

namespace GameDataApp.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        [Required]
        public int Size { get; set; }
        public IEnumerable<Item> Items { get; set; }

        // Foreign Key
        public int PlayerId { get; set; }
        // Navigation property
        public Player Player { get; set; }
    }
}
