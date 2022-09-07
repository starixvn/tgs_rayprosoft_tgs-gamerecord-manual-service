namespace Tgs.GameRecord.ManualService.ViewModels;

public record TCGamingResultViewModel
{
    public bool Success { get; init; }

    public string LastGameRecordDirectory { get; set; } = default!;

    public string LastGameRecordFile { get; set; } = default!;
}
