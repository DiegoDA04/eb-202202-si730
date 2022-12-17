using si730ebu20201c334.API.Loyalty.Domain.Models;
using si730ebu20201c334.API.Loyalty.Domain.Services.Communication;

namespace si730ebu20201c334.API.Loyalty.Domain.Services;

public interface IRewardService
{
    Task<IEnumerable<Reward>> ListAsync();
    Task<RewardResponse> SaveAsync(Reward resource);

    Task<IEnumerable<Reward>> ListByFleetIdAsync(int fleetId);
    Task<IEnumerable<Reward>> ListByScoreGreaterThanOrEqualToAsync(int score);
}