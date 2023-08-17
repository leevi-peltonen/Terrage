namespace TerrageApi.Models
{
    public class Weapon : Item
    {
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }
        public int ActionCost { get; set; }
        public bool IsTwoHanded { get; set; }
        public WeaponType WeaponType { get; set; }
        public int Durability { get; set; }
        public Material Material { get; set; }
        public DamageEffect? DamageEffect { get; set; }
    }

    public enum WeaponType
    {
        //Melee
        Sword,
        Axe,
        Mace,
        Dagger,
        Whip,
        Hammer,
        Rapier,
        Scythe,

        //Ranged
        Bow,
        Crossbow,
        ThrowingKnife,

        //Magic
        Staff,
        Wand,
        Gauntlet
    }
}
