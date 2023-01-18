using System.ComponentModel.DataAnnotations;

namespace GameDataApp.Models
{
    public class Quest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Numele este obligatoriu.")]
        [MaxLength(255, ErrorMessage = "Lungimea campului e prea mare.")]
        public string Name { get; set; }

        [MaxLength(255, ErrorMessage = "Lungimea campului e prea mare.")]
        public string Description { get; set; }

        [MaxLength(255, ErrorMessage = "Lungimea campului e prea mare.")]
        public string Reward { get; set; }
    }
}
