using System.ComponentModel.DataAnnotations;
using Tgs.GameRecord.ManualService.Attributes;

namespace Tgs.GameRecord.ManualService.ViewModels;

public record HabaneroTransferQueryViewModel
{
    [Required]
    public Uri ApiUrl { get; init; } = default!;

    [Required]
    public string BrandId { get; init; } = default!;
    [Required]
    public string ApiKey { get; init; } = default!;
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime StartTime { get; init; }
    [Required]
    [DataType(DataType.DateTime)]
    [DateTimeRange("StartTime", 3600)]
    public DateTime EndTime { get; init; }
}
