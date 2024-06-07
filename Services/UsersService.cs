using MatchingMicroserviceAPI.IRepository;
using MatchingMicroserviceAPI.Models;
using MatchingMicroserviceAPI.Services.IServices;

namespace MatchingMicroserviceAPI.Services;

public class UsersService:IUsersService
{

    private readonly HttpClient _client;

    private readonly IMatchingRepository _matchingRepository;

    public UsersService(HttpClient client, IMatchingRepository matchingRepository)
    {
        _client = client;
        _matchingRepository = matchingRepository;

    }


    public async Task<UserProfile> GetUserByIdAsync(int userId)
    {
        var response = await _client.GetFromJsonAsync<UserProfile>($"users/{userId}");

        return response;
    }

    public async  Task<IEnumerable<UserProfile>> GetAllUsersAsync()
    {
        var response = await _client.GetFromJsonAsync<IEnumerable<UserProfile>>("users");

        return response;
    }
}