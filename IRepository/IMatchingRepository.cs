using MatchingMicroserviceAPI.Models;

namespace MatchingMicroserviceAPI.IRepository;

public interface IMatchingRepository
{

    Task<IEnumerable<Match>>GetAllMatchesAsync();

    Task<Match> GetMatchByIdAsync(int id);

    Task<Match> CreateMatchAsync(Match match);

    Task<bool> UpdateMatchAsync(int id, Match match);

    Task<bool> DeleteMatchAsync(int id);

    Task<bool> SaveChangesAsync();


}