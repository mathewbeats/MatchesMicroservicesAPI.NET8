using MatchingMicroserviceAPI.Models;

namespace MatchingMicroserviceAPI.Services.IServices;

public interface IUsersService
{
    Task<UserProfile> GetUserByIdAsync(int userId);
    Task<IEnumerable<UserProfile>> GetAllUsersAsync();
}