using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TerrageApi.Models
{
    public class Clan
    {
        /*
         * Clan Information
         */
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public string? Description { get; set; }
        public ICollection<ClanTag>? Tags { get; set; }
        
        /*
         * Clan members
         */
        public User Owner { get; set; }
        public ICollection<User>? Members { get; set; }
        /*
         * Game Data
         */
        public int Level { get; set; }
        public int Experience { get; set; }
        public bool IsPublic { get; set; }
        public DateTime LastActivityDate { get; set; }
        //Activity name
    }

    public enum ClanTag
    {
        PvP,
        PvE,
        Casual,
        Hardcore,
        Roleplaying,
        Competitive,
        Social,
        BeginnerFriendly,
        Veteran
    }
}
