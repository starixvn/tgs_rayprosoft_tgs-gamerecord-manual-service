using System.ComponentModel.DataAnnotations;

namespace Tgs.GameRecord.ManualService.ViewModels;

public record EndorphinaQueryViewModel
{
    [Required]
    [DataType(DataType.Url)]
    public Uri ApiUrl { get; init; } = default!;

    [Required]
    public string MerchantId { get; init; } = default!;

    [Required]
    public string SecretKey { get; init; } = default!;

    [Required]
    public string Token { get; init; } = default!;
}
