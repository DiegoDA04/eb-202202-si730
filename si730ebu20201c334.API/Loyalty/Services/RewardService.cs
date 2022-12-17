using si730ebu20201c334.API.Loyalty.Domain.Models;
using si730ebu20201c334.API.Loyalty.Domain.Repositories;
using si730ebu20201c334.API.Loyalty.Domain.Services;
using si730ebu20201c334.API.Loyalty.Domain.Services.Communication;
using si730ebu20201c334.API.Shared.Domain.Repositories;

namespace si730ebu20201c334.API.Loyalty.Services;

public class RewardService : IRewardService
{
    private readonly IRewardRepository _rewardRepository;
    private readonly IUnitOfWork _unitOfWork;


    public RewardService(IRewardRepository rewardRepository, IUnitOfWork unitOfWork)
    {
        _rewardRepository = rewardRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Reward>> ListAsync()
    {
        return await _rewardRepository.ListAsync();
    }

    public async Task<RewardResponse> SaveAsync(Reward resource)
    {
        if (resource.Score == 0)
            return new RewardResponse("Invalid Reward, the score must not have the value 0");

        var existingRewardWithNameAndFleetId =
            await _rewardRepository.FindByNameAndFleetId(resource.Name, resource.FleetId);

        if (existingRewardWithNameAndFleetId != null)
            return new RewardResponse("Invalid Reward, treasure name and fleetId already exists");
            
        try
        {
            await _rewardRepository.AddAsync(resource);
            await _unitOfWork.CompleteAsync();
            
            return new RewardResponse(resource);
        }
        catch (Exception e)
        {
            return new RewardResponse($"An error occurred while saving the Reward: {e.Message}");
        }
    }

    public async Task<IEnumerable<Reward>> ListByFleetIdAsync(int fleetId)
    {
        return await _rewardRepository.ListByFleetIdAsync(fleetId);
    }

    public async Task<IEnumerable<Reward>> ListByScoreGreaterThanOrEqualToAsync(int score)
    {
        return await _rewardRepository.ListByScoreGreaterThanOrEqualToAsync(score);
    }
}