using System.ComponentModel.DataAnnotations;

namespace GameDataApp.Models
{
    public class Quest
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Reward { get; set; }
    }
}
