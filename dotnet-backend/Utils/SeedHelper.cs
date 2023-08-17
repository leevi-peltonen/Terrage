using TerraVillageAPI.Models;

namespace TerraVillageAPI.Utils
{
    public static class SeedHelper
    {
        public static ICollection<Achievement> SeedAchievements()
        {
            ICollection<Achievement> achievements = new List<Achievement>
            {
                new Achievement
                {
                    ID = 1,
                    Name = "Novice Gatherer",
                    Description = "Gather your first set of resources.",
                    Score = 10
                },

                new Achievement
                {
                    ID = 2,
                    Name = "Master Miner",
                    Description = "Mine a total of 1,000 minerals.",
                    Score = 50
                },

                new Achievement
                {
                    ID = 3,
                    Name = "Fishing Enthusiast",
                    Description = "Catch 100 fish from different fishing spots.",
                    Score = 30
                },

                new Achievement
                {
                    ID = 4,
                    Name = "Green Thumb",
                    Description = "Harvest a bountiful crop from your farm.",
                    Score = 20
                },

                new Achievement
                {
                    ID = 5,
                    Name = "Wealthy Merchant",
                    Description = "Accumulate 10,000 gold coins in your village's treasury.",
                    Score = 100
                },

                new Achievement
                {
                    ID = 6,
                    Name = "Monster Slayer",
                    Description = "Defeat 100 enemies in combat.",
                    Score = 60
                },

                new Achievement
                {
                    ID = 7,
                    Name = "Village Builder",
                    Description = "Upgrade all buildings to their maximum level in your village.",
                    Score = 150
                },

                new Achievement
                {
                    ID = 8,
                    Name = "Explorer Extraordinaire",
                    Description = "Visit and unlock all locations on the game map.",
                    Score = 120
                },

                new Achievement
                {
                    ID = 9,
                    Name = "Legendary Crafter",
                    Description = "Craft a legendary weapon or armor.",
                    Score = 200
                },

                new Achievement
                {
                    ID = 10,
                    Name = "Community Leader",
                    Description = "Help 50 villagers with their quests or needs.",
                    Score = 80
                },

                new Achievement
                {
                    ID = 11,
                    Name = "Treasure Hunter",
                    Description = "Discover and collect all hidden treasures in the game world.",
                    Score = 180
                },

                new Achievement
                {
                    ID = 12,
                    Name = "Champion of the Arena",
                    Description = "Win 10 consecutive battles in the village arena.",
                    Score = 100
                },

                new Achievement
                {
                    ID = 13,
                    Name = "Alchemist Apprentice",
                    Description = "Brew 50 different potions and elixirs.",
                    Score = 70
                },

                new Achievement
                {
                    ID = 14,
                    Name = "Master of Trade",
                    Description = "Trade with all neighboring villages and unlock exclusive resources.",
                    Score = 110
                },

                new Achievement
                {
                    ID = 15,
                    Name = "Legendary Village",
                    Description = "Achieve the highest level of prosperity and renown for your village.",
                    Score = 250
                }
            };
            return achievements;
        }

        public static ICollection<Weapon> SeedWeapons()
        {
            ICollection<Weapon> weapons = new List<Weapon>
            {
                new Weapon
                {
                    ID = 1,
                    Name = "Bronze Sword",
                    Description = "A basic sword made out of bronze",
                    Rarity = Rarity.Common,
                    Value = 6,
                    Amount = 1,
                    MinDamage = 1,
                    MaxDamage = 5,
                    ActionCost = 1,
                    IsTwoHanded = false,
                    WeaponType = WeaponType.Sword,
                    Durability = 100,
                    Material = Material.Bronze
                },
                new Weapon
                {
                    ID = 2,
                    Name = "Wooden Bow",
                    Description = "A basic bow made out of wood",
                    Rarity = Rarity.Common,
                    Value = 8,
                    Amount = 1,
                    MinDamage = 2,
                    MaxDamage = 6,
                    ActionCost = 2,
                    IsTwoHanded = true,
                    WeaponType = WeaponType.Bow,
                    Durability = 80,
                    Material = Material.Wood
                },
                new Weapon
                {
                    ID = 3,
                    Name = "Silver Dagger",
                    Description = "A sharp dagger made of silver",
                    Rarity = Rarity.Uncommon,
                    Value = 15,
                    Amount = 1,
                    MinDamage = 3,
                    MaxDamage = 7,
                    ActionCost = 1,
                    IsTwoHanded = false,
                    WeaponType = WeaponType.Dagger,
                    Durability = 60,
                    Material = Material.Silver
                },
                new Weapon
                {
                    ID = 5,
                    Name = "Mithril Staff",
                    Description = "A magical staff made of mithril",
                    Rarity = Rarity.Epic,
                    Value = 100,
                    Amount = 1,
                    MinDamage = 5,
                    MaxDamage = 12,
                    ActionCost = 2,
                    IsTwoHanded = true,
                    WeaponType = WeaponType.Staff,
                    Durability = 120,
                    Material = Material.Mithril
                },
                new Weapon
                {
                    ID = 6,
                    Name = "Dragon Scale Rapier",
                    Description = "A legendary rapier crafted from dragon scales",
                    Rarity = Rarity.Legendary,
                    Value = 1000,
                    Amount = 1,
                    MinDamage = 10,
                    MaxDamage = 20,
                    ActionCost = 1,
                    IsTwoHanded = false,
                    WeaponType = WeaponType.Rapier,
                    Durability = 200,
                    Material = Material.DragonScale
                }
            };

            return weapons;
        }

