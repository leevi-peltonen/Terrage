using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TerrageApi.Models
{
    public class DamageEffect
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public EffectType EffectType { get; set; }
        public int Potency { get; set; }
        public int Duration { get; set; }
        public decimal Chance { get; set; }
        public ICollection<Enemy>? Enemies { get; set; }
    }

    public enum EffectType
    {  
        None,
        Leech,
        DamageOverTime,
        Critical,
        Debilitate
    }
}
