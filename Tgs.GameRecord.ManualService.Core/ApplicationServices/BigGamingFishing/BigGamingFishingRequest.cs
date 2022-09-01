namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.BigGamingFishing;

public record BigGamingFishingRequest
{
    public string CurrencyCode { get; init; } = default!;

    public DateTimeOffset StartTime { get; init; } = default!;

    public DateTimeOffset EndTime { get; init; } = default!;
}