        public static ICollection<Armor> SeedArmor()
        {
            var armor = new List<Armor>
            {
                new Armor
                {
                    ID = 7,
                    Name = "Bronze platebody",
                    Description = "A common platebody made out of bronze",
                    Rarity = Rarity.Common,
                    Value = 20,
                    Amount = 1,
                    Defense = 10,
                    Material = Material.Bronze,
                    ArmorSlot = ArmorSlot.Body
                },
                new Armor
                {
                    ID = 8,
                    Name = "Bronze platelegs",
                    Description = "Common platelegs made out of bronze",
                    Rarity = Rarity.Common,
                    Value = 18,
                    Amount = 1,
                    Defense = 8,
                    Material = Material.Bronze,
                    ArmorSlot = ArmorSlot.Legs
                },
                new Armor
                {
                    ID = 9,
                    Name = "Bronze helm",
                    Description = "A common helm made out of bronze",
                    Rarity = Rarity.Common,
                    Value = 9,
                    Amount = 1,
                    Defense = 5,
                    Material = Material.Bronze,
                    ArmorSlot = ArmorSlot.Head
                },
                new Armor
                {
                    ID = 10,
                    Name = "Bronze gloves",
                    Description = "Common gloves made out of bronze",
                    Rarity = Rarity.Common,
                    Value = 7,
                    Amount = 1,
                    Defense = 2,
                    Material = Material.Bronze,
                    ArmorSlot = ArmorSlot.Hands
                },
                new Armor
                {
                    ID = 11,
                    Name = "Bronze boots",
                    Description = "Common boots made out of bronze",
                    Rarity = Rarity.Common,
                    Value = 7,
                    Amount = 1,
                    Defense = 2,
                    Material = Material.Bronze,
                    ArmorSlot = ArmorSlot.Feet
                }
            };
            return armor;
        }

        public static ICollection<Consumable> SeedConsumables()
        {
            var consumables = new List<Consumable>
            {
                new Consumable
                {
                    ID = 12,
                    Name = "Minor health potion",
                    Description = "Weak potion that gives you some health",
                    Rarity = Rarity.Common,
                    Value = 15,
                    Amount = 1,
                    Type = ConsumableType.Potion,
                    Potency = 10
                },
                new Consumable
                {
                    ID = 13,
                    Name = "Major health potion",
                    Description = "Major potion that gives you a lot of health",
                    Rarity = Rarity.Rare,
                    Value = 125,
                    Amount = 1,
                    Type = ConsumableType.Potion,
                    Potency = 100
                },
                new Consumable
                {
                    ID = 14,
                    Name = "Storm scroll",
                    Description = "Summons a storm upon your enemies",
                    Rarity = Rarity.Common,
                    Value = 50,
                    Amount = 1,
                    Type = ConsumableType.Scroll,
                    Potency = 8
                },
            };
            return consumables;
        }

        public static ICollection<Enemy> SeedEnemies()
        {
            var enemies = new List<Enemy>
            {
                new Enemy
                {
                    ID = 1,
                    Name = "Goblin",
                    Description = "This is not a golbin",
                    Health = 10,
                    MaxHealth = 10,
                    Level = 1,
                    MinDamage = 1,
                    MaxDamage = 2,
                    Defence = 5,
                    RewardXP = 5
                },
                new Enemy
                {
                    ID = 2,
                    Name = "Skeleton",
                    Description = "Boney bonezz",
                    Health = 15,
                    MaxHealth = 15,
                    Level = 3,
                    MinDamage = 1,
                    MaxDamage = 3,
                    Defence = 7,
                    RewardXP = 6
                }
            };
            return enemies;
        }

        public static ICollection<Building> SeedBuildings()
        {
            var buildings = new List<Building>
            {
                new Building
                {
                    ID = 1,
                    Name = "House",
                    Description = "A House.",
                    Level = 1,
                    MaxLevel = 5,
                    UpgradeCost = 100,
                    ConstructionTime = 3600,
                    PopulationCapacity = 4,
                    IsUnderConstruction = false,
                    BuildingType = BuildingType.House
                },
                new Building
                {
                    ID = 2,
                    Name = "Farm",
                    Description = "A farm.",
                    Level = 1,
                    MaxLevel = 5,
                    UpgradeCost = 100,
                    ConstructionTime = 3600,
                    ResourceProduction = 100,
                    IsUnderConstruction = false,
                    BuildingType = BuildingType.Farm
                }
            };
            return buildings;
        }

    }
}
