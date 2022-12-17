using si730ebu20201c334.API.Loyalty.Domain.Models;

namespace si730ebu20201c334.API.Loyalty.Domain.Repositories;

public interface IRewardRepository
{
    Task<IEnumerable<Reward>> ListAsync();
    Task AddAsync(Reward reward);

    Task<IEnumerable<Reward>> ListByFleetIdAsync(int fleetId);

    Task<Reward> FindByNameAndFleetId(string name, int fleetId);
    
    Task<IEnumerable<Reward>> ListByScoreGreaterThanOrEqualToAsync(int score);
}