using System.ComponentModel.DataAnnotations;

namespace Influencer_Outreach_AI.Models;

public class OutreachMessage
{
    public int Id { get; set; }

    public int InfluencerId { get; set; }

    [Required]
    public string Channel { get; set; } = string.Empty;

    [Required]
    public string Content { get; set; } = string.Empty;

    public DateTime SentAt { get; set; }

    public DateTime? ReceivedResponseAt { get; set; }

    public string? Response { get; set; }

    public OutreachMessageStatus Status { get; set; }

    // Navigation property
    public Influencer Influencer { get; set; } = null!;
}