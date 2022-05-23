namespace Tgs.GameRecord.ManualService.ViewModels
{
    public record TCGamingResultViewModel
    {
        public bool Success { get; init; }

        public string LastGameRecorDirectory { get; set; } = default!;

        public string LastGameRecorFile { get; set; } = default!;
    }
}
