using MatchingMicroserviceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MatchingMicroserviceAPI.Data;

public class ApplicationDbContext:DbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Match> Matches { get; set; }
    
}