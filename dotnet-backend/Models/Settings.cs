using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TerraVillageAPI.Models
{
    public class Settings
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        /*
         * Settings owner
         */
        public User User { get; set; }
        /*
         * Settings
         */
        public Language Language { get; set; }
        public CombatDifficulty CombatDifficulty { get; set; }
        public OnlineStatus OnlineStatus { get; set; }
        public bool AllowFriendRequests { get; set; }
        public bool DisableTutorials { get; set; }

    }

    public enum Language
    {
        English,
        Finnish
    }
    public enum CombatDifficulty
    {
        Easy,
        Medium,
        Hard,
        Insane
    }
    public enum OnlineStatus
    {
        Online,
        Offline,
        Away,
        DoNotDisturb
    }
}
