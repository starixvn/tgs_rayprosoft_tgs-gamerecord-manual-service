using System.ComponentModel.DataAnnotations;

namespace Tgs.GameRecord.ManualService.ViewModels;

public record EndorphinaQueryViewModel
{
    [Required]
    public Uri ApiUrl { get; init; } = default!;

    [Required]
    public string MerchantId { get; init; } = default!;

    [Required]
    public string SecretKey { get; init; } = default!;

    [Required]
    public string Token { get; init; } = default!;
}
