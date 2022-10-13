using System.ComponentModel.DataAnnotations;

namespace Tgs.GameRecord.ManualService.ViewModels;

public record WMCasinoTransferQueryViewModel
{
    [Required]
    public Uri GameApiUrl { get; init; } = default!;
    [Required]
    public string GameProviderVendorId { get; init; } = default!;
    [Required]
    public string GameProviderSignature { get; init; } = default!;
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime StartTime { get; init; }
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime EndTime { get; init; }
}
