using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TerrageApi.Models
{
    public class Achievement
    {
        /*
         * Achievement Data
         */
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Score { get; set; }

        /*
         * Relationships
         */
        public ICollection<User>? Users { get; set; }

    }
}
