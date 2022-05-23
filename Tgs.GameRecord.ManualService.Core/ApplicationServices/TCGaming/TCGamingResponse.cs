namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.TCGaming
{
    public record TCGamingResponse
    {
        public bool Success { get; init; }

        public string LastGameRecorDirectory { get; set; } = default!;

        public string LastGameRecorFile { get; set; } = default!;
    }
}
