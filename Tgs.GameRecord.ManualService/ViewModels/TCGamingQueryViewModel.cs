using System.ComponentModel.DataAnnotations;

namespace Tgs.GameRecord.ManualService.ViewModels;

public record TCGamingQueryViewModel
{
	[Required]
	public bool IsDesignation { get; init; }
	[Required]
	public string SubGP { get; init; } = default!;
	[Required]
	public string MerchantCode { get; init; } = default!;
	[Required]
	public string LastGameRecordDirectory { get; init; } = default!;
	[Required]
	public string LastGameRecordFile { get; init; } = default!;
}
