namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.TCGaming;

public record TCGamingResponse
{
    public bool Success { get; init; }

    public string LastGameRecordDirectory { get; set; } = default!;

    public string LastGameRecordFile { get; set; } = default!;
}
