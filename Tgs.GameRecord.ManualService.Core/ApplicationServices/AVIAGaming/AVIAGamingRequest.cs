namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.AVIAGaming;

public record AVIAGamingRequest
{
    public string BrandCode { get; init; } = default!;

    public DateTimeOffset StartTime { get; init; } = default!;

    public DateTimeOffset EndTime { get; init; } = default!;
}
