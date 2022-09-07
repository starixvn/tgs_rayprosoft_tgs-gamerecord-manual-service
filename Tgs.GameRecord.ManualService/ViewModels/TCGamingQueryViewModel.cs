namespace Tgs.GameRecord.ManualService.ViewModels;

public record TCGamingQueryViewModel
{
    public bool IsDesignation { get; init; }
    public string SubGP { get; init; } = default!;
    public string MerchantCode { get; init; } = default!;
    public string LastGameRecordDirectory { get; init; } = default!;
    public string LastGameRecordFile { get; init; } = default!;
}
