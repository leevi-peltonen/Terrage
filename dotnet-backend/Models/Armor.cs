using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TerraVillageAPI.Models
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
