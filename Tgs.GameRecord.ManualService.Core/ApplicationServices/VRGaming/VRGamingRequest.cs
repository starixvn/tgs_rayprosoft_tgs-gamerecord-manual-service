namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.VRGaming;

public record VRGamingRequest
{
    public string BrandCode { get; init; } = default!;

    public DateTimeOffset StartTime { get; init; } = default!;

    public DateTimeOffset EndTime { get; init; } = default!;
}
