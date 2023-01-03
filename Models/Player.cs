using System.ComponentModel.DataAnnotations;

namespace GameDataApp.Models
{
    public class Player
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        public string Password { get; set; }

        // Foreign Key
        public int InventoryId { get; set; }
        // Navigation property
        public Inventory Inventory { get; set; }
    }
}
