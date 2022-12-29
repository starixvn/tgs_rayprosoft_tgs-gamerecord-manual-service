using System.ComponentModel.DataAnnotations;
using Tgs.GameRecord.ManualService.Attributes;

namespace Tgs.GameRecord.ManualService.ViewModels;

public record SM01QueryViewModel
{
    [Required]
    public Uri ApiUrl { get; init; } = default!;
    [Required]
    public string GameProviderMerchantId { get; init; } = default!;
    [Required]
    public string GameProviderMerchantKey { get; init; } = default!;
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime StartTime { get; init; }
    [Required]
    [DataType(DataType.DateTime)]
    [DateTimeRange("StartTime", 1800)]
    public DateTime EndTime { get; init; }
}
