namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.WGFmGaming
{
    public record WGFmGamingResponse
    {
        public bool Success { get; init; }
        public DateTimeOffset? LastGameRecordTime { get; init; }
        public int SuccessCount { get; set; }
        public int FailCount { get; set; }
        public int Count { get; init; }
    }
}
