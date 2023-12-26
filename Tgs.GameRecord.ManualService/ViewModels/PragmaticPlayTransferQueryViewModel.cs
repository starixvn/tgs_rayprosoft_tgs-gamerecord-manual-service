using System.ComponentModel.DataAnnotations;
using Tgs.GameRecord.ManualService.Attributes;

namespace Tgs.GameRecord.ManualService.ViewModels;

public record PragmaticPlayTransferQueryViewModel
{
    /// <summary>
    /// The API URL
    /// </summary>
    [Required]
    [DataType(DataType.Url)]
    public Uri ApiUrl { get; init; } = default!;
    /// <summary>
    /// The secure login
    /// </summary>
    [Required]
    public string SecureLogin { get; init; } = default!;
    /// <summary>
    /// The secret key
    /// </summary>
    [Required]
    public string SecretKey { get; init; } = default!;
    [Required]
    [DataType(DataType.DateTime)]
    public DateTimeOffset StartTime { get; init; }
    [Required]
    [DataType(DataType.DateTime)]
    [DateTimeRange("StartTime", 60)]
    public DateTimeOffset EndTime { get; init; }
}
