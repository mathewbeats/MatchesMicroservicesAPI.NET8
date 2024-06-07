using MatchingMicroserviceAPI.Models;

namespace MatchingMicroserviceAPI.Services.IServices;

public interface IMatchingService
{
    Task<IEnumerable<Match>> FindMatchesAsync(int userId);

     
}