using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TerrageApi.Models
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Rarity Rarity { get; set; }
        public int Value { get; set; }
        public int Amount { get; set; }
        public ICollection<Enemy>? EnemyDropTables { get; set; }
        public ICollection<Inventory>? UserInventories { get; set; }
    }

    public enum Rarity
    {
        Common,
        Uncommon,
        Rare,
        Epic,
        Legendary
    }
    public enum Material
    {
        // Metals
        Wood,
        Copper,
        Tin,
        Bronze,
        Steel,
        Silver,
        Gold,
        Mithril,
        Adamantite,
        DragonScale,
        Crystal,
        VoidMetal,
        Starstone,

        // Cloth
        TatteredCloth,
        FrayedCloth,
        WornCloth,
        PatchedCloth,
        FineCloth,
        EnchantedCloth,
        ResilientCloth,
        LuminousSilk,
        ArcaneWeave,
        EtherealFabric,
        CelestialVeil,
        AstralShroud,
        DivinityRobes,

        //Leathers
        LeatherHide,
        ReinforcedLeather,
        HardenedQuilt,
        Steelweave,
        ShadowSilk,
        RangersScales,
        Venomweave,
        Frostfur,
        Stormbark,
        Dragonhide,
        CelestialVeins,
        AbyssalScales,
        PhoenixPlumes
    }
}
