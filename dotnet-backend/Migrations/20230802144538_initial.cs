using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TerrageApi.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Achievements",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achievements", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    MaxLevel = table.Column<int>(type: "int", nullable: false),
                    UpgradeCost = table.Column<int>(type: "int", nullable: false),
                    ConstructionTime = table.Column<int>(type: "int", nullable: false),
                    PopulationCapacity = table.Column<int>(type: "int", nullable: true),
                    ResourceProduction = table.Column<int>(type: "int", nullable: true),
                    ResourceCapacity = table.Column<int>(type: "int", nullable: true),
                    RequiredBuildings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequiredPlayerLevel = table.Column<int>(type: "int", nullable: true),
                    IsUnderConstruction = table.Column<bool>(type: "bit", nullable: false),
                    ConstructionCompletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BuildingType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DamageEffects",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EffectType = table.Column<int>(type: "int", nullable: false),
                    Potency = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Chance = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DamageEffects", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Enemies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Health = table.Column<int>(type: "int", nullable: false),
                    MaxHealth = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    MinDamage = table.Column<int>(type: "int", nullable: false),
                    MaxDamage = table.Column<int>(type: "int", nullable: false),
                    Defence = table.Column<int>(type: "int", nullable: false),
                    RewardXP = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enemies", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rarity = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EnemyDamageEffects",
                columns: table => new
                {
                    DamageEffectsID = table.Column<int>(type: "int", nullable: false),
                    EnemiesID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnemyDamageEffects", x => new { x.DamageEffectsID, x.EnemiesID });
                    table.ForeignKey(
                        name: "FK_EnemyDamageEffects_DamageEffects_DamageEffectsID",
                        column: x => x.DamageEffectsID,
                        principalTable: "DamageEffects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnemyDamageEffects_Enemies_EnemiesID",
                        column: x => x.EnemiesID,
                        principalTable: "Enemies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Armors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Defense = table.Column<int>(type: "int", nullable: false),
                    Material = table.Column<int>(type: "int", nullable: false),
                    ArmorSlot = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Armors_Items_ID",
                        column: x => x.ID,
                        principalTable: "Items",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consumables",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Potency = table.Column<int>(type: "int", nullable: false),
                    EffectID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumables", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Consumables_DamageEffects_EffectID",
                        column: x => x.EffectID,
                        principalTable: "DamageEffects",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Consumables_Items_ID",
                        column: x => x.ID,
                        principalTable: "Items",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnemyDropTables",
                columns: table => new
                {
                    DropTableID = table.Column<int>(type: "int", nullable: false),
                    EnemyDropTablesID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnemyDropTables", x => new { x.DropTableID, x.EnemyDropTablesID });
                    table.ForeignKey(
                        name: "FK_EnemyDropTables_Enemies_EnemyDropTablesID",
                        column: x => x.EnemyDropTablesID,
                        principalTable: "Enemies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnemyDropTables_Items_DropTableID",
                        column: x => x.DropTableID,
                        principalTable: "Items",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    MinDamage = table.Column<int>(type: "int", nullable: false),
                    MaxDamage = table.Column<int>(type: "int", nullable: false),
                    ActionCost = table.Column<int>(type: "int", nullable: false),
                    IsTwoHanded = table.Column<bool>(type: "bit", nullable: false),
                    WeaponType = table.Column<int>(type: "int", nullable: false),
                    Durability = table.Column<int>(type: "int", nullable: false),
                    Material = table.Column<int>(type: "int", nullable: false),
                    DamageEffectID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Weapons_DamageEffects_DamageEffectID",
                        column: x => x.DamageEffectID,
                        principalTable: "DamageEffects",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Weapons_Items_ID",
                        column: x => x.ID,
                        principalTable: "Items",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clans",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerID = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Experience = table.Column<int>(type: "int", nullable: false),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false),
                    LastActivityDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clans", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AchievementScore = table.Column<int>(type: "int", nullable: false),
                    ClanID = table.Column<int>(type: "int", nullable: true),
                    IsClanOwner = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Users_Clans_ClanID",
                        column: x => x.ClanID,
                        principalTable: "Clans",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    InventorySize = table.Column<int>(type: "int", nullable: false),
                    MaxStackSize = table.Column<int>(type: "int", nullable: false),
                    Gold = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Inventories_Users_ID",
                        column: x => x.ID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false),
                    CombatDifficulty = table.Column<int>(type: "int", nullable: false),
                    OnlineStatus = table.Column<int>(type: "int", nullable: false),
                    AllowFriendRequests = table.Column<bool>(type: "bit", nullable: false),
                    DisableTutorials = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Settings_Users_ID",
                        column: x => x.ID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAchievement",
                columns: table => new
                {
                    AchievementsID = table.Column<int>(type: "int", nullable: false),
                    UsersID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAchievement", x => new { x.AchievementsID, x.UsersID });
                    table.ForeignKey(
                        name: "FK_UserAchievement_Achievements_AchievementsID",
                        column: x => x.AchievementsID,
                        principalTable: "Achievements",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAchievement_Users_UsersID",
                        column: x => x.UsersID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFriends",
                columns: table => new
                {
                    FriendsID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFriends", x => new { x.FriendsID, x.UserID });
                    table.ForeignKey(
                        name: "FK_UserFriends_Users_FriendsID",
                        column: x => x.FriendsID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFriends_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Villages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Population = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Villages_Users_ID",
                        column: x => x.ID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryItems",
                columns: table => new
                {
                    ItemsID = table.Column<int>(type: "int", nullable: false),
                    UserInventoriesID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryItems", x => new { x.ItemsID, x.UserInventoriesID });
                    table.ForeignKey(
                        name: "FK_InventoryItems_Inventories_UserInventoriesID",
                        column: x => x.UserInventoriesID,
                        principalTable: "Inventories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryItems_Items_ItemsID",
                        column: x => x.ItemsID,
                        principalTable: "Items",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VillageBuildings",
                columns: table => new
                {
                    BuildingsID = table.Column<int>(type: "int", nullable: false),
                    VillagesID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VillageBuildings", x => new { x.BuildingsID, x.VillagesID });
                    table.ForeignKey(
                        name: "FK_VillageBuildings_Buildings_BuildingsID",
                        column: x => x.BuildingsID,
                        principalTable: "Buildings",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VillageBuildings_Villages_VillagesID",
                        column: x => x.VillagesID,
                        principalTable: "Villages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Achievements",
                columns: new[] { "ID", "Description", "Name", "Score" },
                values: new object[,]
                {
                    { 1, "Gather your first set of resources.", "Novice Gatherer", 10 },
                    { 2, "Mine a total of 1,000 minerals.", "Master Miner", 50 },
                    { 3, "Catch 100 fish from different fishing spots.", "Fishing Enthusiast", 30 },
                    { 4, "Harvest a bountiful crop from your farm.", "Green Thumb", 20 },
                    { 5, "Accumulate 10,000 gold coins in your village's treasury.", "Wealthy Merchant", 100 },
                    { 6, "Defeat 100 enemies in combat.", "Monster Slayer", 60 },
                    { 7, "Upgrade all buildings to their maximum level in your village.", "Village Builder", 150 },
                    { 8, "Visit and unlock all locations on the game map.", "Explorer Extraordinaire", 120 },
                    { 9, "Craft a legendary weapon or armor.", "Legendary Crafter", 200 },
                    { 10, "Help 50 villagers with their quests or needs.", "Community Leader", 80 },
                    { 11, "Discover and collect all hidden treasures in the game world.", "Treasure Hunter", 180 },
                    { 12, "Win 10 consecutive battles in the village arena.", "Champion of the Arena", 100 },
                    { 13, "Brew 50 different potions and elixirs.", "Alchemist Apprentice", 70 },
                    { 14, "Trade with all neighboring villages and unlock exclusive resources.", "Master of Trade", 110 },
                    { 15, "Achieve the highest level of prosperity and renown for your village.", "Legendary Village", 250 }
                });

            migrationBuilder.InsertData(
                table: "Buildings",
                columns: new[] { "ID", "BuildingType", "ConstructionCompletionTime", "ConstructionTime", "Description", "IsUnderConstruction", "Level", "MaxLevel", "Name", "PopulationCapacity", "RequiredBuildings", "RequiredPlayerLevel", "ResourceCapacity", "ResourceProduction", "UpgradeCost" },
                values: new object[,]
                {
                    { 1, 0, null, 3600, "A House.", false, 1, 5, "House", 4, null, null, null, null, 100 },
                    { 2, 1, null, 3600, "A farm.", false, 1, 5, "Farm", null, null, null, null, 100, 100 }
                });

            migrationBuilder.InsertData(
                table: "Enemies",
                columns: new[] { "ID", "Defence", "Description", "Health", "Level", "MaxDamage", "MaxHealth", "MinDamage", "Name", "RewardXP" },
                values: new object[,]
                {
                    { 1, 5, "This is not a golbin", 10, 1, 2, 10, 1, "Goblin", 5 },
                    { 2, 7, "Boney bonezz", 15, 3, 3, 15, 1, "Skeleton", 6 }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ID", "Amount", "Description", "Name", "Rarity", "Value" },
                values: new object[,]
                {
                    { 1, 1, "A basic sword made out of bronze", "Bronze Sword", 0, 6 },
                    { 2, 1, "A basic bow made out of wood", "Wooden Bow", 0, 8 },
                    { 3, 1, "A sharp dagger made of silver", "Silver Dagger", 1, 15 },
                    { 5, 1, "A magical staff made of mithril", "Mithril Staff", 3, 100 },
                    { 6, 1, "A legendary rapier crafted from dragon scales", "Dragon Scale Rapier", 4, 1000 },
                    { 7, 1, "A common platebody made out of bronze", "Bronze platebody", 0, 20 },
                    { 8, 1, "Common platelegs made out of bronze", "Bronze platelegs", 0, 18 },
                    { 9, 1, "A common helm made out of bronze", "Bronze helm", 0, 9 },
                    { 10, 1, "Common gloves made out of bronze", "Bronze gloves", 0, 7 },
                    { 11, 1, "Common boots made out of bronze", "Bronze boots", 0, 7 },
                    { 12, 1, "Weak potion that gives you some health", "Minor health potion", 0, 15 },
                    { 13, 1, "Major potion that gives you a lot of health", "Major health potion", 2, 125 },
                    { 14, 1, "Summons a storm upon your enemies", "Storm scroll", 0, 50 }
                });

            migrationBuilder.InsertData(
                table: "Armors",
                columns: new[] { "ID", "ArmorSlot", "Defense", "Material" },
                values: new object[,]
                {
                    { 7, 1, 10, 3 },
                    { 8, 3, 8, 3 },
                    { 9, 0, 5, 3 },
                    { 10, 2, 2, 3 },
                    { 11, 4, 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "Consumables",
                columns: new[] { "ID", "EffectID", "Potency", "Type" },
                values: new object[,]
                {
                    { 12, null, 10, 0 },
                    { 13, null, 100, 0 },
                    { 14, null, 8, 1 }
                });

            migrationBuilder.InsertData(
                table: "Weapons",
                columns: new[] { "ID", "ActionCost", "DamageEffectID", "Durability", "IsTwoHanded", "Material", "MaxDamage", "MinDamage", "WeaponType" },
                values: new object[,]
                {
                    { 1, 1, null, 100, false, 3, 5, 1, 0 },
                    { 2, 2, null, 80, true, 0, 6, 2, 8 },
                    { 3, 1, null, 60, false, 5, 7, 3, 3 },
                    { 5, 2, null, 120, true, 7, 12, 5, 11 },
                    { 6, 1, null, 200, false, 9, 20, 10, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clans_OwnerID",
                table: "Clans",
                column: "OwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Consumables_EffectID",
                table: "Consumables",
                column: "EffectID");

            migrationBuilder.CreateIndex(
                name: "IX_EnemyDamageEffects_EnemiesID",
                table: "EnemyDamageEffects",
                column: "EnemiesID");

            migrationBuilder.CreateIndex(
                name: "IX_EnemyDropTables_EnemyDropTablesID",
                table: "EnemyDropTables",
                column: "EnemyDropTablesID");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_UserInventoriesID",
                table: "InventoryItems",
                column: "UserInventoriesID");

            migrationBuilder.CreateIndex(
                name: "IX_UserAchievement_UsersID",
                table: "UserAchievement",
                column: "UsersID");

            migrationBuilder.CreateIndex(
                name: "IX_UserFriends_UserID",
                table: "UserFriends",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ClanID",
                table: "Users",
                column: "ClanID");

            migrationBuilder.CreateIndex(
                name: "IX_VillageBuildings_VillagesID",
                table: "VillageBuildings",
                column: "VillagesID");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_DamageEffectID",
                table: "Weapons",
                column: "DamageEffectID");

            migrationBuilder.AddForeignKey(
                name: "FK_Clans_Users_OwnerID",
                table: "Clans",
                column: "OwnerID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clans_Users_OwnerID",
                table: "Clans");

            migrationBuilder.DropTable(
                name: "Armors");

            migrationBuilder.DropTable(
                name: "Consumables");

            migrationBuilder.DropTable(
                name: "EnemyDamageEffects");

            migrationBuilder.DropTable(
                name: "EnemyDropTables");

            migrationBuilder.DropTable(
                name: "InventoryItems");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "UserAchievement");

            migrationBuilder.DropTable(
                name: "UserFriends");

            migrationBuilder.DropTable(
                name: "VillageBuildings");

            migrationBuilder.DropTable(
                name: "Weapons");

            migrationBuilder.DropTable(
                name: "Enemies");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "Achievements");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "Villages");

            migrationBuilder.DropTable(
                name: "DamageEffects");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Clans");
        }
    }
}
