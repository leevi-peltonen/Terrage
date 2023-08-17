namespace TerrageApi.Models.DTO
{
    public class UserReadDTO
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public int InventoryID { get; set; }
        public List<int>? AchievementIDs { get; set; }
        public int AchievementScore { get; set; }
        public int SettingsID { get; set; }
        public int VillageID { get; set; }
        public List<int>? FriendIDs { get; set; }
        public int? ClanID { get; set; }
        public bool? IsClanOwner { get; set; }

    }
}
