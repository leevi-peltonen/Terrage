using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TerrageApi.Models
{
    public class Armor : Item
    {
        public int Defense { get; set; }
        public Material Material { get; set; }
        public ArmorSlot ArmorSlot { get; set; }
        
    }

    public enum ArmorSlot
    {
        Head,
        Body,
        Hands,
        Legs,
        Feet
    }
}
