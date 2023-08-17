using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TerrageApi.Models
{
    public class Enemy
    {
        /*
         * Basic information
         */
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        /*
         * Game Data
         */
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Level { get; set; }
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }
        public ICollection<DamageEffect>? DamageEffects { get; set; }
        public int Defence { get; set; }
        public int RewardXP { get; set; }
        public ICollection<Item>? DropTable { get; set; }

    }
}
