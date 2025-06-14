using Influencer_Outreach_AI.Models;

namespace Influencer_Outreach_AI.Repositories;

public interface IInfluencerRepository : IRepository<Influencer>
{
    Task<IEnumerable<Influencer>> GetInfluencersByStatusAsync(InfluencerStatus status);
    Task<IEnumerable<Influencer>> GetInfluencersForOutreachAsync();
    Task<bool> ExistsAsync(string email);
}