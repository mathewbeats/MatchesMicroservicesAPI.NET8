using MatchingMicroserviceAPI.Data;
using MatchingMicroserviceAPI.IRepository;
using MatchingMicroserviceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MatchingMicroserviceAPI.Repository
{
    public class MatchingRepository : IMatchingRepository
    {
        private readonly ApplicationDbContext _context;

        public MatchingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Match>> GetAllMatchesAsync()
        {
            return await _context.Matches.OrderBy(c => c.Id).ThenBy(c => c.MatchedAt).ToListAsync();
        }

        public async Task<Match> GetMatchByIdAsync(int id)
        {
            return await _context.Matches.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Match> CreateMatchAsync(Match match)
        {
            await _context.Matches.AddAsync(match);
            await _context.SaveChangesAsync();
            return match;
        }

        public async Task<bool> UpdateMatchAsync(int id, Match match)
        {
            var matchId = await _context.Matches.FindAsync(id);

            if (matchId == null)
            {
                throw new ArgumentNullException(nameof(matchId), "Error al procesar el match");
            }

            _context.Entry(matchId).CurrentValues.SetValues(match);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteMatchAsync(int id)
        {
            var matchId = await _context.Matches.FindAsync(id);

            if (matchId == null)
            {
                return false;
            }

            _context.Matches.Remove(matchId);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}