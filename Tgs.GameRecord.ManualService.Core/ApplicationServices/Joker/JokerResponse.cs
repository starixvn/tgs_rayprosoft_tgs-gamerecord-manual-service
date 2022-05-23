namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.Joker
{
    public record JokerResponse
    {
        public bool Success { get; init; }
        public DateTimeOffset? LastGameRecorTime { get; init; }
        public int SuccessCount { get; set; }
        public int FailCount { get; set; }
        public int Count { get; init; }
    }
}
