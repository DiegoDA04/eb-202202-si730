using Microsoft.EntityFrameworkCore;
using PracticeBackend.API.Shared.Persistence.Repositories;
using si730ebu20201c334.API.Loyalty.Domain.Models;
using si730ebu20201c334.API.Loyalty.Domain.Repositories;
using si730ebu20201c334.API.Shared.Persistence.Contexts;

namespace si730ebu20201c334.API.Loyalty.Persistence.Repositories;

public class RewardRepository : BaseRepository, IRewardRepository
{
    public RewardRepository(AppDbContext context) : base(context)
    {
        
    }
    
    public async Task<IEnumerable<Reward>> ListAsync()
    {
        return await _context.Rewards.ToListAsync();
    }

    public async Task AddAsync(Reward reward)
    {
        await _context.Rewards.AddAsync(reward);
    }

    public async Task<IEnumerable<Reward>> ListByFleetIdAsync(int fleetId)
    {
        return await _context.Rewards
            .Where(r => r.FleetId == fleetId)
            .ToListAsync();
    }

    public async Task<Reward> FindByNameAndFleetId(string name, int fleetId)
    {
        return await _context.Rewards
            .Where(r => r.Name == name && r.FleetId == fleetId)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Reward>> ListByScoreGreaterThanOrEqualToAsync(int score)
    {
        return await _context.Rewards
            .Where(r => r.Score >= score)
            .ToListAsync();
    }
    
}