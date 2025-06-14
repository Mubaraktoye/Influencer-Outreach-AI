using Influencer_Outreach_AI.Data;
using Influencer_Outreach_AI.Models;
using Microsoft.EntityFrameworkCore;

namespace Influencer_Outreach_AI.Repositories;

public class InfluencerRepository : Repository<Influencer>, IInfluencerRepository
{
    public InfluencerRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Influencer>> GetInfluencersByStatusAsync(InfluencerStatus status)
    {
        return await _dbSet
            .Include(i => i.OutreachMessages)
            .Where(i => i.Status == status)
            .ToListAsync();
    }

    public async Task<IEnumerable<Influencer>> GetInfluencersForOutreachAsync()
    {
        return await _dbSet
            .Include(i => i.OutreachMessages)
            .Where(i => i.Status == InfluencerStatus.Identified &&
                      (i.LastContactedAt == null || 
                       i.LastContactedAt < DateTime.UtcNow.AddDays(-30)))
            .ToListAsync();
    }

    public async Task<bool> ExistsAsync(string email)
    {
        return await _dbSet.AnyAsync(i => i.Email == email);
    }
}