namespace si730ebu20201c334.API.Loyalty.Domain.Models;

public class Reward
{
    public int Id { get; set; }
    public int FleetId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Score { get; set; }
}