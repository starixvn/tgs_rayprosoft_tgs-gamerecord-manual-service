namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.LEGaming;

public record LEGamingResult
{
    public bool Success { get; init; }
    public DateTimeOffset? LastGameRecordTime { get; init; }
    public int SuccessCount { get; set; }
    public int FailureCount { get; set; }
    public int Count { get; init; }
}
