using System.ComponentModel.DataAnnotations;

namespace GameDataApp.Models
{
    public class Item
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Numele este obligatoriu.")]
        [MaxLength(255, ErrorMessage = "Lungimea campului e prea mare.")]
        public string Name { get; set; }

        [MaxLength(255, ErrorMessage = "Lungimea campului e prea mare.")]
        public string Description { get; set; }
        public bool IsUsable { get; set; }
    }
}
