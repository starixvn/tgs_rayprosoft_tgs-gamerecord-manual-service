namespace Tgs.GameRecord.ManualService.ViewModels
{
    public record WGFmGamingQueryViewModel
    {
        public DateTimeOffset StartTime { get; init; } = default!;

        public DateTimeOffset EndTime { get; init; } = default!;
    }
}
