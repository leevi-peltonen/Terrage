using TerraVillageAPI.Models;

namespace TerraVillageAPI.Services
{
    public interface IVillageService
    {
        public Task<Village> InitVillage(int UserID, string name);
        public Task<bool> VillageExistsForUser(int UserID);
    }
}
