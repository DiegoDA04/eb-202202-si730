using System.ComponentModel.DataAnnotations;

namespace si730ebu20201c334.API.Loyalty.Resources;

public class SaveRewardResource
{
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    [Required]
    public decimal Score { get; set; }
}