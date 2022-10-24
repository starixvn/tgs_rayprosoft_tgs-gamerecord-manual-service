namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.WGViaGaming;

public record WGViaGamingResult
{
    public bool Success { get; init; }
    public DateTimeOffset? LastGameRecordTime { get; init; }
    public int SuccessCount { get; set; }
    public int FailureCount { get; set; }
    public int Count { get; init; }
}
