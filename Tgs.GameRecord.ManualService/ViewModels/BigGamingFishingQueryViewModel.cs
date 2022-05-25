namespace Tgs.GameRecord.ManualService.ViewModels
{
    public record BigGamingFishingQueryViewModel
    {
        public string CurrencyCode { get; init; } = default!;

        public DateTimeOffset StartTime { get; init; } = default!;

        public DateTimeOffset EndTime { get; init; } = default!;
    }
}
