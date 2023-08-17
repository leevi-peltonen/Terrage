using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TerrageApi.Models
{
    public class Village
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public User Owner { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
        public int Level { get; set; }
        public ICollection<Building>? Buildings { get; set; }

    }
}
