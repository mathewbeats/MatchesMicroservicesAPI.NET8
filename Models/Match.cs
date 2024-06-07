using System.ComponentModel.DataAnnotations;

namespace MatchingMicroserviceAPI.Models;

public class Match
{
    [Key]
    public int Id { get; set; }
        
    [Required]
    public int UserId1 { get; set; }
        
    [Required]
    public int UserId2 { get; set; }

    [Required]
    public DateTime MatchedAt { get; set; }

    public bool IsAcceptedByUser1 { get; set; }
    public bool IsAcceptedByUser2 { get; set; }
        
    [Required]
    public MatchStatus Status { get; set; }

    public DateTime? User1ResponseAt { get; set; }
    public DateTime? User2ResponseAt { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }
        
    [Required]
    public DateTime UpdatedAt { get; set; }
}

public enum MatchStatus
{
    Pending,
    Accepted,
    Rejected
}