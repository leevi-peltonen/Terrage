using Microsoft.EntityFrameworkCore;
using TerrageApi.Models;

namespace TerrageApi.Services
{
    public class VillageService : IVillageService
    {
        private readonly TerrageApiDBContext _context;

        public VillageService(TerrageApiDBContext context)
        {
            _context = context;
        }
        public async Task<Village> InitVillage(int UserID, string name)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(u => u.ID == UserID);
            if (user == null)
            {
                return null;
            }
            Village village = new Village
            {
                Owner = user,
                Name = name,
                Population = 0,
                Level = 1,
                Buildings = null
            };

            await _context.Villages.AddAsync(village);
            await _context.SaveChangesAsync();
            return village;
        }

        public async Task<bool> VillageExistsForUser(int UserID)
        {
            bool UserHasVillage = await _context.Villages.Include(v => v.Owner).AnyAsync(v => v.Owner.ID == UserID);

            return UserHasVillage;
        }
    }
}
