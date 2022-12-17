using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using si730ebu20201c334.API.Loyalty.Domain.Models;
using si730ebu20201c334.API.Loyalty.Domain.Services;
using si730ebu20201c334.API.Loyalty.Resources;
using si730ebu20201c334.API.Shared.Extensions;
using Swashbuckle.AspNetCore.Annotations;

namespace si730ebu20201c334.API.Loyalty.Controllers;


[ApiController]
[Route("/api/v1/")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag]
public class RewardsController : ControllerBase
{
    private readonly IRewardService _rewardService;
    private readonly IMapper _mapper;


    public RewardsController(IRewardService rewardService, IMapper mapper)
    {
        _rewardService = rewardService;
        _mapper = mapper;
    }
    
    [HttpGet("scores/{score}/[controller]")]
    [SwaggerOperation(
        Summary = "Get All Treasures by the Highest Score Than Given",
        Description = "Get existing Rewards associated with the score",
        OperationId = "GetRewardsScore",
        Tags = new []{"Scores"})]
    public async Task<IEnumerable<RewardResource>> GetAllRewardsByScoreGreaterThanOrEqualToAsync(int score)
    {
        var rewards = await _rewardService.ListByScoreGreaterThanOrEqualToAsync(score);
        var resources = _mapper.Map<IEnumerable<Reward>, IEnumerable<RewardResource>>(rewards);
        
        return resources;
    }
    [HttpPost("fleets/{fleetId}/[controller]")]
    [SwaggerOperation(
        Summary = "Create Treasure for Given FleetId",
        Description = "Create Reward associated with the specified FleetId",
        OperationId = "GetRewardsFleet",
        Tags = new []{"Fleets"})]
    public async Task<IActionResult> PostAsync(int fleetId, [FromBody] SaveRewardResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var reward = _mapper.Map<SaveRewardResource, Reward>(resource);
        
        reward.FleetId = fleetId;
        
        var result = await _rewardService.SaveAsync(reward);

        if (!result.Success)
            return BadRequest(result.Message);

        var tutorialResource = _mapper.Map<Reward, RewardResource>(result.Resource);

        return Ok(tutorialResource);
    }
}