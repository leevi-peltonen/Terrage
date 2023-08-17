using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using System.Security.Cryptography.Xml;
using System.Text.Json;
using System.Text.Json.Serialization;
using TerraVillageAPI.Utils;

namespace TerraVillageAPI.Models
{
    public class TerraVillageDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<Clan> Clans { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Armor> Armors { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<Enemy> Enemies { get; set; }
        public DbSet<DamageEffect> DamageEffects { get; set; }
        public DbSet<Village> Villages { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Consumable> Consumables { get; set; }

        public TerraVillageDBContext(DbContextOptions<TerraVillageDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Achievement>().ToTable("Achievements");
            modelBuilder.Entity<Clan>().ToTable("Clans");
            modelBuilder.Entity<Inventory>().ToTable("Inventories");
            modelBuilder.Entity<Weapon>().ToTable("Weapons");
            modelBuilder.Entity<Armor>().ToTable("Armors");
            modelBuilder.Entity<Settings>().ToTable("Settings");
            modelBuilder.Entity<Enemy>().ToTable("Enemies");
            modelBuilder.Entity<DamageEffect>().ToTable("DamageEffects");
            modelBuilder.Entity<Village>().ToTable("Villages");
            modelBuilder.Entity<Building>().ToTable("Buildings");
            modelBuilder.Entity<Consumable>().ToTable("Consumables");

            /*
             * Data seeds
             */

            modelBuilder.Entity<Achievement>().HasData(SeedHelper.SeedAchievements());
            modelBuilder.Entity<Weapon>().HasData(SeedHelper.SeedWeapons());
            modelBuilder.Entity<Armor>().HasData(SeedHelper.SeedArmor());
            modelBuilder.Entity<Consumable>().HasData(SeedHelper.SeedConsumables());
            modelBuilder.Entity<Enemy>().HasData(SeedHelper.SeedEnemies());
            modelBuilder.Entity<Building>().HasData(SeedHelper.SeedBuildings());

            /*
             * One To One
             */
            // User inventory
            modelBuilder.Entity<User>()
                .HasOne(u => u.Inventory)
                .WithOne(i => i.User)
                .HasForeignKey<Inventory>(i => i.ID)
                .OnDelete(DeleteBehavior.Cascade);
            // User settings
            modelBuilder.Entity<User>()
                .HasOne(u => u.Settings)
                .WithOne(s => s.User)
                .HasForeignKey<Settings>(s => s.ID)
                .OnDelete(DeleteBehavior.Cascade);
            // User village
            modelBuilder.Entity<User>()
                .HasOne(u => u.Village)
                .WithOne(v => v.Owner)
                .HasForeignKey<Village>(i => i.ID)
                .OnDelete(DeleteBehavior.Cascade);

            /*
             * One To Many
             */

            // Clan members
            modelBuilder.Entity<Clan>()
                .HasMany(c => c.Members)
                .WithOne(u => u.Clan);

            // Building requirements
            modelBuilder.Entity<Building>()
                .Property(b => b.RequiredBuildings)
                .HasConversion(
                    x => JsonConvert.SerializeObject(x, Formatting.None),
                    y => JsonConvert.DeserializeObject<Dictionary<BuildingType, int>>(y)
                );

            /*
             * Many To Many
             */

            // User Achievements
            modelBuilder.Entity<User>()
                .HasMany(u => u.Achievements)
                .WithMany(a => a.Users)
                .UsingEntity(x => x.ToTable("UserAchievement"));

            //Inventory Items
            modelBuilder.Entity<Inventory>()
                .HasMany(i => i.Items)
                .WithMany(i => i.UserInventories)
                .UsingEntity(x => x.ToTable("InventoryItems"));

            // Enemy drop tables
            modelBuilder.Entity<Enemy>()
                .HasMany(e => e.DropTable)
                .WithMany(i => i.EnemyDropTables)
                .UsingEntity(x => x.ToTable("EnemyDropTables"));

            // Enemy damage effects
            modelBuilder.Entity<Enemy>()
                .HasMany(e => e.DamageEffects)
                .WithMany(de => de.Enemies)
                .UsingEntity(x => x.ToTable("EnemyDamageEffects"));

            // User friends
            modelBuilder.Entity<User>()
                .HasMany(u => u.Friends)
                .WithMany()
                .UsingEntity(x => x.ToTable("UserFriends"));

            // Village buildings
            modelBuilder.Entity<Village>()
                .HasMany(v => v.Buildings)
                .WithMany(b => b.Villages)
                .UsingEntity(x => x.ToTable("VillageBuildings"));

            /*
             * Conversions
             */

            // Clan tags
            modelBuilder.Entity<Clan>()
                .Property(c => c.Tags)
                .HasConversion(
                    v => string.Join(",", v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(s => Enum.Parse<ClanTag>(s)).ToList()
                );
        }
    }
}
