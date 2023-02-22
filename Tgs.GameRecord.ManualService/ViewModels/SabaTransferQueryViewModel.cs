using System.ComponentModel.DataAnnotations;
using Tgs.GameRecord.ManualService.Attributes;

namespace Tgs.GameRecord.ManualService.ViewModels;

public class SabaTransferQueryViewModel
{
    [Required]
    public Uri ApiUrl { get; init; } = default!;

    [Required]
    [DataType(DataType.DateTime)]
    [DateTimeRange("StartTime", 86400)]
    public DateTime EndTime { get; init; }

    [Required]
    public string OperatorId { get; init; } = default!;

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime StartTime { get; init; }

    [Required]
    public string VendorId { get; init; } = default!;
}
