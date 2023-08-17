using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TerraVillageAPI.Models
{
    public class Inventory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        /*
         * Owner of the inventory
         */
        public User User { get; set; }
        /*
         * Inventory Specs
         */
        public int InventorySize { get; set; }
        public int MaxStackSize { get; set; }
        /*
         * Inventory Data
         */
        public ICollection<Item>? Items { get; set; }
        public int Gold { get; set; }
    }
}
