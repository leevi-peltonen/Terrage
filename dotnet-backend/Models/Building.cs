using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TerrageApi.Models
{
    public class Building
    {
        /*
         * Information
         */
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Village>? Villages { get; set; }

        /*
         * Game Data
         */

        public int Level { get; set; }
        public int MaxLevel { get; set; }
        public int UpgradeCost { get; set; }
        public int ConstructionTime { get; set; }
        public int? PopulationCapacity { get; set; }
        public int? ResourceProduction { get; set; }
        public int? ResourceCapacity { get; set; }
        public Dictionary<BuildingType, int>? RequiredBuildings { get; set; }
        public int? RequiredPlayerLevel { get; set; }
        public bool IsUnderConstruction { get; set; }
        public DateTime? ConstructionCompletionTime { get; set; }
        public BuildingType BuildingType { get; set; }
    }

    public enum BuildingType
    {
        House,
        Farm,
        Sawmill,
        Quarry,
        Mine,
        Marketplace,
        Smithy,
        Workshop,
        TrainingGrounds,
        HealingHut,
        Library,
        Barracks,
        Watchtower,
        Temple,
        MageTower,
        Stables,
        Tavern,
        Academy,
        FishingHut,
        LumberMill,
        Granary,
        Warehouse,
        Windmill,
        GuardPost,
        University
    }
}
