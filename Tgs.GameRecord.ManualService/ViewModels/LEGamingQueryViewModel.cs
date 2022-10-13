using System.ComponentModel.DataAnnotations;

namespace Tgs.GameRecord.ManualService.ViewModels;

public record LEGamingQueryViewModel
{
    [Required]
    public string BrandCode { get; init; } = default!;

    [Required]
    public string CurrencyCode { get; init; } = default!;

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime StartTime { get; init; }
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime EndTime { get; init; }
}
