namespace Tgs.GameRecord.ManualService.ViewModels;

public record JokerQueryViewModel()
{
    public string BrandCode { get; init; } = default!;
    public string AgentId { get; init; } = default!;
    public DateTimeOffset StartTime { get; init; }
    public DateTimeOffset EndTime { get; init; }
}
