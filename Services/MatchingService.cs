using MatchingMicroserviceAPI.IRepository;
using MatchingMicroserviceAPI.Models;
using MatchingMicroserviceAPI.Services.IServices;

namespace MatchingMicroserviceAPI.Services;

public class MatchingService : IMatchingService
{
    private readonly IUsersService _usersService;

    private readonly IMatchingRepository _matchingRepository;

    public MatchingService(IUsersService usersService, IMatchingRepository matchingRepository)
    {
        _usersService = usersService;
        _matchingRepository = matchingRepository;
    }

    public async Task<IEnumerable<Match>> FindMatchesAsync(int userId)
    {
        var user = await _usersService.GetUserByIdAsync(userId);

        if (user == null)
        {
            throw new ArgumentException(nameof(user));
        }

        var allUsers = await _usersService.GetAllUsersAsync();

        var potentialMatches = allUsers.Where(u => u.Id != userId).ToList();

        var matches = new List<Match>();

        foreach (var potentialMatch in potentialMatches)
        {
            if (IsMatch(user, potentialMatch))
            {
                var match = new Match()
                {
                    UserId1 = userId,
                    UserId2 = potentialMatch.Id,
                    MatchedAt = DateTime.UtcNow,
                    Status = MatchStatus.Pending,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };
                
                matches.Add(match);
            }
            
        }

        return matches;
    }

    private bool IsMatch(UserProfile user, UserProfile potentialMatch)
    {
        // Implement your matching logic here, for example:
        // - Compare interests
        // - Check location proximity
        // - Match based on preferences
        // This is a simple example of comparing interests.
        var commonInterests = user.Interests.Intersect(potentialMatch.Interests).Count();
        return commonInterests >= 3; // Arbitrary threshold for matching
    }
}