using MatchingMicroserviceAPI.IRepository;

namespace MatchingMicroserviceAPI.MatchingApi;

public static class ApiExtensions
{
    public static void MapMatchesApiExtensions(this IEndpointRouteBuilder map)
    {
        map.MapGet("matches", async (IMatchingRepository repository) => await GetMatchessAsync(repository));
        map.MapGet("matches/{userId:int}",
            async (int userId, IMatchingRepository repository) => await GetMatchesByIdAsync(userId, repository));
    }


    private static async Task<IResult> GetMatchessAsync(IMatchingRepository repository)
    {
        var matches = await repository.GetAllMatchesAsync();

        return Results.Ok(matches);
    }

    private static async Task<IResult> GetMatchesByIdAsync(int userId, IMatchingRepository matchingRepository)
    {
        var idMatch = await matchingRepository.GetMatchByIdAsync(userId);

        return idMatch != null ? Results.Ok(idMatch) : Results.NotFound();
    }
}