namespace MatchingMicroserviceAPI.Models;

public class UserProfile
{
    public int Id { get; set; }


    public string UserName { get; set; }

    public string Email { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string Gender { get; set; }

    public string Location { get; set; }
    public string Bio { get; set; }
    public List<string> Interests { get; set; }

    public List<string> Photos { get; set; } // URLs of user photos
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}