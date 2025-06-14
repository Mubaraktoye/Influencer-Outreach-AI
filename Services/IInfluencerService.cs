using Influencer_Outreach_AI.Models;

namespace Influencer_Outreach_AI.Services;

public interface IInfluencerService
{
    Task<IEnumerable<Influencer>> DiscoverInfluencersAsync();
    Task<bool> ValidateInfluencerAsync(Influencer influencer);
    Task<bool> InitiateOutreachAsync(int influencerId);
    Task<bool> ProcessResponseAsync(int messageId, string response);
    Task<IEnumerable<Influencer>> GetInfluencersForOutreachAsync();
    Task<IEnumerable<OutreachMessage>> GetPendingMessagesAsync();
}