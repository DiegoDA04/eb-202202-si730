using AutoMapper;
using si730ebu20201c334.API.Loyalty.Domain.Models;
using si730ebu20201c334.API.Loyalty.Resources;


namespace si730ebu20201c334.API.Loyalty.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Reward, RewardResource>();
    }
}