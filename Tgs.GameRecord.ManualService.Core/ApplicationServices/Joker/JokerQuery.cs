namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.Joker;

public record JokerQuery
{
    public string BrandCode { get; init; } = default!;
    public string AgentId { get; init; } = default!;
    public DateTimeOffset StartTime { get; init; }
    public DateTimeOffset EndTime { get; init; }
}
