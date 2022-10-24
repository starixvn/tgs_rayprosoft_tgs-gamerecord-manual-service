namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.BigGamingFishing;

public record BigGamingFishingQuery
{
    public string CurrencyCode { get; init; } = default!;

    public DateTimeOffset StartTime { get; init; } = default!;

    public DateTimeOffset EndTime { get; init; } = default!;
}
