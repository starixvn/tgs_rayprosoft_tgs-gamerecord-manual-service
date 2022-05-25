namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.WGViaGaming
{
    public record WGViaGamingRequest
    {
        public DateTimeOffset StartTime { get; init; } = default!;

        public DateTimeOffset EndTime { get; init; } = default!;
    }
}
