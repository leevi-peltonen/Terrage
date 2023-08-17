namespace TerrageApi.Models
{
    public class Consumable : Item
    {
        public ConsumableType Type { get; set; }
        public int Potency { get; set; }
        public DamageEffect? Effect { get; set; }
    }

    public enum ConsumableType
    {
        Potion,
        Scroll,
        Food
    }
}
