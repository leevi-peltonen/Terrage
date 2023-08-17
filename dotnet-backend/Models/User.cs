using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TerrageApi.Models
{
    public class User
    {
        /*
         * Personal information
         */
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string? Email { get; set; }

        /*
         * Game data
         */
        public Inventory Inventory { get; set; }
        public ICollection<Achievement>? Achievements { get; set; }
        public int AchievementScore { get; set; }
        public Settings Settings { get; set; }
        public Village Village { get; set; }

        /*
         * Social
         */
        public ICollection<User>? Friends { get; set; }
        public Clan? Clan { get; set; }
        public bool? IsClanOwner { get; set; }
    }
}
