using System.ComponentModel.DataAnnotations;

namespace Tgs.GameRecord.ManualService.ViewModels;

public record BigGamingFishingQueryViewModel
{
    public string CurrencyCode { get; init; } = default!;

    [Required]
    [DataType(DataType.DateTime)]
    public DateTimeOffset StartTime { get; init; }
    [Required]
    [DataType(DataType.DateTime)]
    public DateTimeOffset EndTime { get; init; }
}
