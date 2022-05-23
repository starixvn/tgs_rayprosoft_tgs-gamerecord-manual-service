namespace Tgs.GameRecord.ManualService.ViewModels
{
    public record WGViaGamingQueryViewModel
    {
        public DateTimeOffset StartTime { get; init; } = default!;

        public DateTimeOffset EndTime { get; init; } = default!;
    }
}
