using System.ComponentModel.DataAnnotations;

namespace GameDataApp.Models
{
    public class Player
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Numele de utilizator este obligatoriu.")]
        [MaxLength(20, ErrorMessage = "Lungimea campului e prea mare.")]
        public string Username { get; set; }

        [MaxLength(20, ErrorMessage = "Lungimea campului e prea mare.")]
        public string Password { get; set; }

        // Foreign Key
        //public int InventoryId { get; set; }
        // Navigation property
        public Inventory Inventory { get; set; }
    }
}
