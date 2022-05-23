namespace Tgs.GameRecord.ManualService.ViewModels
{
    public record TCGamingQueryViewModel
    {
        public bool IsDesignation { get; init; }
        public string SubGP { get; init; } = default!;
        public string MerchantCode { get; init; } = default!;
        public string LastGameRecorDirectory { get; init; } = default!;
        public string LastGameRecorFile { get; init; } = default!;
    }
}
