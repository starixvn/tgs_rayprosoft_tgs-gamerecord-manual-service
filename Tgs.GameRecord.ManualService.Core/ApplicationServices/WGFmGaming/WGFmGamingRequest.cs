namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.WGFmGaming
{
    public record WGFmGamingRequest
    {
        public DateTimeOffset StartTime { get; init; } = default!;

        public DateTimeOffset EndTime { get; init; } = default!;
    }
}
