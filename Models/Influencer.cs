using System.ComponentModel.DataAnnotations;

namespace Influencer_Outreach_AI.Models;

public class Influencer
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Email { get; set; } = string.Empty;

    public string? PhoneNumber { get; set; }

    [Required]
    public string PrimaryPlatform { get; set; } = string.Empty;

    public string? PlatformHandle { get; set; }

    public int FollowerCount { get; set; }

    public double EngagementRate { get; set; }

    public string? Niche { get; set; }

    public string? Location { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? LastContactedAt { get; set; }

    [Required]
    public InfluencerStatus Status { get; set; }

    // Navigation properties
    public ICollection<OutreachMessage> OutreachMessages { get; set; } = new List<OutreachMessage>();
}